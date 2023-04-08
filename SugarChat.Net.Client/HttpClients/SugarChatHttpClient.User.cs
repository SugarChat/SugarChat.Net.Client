﻿using Newtonsoft.Json;
using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Users;
using SugarChat.Message.Dtos;
using SugarChat.Message.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SugarChat.Net.Client.HttpClients
{
    public partial class SugarChatHttpClient
    {
        private const string _getUserProfileUrl = "api/user/getUserProfile";
        private const string _updateMyProfileUrl = "api/user/updateMyProfile";
        private const string _createUserUrl = "api/user/create";
        private const string _removeUserUrl = "api/user/remove";
        private const string _batchAddUsersUrl = "api/user/batchAddUsers";

        public async Task<SugarChatResponse<UserDto>> GetUserProfileAsync(GetUserRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            var requestUrl = $"{_getUserProfileUrl}?id={request.Id}";
            return await ExecuteAsync<SugarChatResponse<UserDto>>(httpClient, correlationId, requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> UpdateMyProfileAsync(UpdateUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _updateMyProfileUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> CreateUserAsync(AddUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _createUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveUserAsync(RemoveUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _removeUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchAddUsers(BatchAddUsersCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _batchAddUsersUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }
    }
}
