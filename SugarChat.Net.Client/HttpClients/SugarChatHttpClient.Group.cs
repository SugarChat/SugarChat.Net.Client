using Newtonsoft.Json;
using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Groups;
using SugarChat.Message.Commands.GroupUsers;
using SugarChat.Message.Dtos;
using SugarChat.Message.Dtos.GroupUsers;
using SugarChat.Message.Paging;
using SugarChat.Message.Requests;
using SugarChat.Message.Requests.Groups;
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
        private const string _createGroupUrl = "api/group/create";
        private const string _batchCreateGroupUrl = "api/group/batchCreate";
        private const string _dismissGroupUrl = "api/group/dismiss";
        private const string _getGroupListUrl = "api/group/getGroupList";
        private const string _getGroupProfileUrl = "api/group/getGroupProfile";
        private const string _updateGroupProfileUrl = "api/group/updateGroupProfile";
        private const string _removeGroupUrl = "api/group/remove";
        private const string _getGroupMemberListUrl = "api/groupUser/getGroupMemberList";
        private const string _setGroupMemberCustomFieldUrl = "api/groupUser/setGroupMemberCustomField";
        private const string _joinGroupUrl = "api/groupUser/join";
        private const string _quitGroupUrl = "api/groupUser/quit";
        private const string _changeGroupOwnerUrl = "api/groupUser/changeGroupOwner";
        private const string _addGroupMemberUrl = "api/groupUser/addGroupMember";
        private const string _batchAddGroupMemberUrl = "api/groupUser/batchAddGroupMember";
        private const string _deleteGroupMemberUrl = "api/groupUser/deleteGroupMember";
        private const string _setMessageRemindTypeUrl = "api/groupUser/setMessageRemindType";
        private const string _setGroupMemberRoleUrl = "api/groupUser/setGroupMemberRole";
        private const string _getUserIdsByGroupIdsUrl = "api/groupUser/getUserIdsByGroupIds";
        private const string _getByCustomPropertiesUrl = "api/group/getByCustomProperties";
        private const string _updateGroupUserUrl = "api/GroupUser/UpdateGroupUserData";
        private const string _removeUserFromGroupUrl = "api/GroupUser/RemoveUserFromGroup";
        private const string _checkUserIsInGroupUrl = "api/GroupUser/CheckUserIsInGroup";

        public async Task<SugarChatResponse> CreateGroupAsync(AddGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _createGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchCreateGroupAsync(BatchAddGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _batchCreateGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> DismissGroupAsync(DismissGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _dismissGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<PagedResult<GroupDto>>> GetGroupListAsync(GetGroupsOfUserRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            string requestUrl;
            if (request.PageSettings is null)
            {
                requestUrl = $"{_getGroupListUrl}?userId={request.UserId}";
            }
            else
            {
                requestUrl = $"{_getGroupListUrl}?userId={request.UserId}&pageSettings.pageSize={request.PageSettings.PageSize}&pageSettings.pageNum={request.PageSettings.PageNum}";
            }
            return await ExecuteAsync<SugarChatResponse<PagedResult<GroupDto>>>(httpClient, correlationId, requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<GroupDto>> GetGroupProfileAsync(GetGroupProfileRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            var requestUrl = $"{_getGroupProfileUrl}?userId={request.UserId}&groupId={request.GroupId}";
            return await ExecuteAsync<SugarChatResponse<GroupDto>>(httpClient, correlationId, requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> UpdateGroupProfileAsync(UpdateGroupProfileCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _updateGroupProfileUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveGroupAsync(RemoveGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _removeGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<IEnumerable<GroupUserDto>>> GetGroupMemberListAsync(GetMembersOfGroupRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            var requestUrl = $"{_getGroupMemberListUrl}?userId={request.UserId}&groupId={request.GroupId}";
            return await ExecuteAsync<SugarChatResponse<IEnumerable<GroupUserDto>>>(httpClient, correlationId, requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetGroupMemberCustomFieldAsync(SetGroupMemberCustomFieldCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _setGroupMemberCustomFieldUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> JoinGroupAsync(JoinGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _joinGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> QuitGroupAsync(QuitGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _quitGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> ChangeGroupOwnerAsync(ChangeGroupOwnerCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _changeGroupOwnerUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> AddGroupMemberAsync(AddGroupMemberCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _addGroupMemberUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchAddGroupMemberAsync(BatchAddGroupMemberCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _batchAddGroupMemberUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> DeleteGroupMemberAsync(RemoveGroupMemberCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _deleteGroupMemberUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetMessageRemindTypeAsync(SetMessageRemindTypeCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _setMessageRemindTypeUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> SetGroupMemberRoleAsync(SetGroupMemberRoleCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _setGroupMemberRoleUrl, HttpMethod.Post, JsonConvert.SerializeObject(command)).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> UpdateGroupUserDataAsync(UpdateGroupUserDataCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _updateGroupUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveUserFromGroupAsync(RemoveUserFromGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse>(httpClient, correlationId, _removeUserFromGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse<bool>> CheckUserIsInGroupAsync(CheckUserIsInGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null)
        {
            return await ExecuteAsync<SugarChatResponse<bool>>(httpClient, correlationId, _checkUserIsInGroupUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }
    }
}
