
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace StrefaKibicaGeek.Utils
{
    public static class GeoHelper
    {
        //Constants for the Clustering
        //(addressable area in Bing Maps)
        private static  double MinLatitude = -85.05112878;
        private static  double MaxLatitude = 85.05112878;
        private static  double MinLongitude = -180;
        private static  double MaxLongitude = 180;

        private static  double EquatorialEarthRadiusInMeters = 6378137;
        private static  double AxisBInMeters = 6356752.31424518; // From WGS84 earth flattening coefficient definition.

        /// <summary>
        /// Computes the distance between points on the WGS84 ellipsoid.        
        /// </summary>
        /// <remarks>
        /// Took from http://www.mathworks.com/matlabcentral/fx_files/5379/1/vdist.m which is based on T. Vincenty's algorithm.
        /// Code is specifically license free.
        /// </remarks>
        /// <param name="latitudeA"></param>
        /// <param name="longitudeA"></param>
        /// <param name="latitudeB"></param>
        /// <param name="longitudeB"></param>
        /// <returns></returns>
        public static double CalculateDistance(double latitudeA, double longitudeA, double latitudeB, double longitudeB)
        {

            // Convert to radians.
            latitudeA *= Math.PI / 180.0;
            longitudeA *= Math.PI / 180.0;
            latitudeB *= Math.PI / 180.0;
            longitudeB *= Math.PI / 180.0;

            // Correct for errors at exact poles by adjusting 0.6 millimeters.
            if (Math.Abs(Math.PI / 2.0 - Math.Abs(latitudeA)) < 1e-10)
            {
                latitudeA = Math.Sign(latitudeA) * (Math.PI / 2.0 - 1e-10);
            }
            if (Math.Abs(Math.PI / 2.0 - Math.Abs(latitudeB)) < 1e-10)
            {
                latitudeB = Math.Sign(latitudeB) * (Math.PI / 2.0 - 1e-10);
            }

            // Limit the longitude.
            longitudeA %= Math.PI * 2.0;
            longitudeB %= Math.PI * 2.0;
            double longitudeDelta = Math.Abs(longitudeB - longitudeA);
            if (longitudeDelta > Math.PI)
            {
                longitudeDelta = Math.PI * 2.0 - longitudeDelta;
            }

            double f = (EquatorialEarthRadiusInMeters - AxisBInMeters) / EquatorialEarthRadiusInMeters;
            double uA = Math.Atan((1.0 - f) * Math.Tan(latitudeA));
            double uB = Math.Atan((1.0 - f) * Math.Tan(latitudeB));
            double lambda = longitudeDelta;
            double lambdaOld = 0;
            double sigma = 0;
            double cos2Sigmam = 0;
            double alpha = 0;
            double cosAlpha2 = 0;

            int i = 0;
            do
            {
                if (i > 50)
                {
                    lambda = Math.PI;
                    break;
                }
                lambdaOld = lambda;

                double cosUA = Math.Cos(uA);
                double cosUB = Math.Cos(uB);
                double sinUA = Math.Sin(uA);
                double sinUB = Math.Sin(uB);

                double sinSigma = Math.Sqrt(
                      Math.Pow(cosUB * Math.Sin(lambda), 2.0) +
                      Math.Pow(cosUA * sinUB - sinUA * cosUB * Math.Cos(lambda), 2.0));
                double cosSigma =
                      sinUA * sinUB + cosUA * cosUB * Math.Cos(lambda);
                sigma = Math.Atan2(sinSigma, cosSigma);
                alpha = Math.Asin(cosUA * cosUB * Math.Sin(lambda) / Math.Sin(sigma));
                cosAlpha2 = Math.Pow(Math.Cos(alpha), 2.0);
                cos2Sigmam = Math.Cos(sigma) - 2.0 * sinUA * sinUB / cosAlpha2;
                double c = f / 16.0 * cosAlpha2 * (4.0 + f * (4.0 - 3.0 * cosAlpha2));
                lambda =
                      longitudeDelta + (1.0 - c) * f * Math.Sin(alpha) * (sigma + c * Math.Sin(sigma) *
                      (cos2Sigmam + c * Math.Cos(sigma) * (-1.0 + 2.0 * cos2Sigmam * cos2Sigmam)));

                // Correct for convergence failure in the case of essentially antipodal points.
                if (lambda > Math.PI)
                {
                    lambda = Math.PI;
                    break;
                }

                ++i;
            } while (Math.Abs(lambda - lambdaOld) > 1e-12);

            uB = cosAlpha2 * (EquatorialEarthRadiusInMeters * EquatorialEarthRadiusInMeters - AxisBInMeters * AxisBInMeters) / (AxisBInMeters * AxisBInMeters);
            double a = 1.0 + uB / 16384.0 * (4096.0 + uB * (-768.0 + uB * (320.0 - 175.0 * uB)));
            double b = uB / 1024.0 * (256.0 + uB * (-128.0 + uB * (74.0 - 47.0 * uB)));
            double deltaSigma =
                  b * Math.Sin(sigma) * (cos2Sigmam + b / 4.0 * (Math.Cos(sigma) * (-1.0 * 2.0 * cos2Sigmam * cos2Sigmam)
                  - b / 6.0 * cos2Sigmam * (-3.0 + 4.0 * Math.Pow(Math.Sin(sigma), 2.0)) * (-3.0 + 4.0 * cos2Sigmam * cos2Sigmam)));
            return AxisBInMeters * a * (sigma - deltaSigma);
        }
    }
}
