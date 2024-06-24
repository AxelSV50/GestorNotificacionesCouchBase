using Couchbase;
using Couchbase.Core;
using Couchbase.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace GestorNotificaciones
{
    public class Utils
    {
        private readonly IBucket _bucket;
        private readonly string _apiHost;
        private readonly string _emailAPI;

        public Utils(IConfiguration configuration, INotificationBucketProvider bucketProvider)
        {
            _bucket = bucketProvider.GetBucketAsync().Result;
            _apiHost = configuration.GetValue<string>("APIHost");
            _emailAPI = configuration.GetValue<string>("EmailAPI");
        }

        public IBucket GetBucket()
        {
            return _bucket;
        }

        public string GetEmailAPI()
        {
            return _emailAPI;
        }

        public HttpClient GetAPIHost()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiHost);
            return client;
        }

        private static string DecryptConnectionString(string encryptedConnectionString)
        {
            byte[] decodedBytes = Convert.FromBase64String(encryptedConnectionString);
            string decryptedConnectionString = System.Text.Encoding.UTF8.GetString(decodedBytes);

            //Debug.WriteLine(decryptedConnectionString);

            return decryptedConnectionString;
        }
    }
}
