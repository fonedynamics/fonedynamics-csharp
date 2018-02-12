using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoneDynamics.Http
{
    /// <summary>
    /// Client to make HTTP requests.
    /// </summary>
    internal class HttpClient
    {
        /// <summary>
        /// The .NET HttpClient to use when making requests.
        /// </summary>
        private readonly System.Net.Http.HttpClient _httpClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        internal HttpClient()
        {
            // initialise the HttpClient
            _httpClient = new System.Net.Http.HttpClient();
        }

        /// <summary>
        /// Sends the specified request and returns the response.
        /// </summary>
        internal HttpResponse Send(Request request)
        {
            try
            {
                // perform synchronously
                Task<HttpResponse> task = SendAsync(request);
                task.Wait();
                return task.Result;
            }
            catch (AggregateException ex)
            {
                // throw first exception
                throw ex.Flatten().InnerExceptions[0];
            }
        }

        /// <summary>
        /// Sends the specified request and returns the response.
        /// </summary>
        private async Task<HttpResponse> SendAsync(Request request)
        {
            // perform the request
            HttpRequestMessage msg = CreateHttpRequest(request);
            HttpResponseMessage response = await _httpClient.SendAsync(msg).ConfigureAwait(false);
            byte[] responseBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            return new HttpResponse((int)response.StatusCode, responseBytes);
        }

        /// <summary>
        /// Creates the HTTP request.
        /// </summary>
        private HttpRequestMessage CreateHttpRequest(Request request)
        {
            // create request message
            HttpRequestMessage msg = new HttpRequestMessage(new System.Net.Http.HttpMethod(request.Method.ToString().ToUpper()), request.CreateUri());
            msg.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(Utility.Json.CONTENT_TYPE));
            msg.Headers.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-8"));
            msg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{request.AccountSid}:{request.Token}")));

            // configure request body
            if (request.RequestBody != null)
            {
                msg.Content = new ByteArrayContent(request.RequestBody);
                if (request.ContentType != null)
                {
                    msg.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(request.ContentType);
                }
            }

            return msg;
        }
    }
}
