using Newtonsoft.Json;
using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Conversations;
using SugarChat.Message.Commands.Messages;
using SugarChat.Message.Dtos.Conversations;
using SugarChat.Message.Paging;
using SugarChat.Message.Requests.Conversations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SugarChat.Net.Client.HttpClients
{
    public partial class SugarChatHttpClient
    {
        private const string _getMessageListUrl = "api/conversation/getMessageList";
        private const string _getConversationListUrl = "api/conversation/getConversationList";
        private const string _getUnreadConversationListUrl = "api/conversation/getUnreadConversationList";
        private const string _getConversationProfileUrl = "api/conversation/getConversationProfile";
        private const string _setMessageReadUrl = "api/conversation/setMessageRead";
        private const string _deleteConversationUrl = "api/conversation/deleteConversation";
        private const string _setMessageReadSetByUserBasedOnGroupIdUrl = "api/conversation/setMessageReadSetByUserBasedOnGroupId";
        private const string _getConversationByKeywordUrl = "api/conversation/getConversationByKeyword";
        private const string _setMessageReadByUserIdsBasedOnGroupIdUrl = "api/conversation/setMessageReadByUserIdsBasedOnGroupId";
        private const string _batchSetMessageReadByUserIdsBasedOnGroupIdUrl = "api/conversation/batchSetMessageReadByUserIdsBasedOnGroupId";
        private const string _setMessageUnreadByUserIdsBasedOnGroupIdUrl = "api/conversation/setMessageUnreadByUserIdsBasedOnGroupId";

        public async Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationListAsync(GetConversationListRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<PagedResult<ConversationDto>>>(_getConversationListUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<PagedResult<ConversationDto>>> GetUnreadConversationListAsync(GetUnreadConversationListRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<PagedResult<ConversationDto>>>(_getUnreadConversationListUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<ConversationDto>> GetConversationProfileAsync(GetConversationProfileRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getConversationProfileUrl}?conversationId={request.ConversationId}&userId={request.UserId}";
            return await ExecuteAsync<SugarChatResponse<ConversationDto>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetMessageReadAsync(SetMessageReadByUserBasedOnMessageIdCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_setMessageReadUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> DeleteConversationAsync(RemoveConversationCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_deleteConversationUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetMessageReadSetByUserBasedOnGroupIdAsync(SetMessageReadByUserBasedOnGroupIdCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_setMessageReadSetByUserBasedOnGroupIdUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetMessageReadByUserIdsBasedOnGroupIdAsync(SetMessageReadByUserIdsBasedOnGroupIdCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_setMessageReadByUserIdsBasedOnGroupIdUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchSetMessageReadByUserIdsBasedOnGroupIdAsync(BatchSetMessageReadByUserIdsBasedOnGroupIdCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_batchSetMessageReadByUserIdsBasedOnGroupIdUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetMessageUnreadByUserIdsBasedOnGroupIdAsync(SetMessageUnreadByUserIdsBasedOnGroupIdCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_setMessageUnreadByUserIdsBasedOnGroupIdUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }
    }
}
