﻿using Newtonsoft.Json;
using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Messages;
using SugarChat.Message.Dtos;
using SugarChat.Message.Paging;
using SugarChat.Message.Requests;
using SugarChat.Message.Requests.Conversations;
using SugarChat.Message.Requests.Messages;
using SugarChat.Message.Responses.Conversations;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SugarChat.Net.Client.HttpClients
{
    public partial class SugarChatHttpClient
    {
        private const string _sendMessageUrl = "api/message/send";
        private const string _batchSendMessageUrl = "api/message/batchSend";
        private const string _revokeMessageUrl = "api/message/revoke";
        private const string _getUnreadMessageCountUrl = "api/message/getUnreadMessageCount";
        private const string _getUnreadMessagesFromGroupUrl = "api/message/getUnreadMessagesFromGroup";
        private const string _getAllToUserFromGroupUrl = "api/message/getAllToUserFromGroup";
        private const string _getMessagesOfGroupUrl = "api/message/getMessagesOfGroup";
        private const string _getMessagesOfGroupBeforeUrl = "api/message/getMessagesOfGroupBefore";
        private const string _getMessagesByGroupIdsUrl = "api/message/getMessagesByGroupIds";
        private const string _translateMessageUrl = "api/message/translate";
        private const string _updateMessageUrl = "api/Message/updateMessageData";

        public async Task<SugarChatResponse<GetMessageListResponse>> GetMessageListAsync(GetMessageListRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getMessageListUrl}?userId={request.UserId}&conversationId={request.ConversationId}&nextReqMessageId={request.NextReqMessageId}&count={request.Count}&index={request.Index}";
            return await ExecuteAsync<SugarChatResponse<GetMessageListResponse>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SendMessageAsync(SendMessageCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_sendMessageUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchSendMessageAsync(BatchSendMessageCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_batchSendMessageUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RevokeMessageAsync(RevokeMessageCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_revokeMessageUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<int>> GetUnreadMessageCountAsync(GetUnreadMessageCountRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<int>>(_getUnreadMessageCountUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<MessageDto>>> GetUnreadMessagesFromGroupAsync(GetUnreadMessagesFromGroupRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getUnreadMessagesFromGroupUrl}?userId={request.UserId}&groupId={request.GroupId}&messageId={request.MessageId}&count={request.Count}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<MessageDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<MessageDto>>> GetAllToUserFromGroupAsync(GetAllMessagesFromGroupRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getAllToUserFromGroupUrl}?userId={request.UserId}&groupId={request.GroupId}&index={request.Index}&messageId={request.MessageId}&count={request.Count}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<MessageDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<PagedResult<MessageDto>>> GetMessagesOfGroupAsync(GetMessagesOfGroupRequest request, CancellationToken cancellationToken = default)
        {
            string requestUrl = $"{_getMessagesOfGroupUrl}?groupId={request.GroupId}";
            if (request.FromDate != null)
            {
                requestUrl += $"&fromDate={request.FromDate.Value.ToString("yyyy-MM-dd HH:mm:ss")}";
            }
            if (request.PageSettings != null)
            {
                requestUrl += $"&pageSettings.pageSize={request.PageSettings.PageSize}&pageSettings.pageNum={request.PageSettings.PageNum}";
            }
            return await ExecuteAsync<SugarChatResponse<PagedResult<MessageDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<MessageDto>>> GetMessagesOfGroupBeforeAsync(GetMessagesOfGroupBeforeRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getMessagesOfGroupBeforeUrl}?messageId={request.MessageId}&count={request.Count}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<MessageDto>>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<MessageTranslateDto>> TranslateMessageAsync(TranslateMessageCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<MessageTranslateDto>>(_translateMessageUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> UpdateMessageDataAsync(UpdateMessageDataCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_updateMessageUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<PagedResult<MessageDto>>> GetMessagesByGroupIdsAsync(GetMessagesByGroupIdsRequest request, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse<PagedResult<MessageDto>>>(_getMessagesByGroupIdsUrl, HttpMethod.Post, JsonConvert.SerializeObject(request), cancellationToken).ConfigureAwait(false);
        }
    }
}
