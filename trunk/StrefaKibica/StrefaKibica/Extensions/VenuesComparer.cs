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
using System.Collections;
using StrefaKibicaGeek.Models;
using System.Collections.Generic;

namespace StrefaKibicaGeek.Extensions
{
    public class VenuesComparer<T> : IEqualityComparer<T>
    {
        
        public bool Equals(T x, T y)
        {
            if (x.GetType() == typeof(Venue) && y.GetType() == typeof(Venue))
            {
                Venue X = x as Venue;
                Venue Y = y as Venue;
                return X.Name == Y.Name;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }

    public class VenuesRemoveWithoutTipsComparer<T> : IEqualityComparer<T>
    {

        public bool Equals(T x, T y)
        {
            if (x.GetType() == typeof(Venue) && y.GetType() == typeof(Venue))
            {
                Venue X = x as Venue;
                Venue Y = y as Venue;
                return X.Name == Y.Name;
            }
            else
            {
                return false;
            }
        }

        public int GetHashCode(T obj)
        {
            return obj.GetHashCode();
        }
    }
}
