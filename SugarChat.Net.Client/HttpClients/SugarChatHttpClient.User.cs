using Newtonsoft.Json;
using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Users;
using SugarChat.Message.Dtos;
using SugarChat.Message.Requests;
using System.Net.Http;
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
        private const string _removeAllUserUrl = "api/user/removeAll";

        public async Task<SugarChatResponse<UserDto>> GetUserProfileAsync(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            var requestUrl = $"{_getUserProfileUrl}?id={request.Id}";
            return await ExecuteAsync<SugarChatResponse<UserDto>>(requestUrl, HttpMethod.Get, cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> UpdateMyProfileAsync(UpdateUserCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_updateMyProfileUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> CreateUserAsync(AddUserCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_createUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveUserAsync(RemoveUserCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_removeUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> RemoveAllUserAsync(RemoveAllUserCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_removeAllUserUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }

        public async Task<SugarChatResponse> BatchAddUsers(BatchAddUsersCommand command, CancellationToken cancellationToken = default)
        {
            return await ExecuteAsync<SugarChatResponse>(_batchAddUsersUrl, HttpMethod.Post, JsonConvert.SerializeObject(command), cancellationToken).ConfigureAwait(false);
        }
    }
}
