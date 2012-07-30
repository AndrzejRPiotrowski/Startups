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
using System.Collections.Generic;
using Facebook;

namespace StrefaKibicaGeek.SvcProvider
{
    public class FBAuthenticationService
    {
        static readonly string appID = "214291538691243";
        public static string AccessToken { get; set; }

        public bool IsConnected { get; private set; }
        public string ErrorDescription { get; set; }
        public string ErrorReason { get; set; }

        private string extendedPermissions = "user_about_me, friends_about_me, user_status, friends_status, user_events, friends_events, create_event, rsvp_event";

        FacebookClient fbClient = null;

        public FBAuthenticationService()
        {
            fbClient = new FacebookClient();
            IsConnected = false;
        }

        public Uri GetLoginUrl()
        {
            // for .net 3.5
            var parameters = new Dictionary<string, object>();
            parameters["client_id"] = appID;
            parameters["redirect_uri"] = "https://www.facebook.com/connect/login_success.html";
            //dynamic parameters = new ExpandoObject();
            //parameters.client_id = appId;
            //parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";

            // The requested response: an access token (token), an authorization code (code), or both (code token).
            parameters["response_type"] = "token";

            // list of additional display modes can be found at http://developers.facebook.com/docs/reference/dialogs/#display
            parameters["display"] = "popup";//"touch"; 

            // add the 'scope' parameter only if we have extendedPermissions.
            if (!string.IsNullOrWhiteSpace(extendedPermissions))
                parameters["scope"] = extendedPermissions;

            // generate the login url
            //var fb = new FacebookClient();
            return fbClient.GetLoginUrl(parameters);
        }

        public Uri GetLogoutUrl()
        {
            //var parameters = new Dictionary<string, object>();
            //parameters["access_token"] = accessToken;
            //parameters["confirm"] = 1;
            //parameters["next"] = "https://www.facebook.com/connect/login_success.html";

            //var fb = new FacebookClient();
            var logoutUrl = fbClient.GetLogoutUrl(//parameters);
                new
                {
                    access_token = AccessToken,
                    confirm = 1,
                    next = "https://www.facebook.com/connect/login_success.html"
                });
            //MessageBox.Show(logoutUrl.ToString());
            return logoutUrl;
        }

        public bool? ParseResponse(Uri response)
        {
            //var fb = new FacebookClient();
            FacebookOAuthResult oauthResult;
            if (fbClient.TryParseOAuthCallbackUrl(response, out oauthResult))
            {
                // The url is the result of OAuth 2.0 authentication
                if (oauthResult.IsSuccess)
                {
                    AccessToken = oauthResult.AccessToken;
                    IsConnected = true;
                    //doSomething();
                    return true;
                }
                else
                {
                    ErrorDescription = oauthResult.ErrorDescription;
                    ErrorReason = oauthResult.ErrorReason;

                    IsConnected = false;
                    //MessageBox.Show("Error: " + errorDescription + Environment.NewLine + errorReason);
                    return false;
                }

                //webBrowser1.Navigated -= new EventHandler<System.Windows.Navigation.NavigationEventArgs>(webBrowser1_Navigated);
            }
            else
            {
                // The url is NOT the result of OAuth 2.0 authentication.
                //throw new Exception("URL is not a valid result.");
                return null;
            }
        }

    }
}
