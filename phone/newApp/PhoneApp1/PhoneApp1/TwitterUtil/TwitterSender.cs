using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Hammock;
using Hammock.Authentication.OAuth;
using Hammock.Web;
using Microsoft.Xna.Framework.Media;
using UserInterface;

namespace twit.Common
{
    class TwitterSender
    {
        private readonly TwitterAccess _twitterSettings;
        private readonly bool _authorized;
        private readonly OAuthCredentials _credentials;
        private readonly RestClient _client;
        public event EventHandler TweetCompletedEvent;
        public event EventHandler ErrorEvent;
        public TwitterSender(TwitterAccess settings)
        {
            _twitterSettings = settings;
            if (_twitterSettings == null ||
                String.IsNullOrEmpty(_twitterSettings.AccessToken) ||
                String.IsNullOrEmpty(_twitterSettings.AccessTokenSecret))
            {
                return;
            }
            _authorized = true;
            _credentials = new OAuthCredentials
            {
                Type = OAuthType.ProtectedResource,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ParameterHandling = OAuthParameterHandling.HttpAuthorizationHeader,
                ConsumerKey = TwitterSettings.ConsumerKey,
                ConsumerSecret = TwitterSettings.ConsumerKeySecret,
                Token = _twitterSettings.AccessToken,
                TokenSecret = _twitterSettings.AccessTokenSecret,
                Version = TwitterSettings.OAuthVersion,
            };
            _client = new RestClient
            {
                Authority = "https://api.twitter.com",
                HasElevatedPermissions = true
            };
        }
       
        public void NewTweet(string tweetText, int index)
        {
            if (!_authorized)
            {
                if (ErrorEvent != null)
                    ErrorEvent(this, EventArgs.Empty);
                return;
            }

            //Stream stream = Application.GetResourceStream(new Uri("Background.png", UriKind.Relative)).Stream;

            var request = new RestRequest
            {
                Credentials = _credentials,
                Path = "/1.1/statuses/update_with_media.json",
                Method = WebMethod.Post
            };
            request.AddParameter("status", tweetText);
            var lib = new MediaLibrary();
            string filename = "ocrAppImage" + (index) + ".jpg";

            Stream stream = lib.Pictures.ElementAt(index).GetImage();
            request.AddFile("media[]", filename, stream, "image/jpg");
            _client.BeginRequest(request, new RestCallback(NewTweetCompleted));
        }
        private void NewTweetCompleted(RestRequest request, RestResponse response, object userstate)
        {
            // We want to ensure we are running on our thread UI
            Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (TweetCompletedEvent != null)
                            TweetCompletedEvent(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(response.Content);
                        if (ErrorEvent != null)
                            ErrorEvent(this, EventArgs.Empty);
                    }
                });
        }
    }
}
