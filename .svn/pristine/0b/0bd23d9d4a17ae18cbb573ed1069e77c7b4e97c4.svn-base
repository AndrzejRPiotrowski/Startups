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
using System.Security.Cryptography;

namespace StrefaKibicaGeek.Utils
{
    public class OAuth
    {
        public OAuth()
        {

        }

        public void DoAuthenticate()
        {
            // twitter
            var oauth_token = "819797-Jxq8aYUDRmykzVKrgoLhXSq67TEa5ruc4GJC2rWimw";
            var oauth_token_secret = "J6zix3FfA9LofH0awS24M3HcBYXO5nI1iYe8EfBA";
            var oauth_consumer_key = "GDdmIQH6jhtmLUypg82g";
            var oauth_consumer_secret = "MCD8BKwGdgPHvAuvgvz4EQpqDAtx89grbuNMRd7Eh98";
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";
            var oauth_nonce = Convert.ToBase64String(FromCharsToBytes(DateTime.Now.Ticks.ToString().ToCharArray()));
            
            // facebook
            var appID = "184484190795";
            var oauth_access_token = "AAAAAKvQdWksBAKOU47OAJKVnT4AQjDorG6eFqBMZAtsYmTnHIqFOMYlqE2r7ELRhF5gTZBxYx4nadwwafoW3bXBLsgfdiZBsPe0WFSR6ZAT4iWZBnG7ZAN";
            var signedRequest = "CjzDDttm_bH6c372Ue2zRbax_I7pSmRpmjzsnOiVWK4";

            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
            var resource_url = "http://api.twitter.com/1/statuses/update.json";
            var status = "Updating status via REST API if this works";


            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version,
                                        Uri.EscapeDataString(status)
                                        );

            baseString = string.Concat("POST&", Uri.EscapeDataString(resource_url),
                         "&", Uri.EscapeDataString(baseString));


            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                        "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(FromStringToBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(FromStringToBytes(baseString)));
            }


            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                   "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                   "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                   "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );


            var postBody = "status=" + Uri.EscapeDataString(status);



            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers["Authorization"] = authHeader;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";


            //using (Stream stream = request.GetRequestStream())
            //{
            //    byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
            //    stream.Write(content, 0, content.Length);
            //}

            IAsyncResult response = request.BeginGetResponse
                (
                new AsyncCallback
                    (
                    (Arg) => { }
                    ),
                    null
                );

        }

        private byte[] FromCharsToBytes(char[] charArray)
        {
            char[] CharArr = charArray;
            byte[] ByteArr = new byte[CharArr.Length];

            for (int i = 0; i < CharArr.Length; i++)
                ByteArr[i] = (byte)CharArr[i];

            return ByteArr;
        }

        private byte[] FromStringToBytes(String stringpiece)
        {
            char[] CharArr = stringpiece.ToCharArray();
            byte[] ByteArr = new byte[CharArr.Length];

            for (int i = 0; i < CharArr.Length; i++)
                ByteArr[i] = (byte)CharArr[i];

            return ByteArr;
        }

    }
}
