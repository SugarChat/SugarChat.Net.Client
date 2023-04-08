using SugarChat.Message.Basic;
using SugarChat.Message.Commands.Conversations;
using SugarChat.Message.Commands.Friends;
using SugarChat.Message.Commands.Groups;
using SugarChat.Message.Commands.GroupUsers;
using SugarChat.Message.Commands.Messages;
using SugarChat.Message.Commands.Users;
using SugarChat.Message.Dtos;
using SugarChat.Message.Dtos.Conversations;
using SugarChat.Message.Dtos.GroupUsers;
using SugarChat.Message.Paging;
using SugarChat.Message.Requests;
using SugarChat.Message.Requests.Conversations;
using SugarChat.Message.Requests.Groups;
using SugarChat.Message.Requests.GroupUsers;
using SugarChat.Message.Requests.Messages;
using SugarChat.Message.Responses.Conversations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SugarChat.Message.Commands.Emotions;
using SugarChat.Message.Dtos.Configurations;
using SugarChat.Message.Dtos.Emotions;
using SugarChat.Message.Requests.Configurations;
using SugarChat.Message.Requests.Emotions;
using System.Net.Http;

namespace SugarChat.Net.Client
{
    public interface ISugarChatClient
    {

        Task<string> GetConnectionUrlAsync(string userIdentifier, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<GetMessageListResponse>> GetMessageListAsync(GetMessageListRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationListAsync(GetConversationListRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<PagedResult<ConversationDto>>> GetUnreadConversationListAsync(GetUnreadConversationListRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<ConversationDto>> GetConversationProfileAsync(GetConversationProfileRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> SetMessageReadAsync(SetMessageReadByUserBasedOnMessageIdCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> DeleteConversationAsync(RemoveConversationCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> AddFriendAsync(AddFriendCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> RemoveFriendAsync(RemoveFriendCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> AddEmotionAsync(AddEmotionCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> RemoveEmotionAsync(RemoveEmotionCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetUserEmotionsAsync(GetUserEmotionsRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetEmotionByIdsAsync(GetEmotionByIdsRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);
        
        Task<SugarChatResponse> CreateGroupAsync(AddGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> DismissGroupAsync(DismissGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<PagedResult<GroupDto>>> GetGroupListAsync(GetGroupsOfUserRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<GroupDto>> GetGroupProfileAsync(GetGroupProfileRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> UpdateGroupProfileAsync(UpdateGroupProfileCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> RemoveGroupAsync(RemoveGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<GroupUserDto>>> GetGroupMemberListAsync(GetMembersOfGroupRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> SetGroupMemberCustomFieldAsync(SetGroupMemberCustomFieldCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> JoinGroupAsync(JoinGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> QuitGroupAsync(QuitGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> ChangeGroupOwnerAsync(ChangeGroupOwnerCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> AddGroupMemberAsync(AddGroupMemberCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> DeleteGroupMemberAsync(RemoveGroupMemberCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> SetMessageRemindTypeAsync(SetMessageRemindTypeCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> SetGroupMemberRoleAsync(SetGroupMemberRoleCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> SendMessageAsync(SendMessageCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> RevokeMessageAsync(RevokeMessageCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<int>> GetUnreadMessageCountAsync(GetUnreadMessageCountRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetUnreadMessagesFromGroupAsync(GetUnreadMessagesFromGroupRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetAllToUserFromGroupAsync(GetAllMessagesFromGroupRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<PagedResult<MessageDto>>> GetMessagesOfGroupAsync(GetMessagesOfGroupRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetMessagesOfGroupBeforeAsync(GetMessagesOfGroupBeforeRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse<UserDto>> GetUserProfileAsync(GetUserRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> UpdateMyProfileAsync(UpdateUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);


        Task<SugarChatResponse> CreateUserAsync(AddUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> RemoveUserAsync(RemoveUserCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> SetMessageReadSetByUserBasedOnGroupIdAsync(SetMessageReadByUserBasedOnGroupIdCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<string>>> GetUserIdsByGroupIdsAsync(GetUserIdsByGroupIdsRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationByKeywordAsync(GetConversationByKeywordRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<GroupDto>>> GetGroupByCustomPropertiesAsync(GetGroupByCustomPropertiesRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetMessagesByGroupIdsAsync(GetMessagesByGroupIdsRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> BatchAddUsers(BatchAddUsersCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<MessageTranslateDto>> TranslateMessageAsync(TranslateMessageCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> SetMessageReadByUserIdsBasedOnGroupIdAsync(SetMessageReadByUserIdsBasedOnGroupIdCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> UpdateMessageDataAsync(UpdateMessageDataCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> UpdateGroupUserDataAsync(UpdateGroupUserDataCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse> RemoveUserFromGroupAsync(RemoveUserFromGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<ServerConfigurationsDto>> GetServerConfigurationsAsync(GetServerConfigurationsRequest request, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);

        Task<SugarChatResponse<bool>> CheckUserIsInGroupAsync(CheckUserIsInGroupCommand command, CancellationToken cancellationToken = default, HttpClient httpClient = null, string correlationId = null);
    }
}
