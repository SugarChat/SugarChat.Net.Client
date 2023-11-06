using Newtonsoft.Json;
using SugarChat.Message.Commands.Friends;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Linq;
using SugarChat.Net.Client.Exceptions;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SugarChat.Message.Requests.Conversations;
using SugarChat.Message.Requests.Groups;
using SugarChat.Message.Requests.Messages;
using SugarChat.Message.Basic;
using SugarChat.Message.Requests.GroupUsers;
using SugarChat.Message.Dtos;
using SugarChat.Message.Dtos.Conversations;
using SugarChat.Message.Paging;
using System.Text;
using SugarChat.Message.Commands.Emotions;
using SugarChat.Message.Dtos.Configurations;
using SugarChat.Message.Dtos.Emotions;
using SugarChat.Message.Requests.Configurations;
using SugarChat.Message.Requests.Emotions;

namespace SugarChat.Net.Client.HttpClients
{
    public partial class SugarChatHttpClient : ISugarChatClient
    {
        private const string _getConnectionUrl = "api/chat/getConnectionUrl";

        #region friend
        private const string _addFriendUrl = "api/friend/add";
        private const string _removeFriendUrl = "api/friend/remove";
        #endregion

        #region emotion
        private const string _addEmotionUrl = "api/emotion/add";
        private const string _removeEmotionUrl = "api/emotion/remove";
        private const string _getUserEmotionsUrl = "api/emotion/getUserEmotions";
        private const string _getEmotionByIdsUrl = "api/emotion/getEmotionByIds";
        #endregion

        private const string _getServerConfigurationsUrl = "api/Configuration/GetConfigurations";

        private readonly string _baseUrl;
        private readonly ISugarChatHttpClientFactory _httpClientFactory;
        public SugarChatHttpClient(string baseUrl, ISugarChatHttpClientFactory httpClientFactory)
        {
            _baseUrl = baseUrl;
            _httpClientFactory = httpClientFactory;
        }

        private Dictionary<string, string> _headers;

        public void SetHttpClient(Dictionary<string,string> headers)
        {
            _headers = headers;
        }

        protected struct ObjectResponseResult<T>
        {
            public ObjectResponseResult(T responseObject, string responseText)
            {
                this.Object = responseObject;
                this.Text = responseText;
            }

            public T Object { get; }

            public string Text { get; }
        }

        public bool ReadResponseAsString { get; set; }

        protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(HttpResponseMessage response, ReadOnlyDictionary<string, IEnumerable<string>> headers, CancellationToken cancellationToken)
        {
            if (response == null || response.Content == null)
            {
                return new ObjectResponseResult<T>(default(T), string.Empty);
            }

            if (ReadResponseAsString)
            {
                var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    var typedBody = JsonConvert.DeserializeObject<T>(responseText);
                    return new ObjectResponseResult<T>(typedBody, responseText);
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
                }
            }
            else
            {
                try
                {
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var streamReader = new StreamReader(responseStream))
                    using (var jsonTextReader = new JsonTextReader(streamReader))
                    {
                        var serializer = JsonSerializer.Create();
                        var typedBody = serializer.Deserialize<T>(jsonTextReader);
                        return new ObjectResponseResult<T>(typedBody, string.Empty);
                    }
                }
                catch (JsonException exception)
                {
                    var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                    throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
                }
            }
        }

        private async Task<T> ExecuteAsync<T>(
            string url,
            HttpMethod method,
            string requestString = "",
            CancellationToken cancellationToken = default)
        {
            var client = _httpClientFactory.GetHttpClient();
            if (_headers != null)
            {
                foreach (var header in _headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            client.BaseAddress = new Uri(_baseUrl);

            try
            {
                using (var request = new HttpRequestMessage(method, url))
                {
                    var content = new StringContent(requestString);
                    content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    request.Content = content;
                    request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

                    try
                    {
                        var headers = Enumerable.ToDictionary(response.Headers, h => h.Key, h => h.Value);
                        if (response.Content != null && response.Content.Headers != null)
                        {
                            foreach (var item in response.Content.Headers)
                                headers[item.Key] = item.Value;
                        }

                        var status = (int)response.StatusCode;
                        if (response.IsSuccessStatusCode)
                        {
                            var objectResponse = await ReadObjectResponseAsync<T>(response, new ReadOnlyDictionary<string, IEnumerable<string>>(headers), cancellationToken).ConfigureAwait(false);
                            if (objectResponse.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status, objectResponse.Text, headers, null);
                            }
                            return objectResponse.Object;
                        }
                        else
                        {
                            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status + ").", status, responseData, headers, null);
                        }
                    }
                    finally
                    {
                        response.Dispose();
                    }
                }
            }
            finally
            {
                client.Dispose();
            }
        }

        public async Task<string> GetConnectionUrlAsync(string userIdentifier, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getConnectionUrl}?userIdentifier={userIdentifier}";
            return await ExecuteAsync<string>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> AddFriendAsync(AddFriendCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_addFriendUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveFriendAsync(RemoveFriendCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_removeFriendUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> AddEmotionAsync(AddEmotionCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_addEmotionUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveEmotionAsync(RemoveEmotionCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_removeEmotionUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetUserEmotionsAsync(GetUserEmotionsRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getUserEmotionsUrl}?userId={request.UserId}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<EmotionDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetEmotionByIdsAsync(GetEmotionByIdsRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<IEnumerable<EmotionDto>>>(_getEmotionByIdsUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<string>>> GetUserIdsByGroupIdsAsync(GetUserIdsByGroupIdsRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<IEnumerable<string>>>(_getUserIdsByGroupIdsUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationByKeywordAsync(GetConversationByKeywordRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<PagedResult<ConversationDto>>>(_getConversationByKeywordUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<GroupDto>>> GetGroupByCustomPropertiesAsync(GetGroupByCustomPropertiesRequest request, CancellationToken cancellationToken = default)
        {
            var query = DictionariesToQuery("CustomProperties", request.CustomProperties);
            var requestUrl = $"{_getByCustomPropertiesUrl}?userId={request.UserId}&SearchAllGroup={request.SearchAllGroup}{query}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<GroupDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        private string DictionariesToQuery(string fieldName, IDictionary<string, string> dictionaries)
        {
            StringBuilder query = new StringBuilder();
            foreach (var dictionary in dictionaries)
            {
                query.Append($"&{fieldName}[{dictionary.Key}]={dictionary.Value}");
            }
            return query.ToString();
        }

        private string StringEnumerableToQuery(string fieldName, IEnumerable<string> arr)
        {
            StringBuilder query = new StringBuilder();
            foreach (var item in arr)
            {
                query.Append($"&{fieldName}={item}");
            }
            return query.ToString();
        }

        public async Task<SugarChatResponse<ServerConfigurationsDto>> GetServerConfigurationsAsync(GetServerConfigurationsRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getServerConfigurationsUrl}";
            return await ExecuteAsync<SugarChatResponse<ServerConfigurationsDto>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}
