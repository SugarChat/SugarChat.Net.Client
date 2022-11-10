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

namespace SugarChat.Net.Client
{
    public interface ISugarChatClient
    {

        Task<string> GetConnectionUrlAsync(string userIdentifier, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<GetMessageListResponse>> GetMessageListAsync(GetMessageListRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationListAsync(GetConversationListRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<ConversationDto>> GetConversationProfileAsync(GetConversationProfileRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> SetMessageReadAsync(SetMessageReadByUserBasedOnMessageIdCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> DeleteConversationAsync(RemoveConversationCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> AddFriendAsync(AddFriendCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> RemoveFriendAsync(RemoveFriendCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> AddEmotionAsync(AddEmotionCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> RemoveEmotionAsync(RemoveEmotionCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetUserEmotionsAsync(GetUserEmotionsRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<IEnumerable<EmotionDto>>> GetEmotionByIdsAsync(GetEmotionByIdsRequest request, CancellationToken cancellationToken = default);
        
        Task<SugarChatResponse> CreateGroupAsync(AddGroupCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> DismissGroupAsync(DismissGroupCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<PagedResult<GroupDto>>> GetGroupListAsync(GetGroupsOfUserRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<GroupDto>> GetGroupProfileAsync(GetGroupProfileRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> UpdateGroupProfileAsync(UpdateGroupProfileCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> RemoveGroupAsync(RemoveGroupCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<IEnumerable<GroupUserDto>>> GetGroupMemberListAsync(GetMembersOfGroupRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> SetGroupMemberCustomFieldAsync(SetGroupMemberCustomFieldCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> JoinGroupAsync(JoinGroupCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> QuitGroupAsync(QuitGroupCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> ChangeGroupOwnerAsync(ChangeGroupOwnerCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> AddGroupMemberAsync(AddGroupMemberCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> DeleteGroupMemberAsync(RemoveGroupMemberCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> SetMessageRemindTypeAsync(SetMessageRemindTypeCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> SetGroupMemberRoleAsync(SetGroupMemberRoleCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> SendMessageAsync(SendMessageCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> RevokeMessageAsync(RevokeMessageCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<int>> GetUnreadMessageCountAsync(GetUnreadMessageCountRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetUnreadMessagesFromGroupAsync(GetUnreadMessagesFromGroupRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetAllToUserFromGroupAsync(GetAllMessagesFromGroupRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<PagedResult<MessageDto>>> GetMessagesOfGroupAsync(GetMessagesOfGroupRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetMessagesOfGroupBeforeAsync(GetMessagesOfGroupBeforeRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse<UserDto>> GetUserProfileAsync(GetUserRequest request, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> UpdateMyProfileAsync(UpdateUserCommand command, CancellationToken cancellationToken = default);


        Task<SugarChatResponse> CreateUserAsync(AddUserCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> SetMessageReadSetByUserBasedOnGroupIdAsync(SetMessageReadByUserBasedOnGroupIdCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<IEnumerable<string>>> GetUserIdsByGroupIdsAsync(GetUserIdsByGroupIdsRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<PagedResult<ConversationDto>>> GetConversationByKeywordAsync(GetConversationByKeywordRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<IEnumerable<GroupDto>>> GetGroupByCustomPropertiesAsync(GetGroupByCustomPropertiesRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<IEnumerable<MessageDto>>> GetMessagesByGroupIdsAsync(GetMessagesByGroupIdsRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> BatchAddUsers(BatchAddUsersCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<MessageTranslateDto>> TranslateMessageAsync(TranslateMessageCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> SetMessageReadByUserIdsBasedOnGroupIdAsync(SetMessageReadByUserIdsBasedOnGroupIdCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> UpdateMessageDataAsync(UpdateMessageDataCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> UpdateGroupUserDataAsync(UpdateGroupUserDataCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse> RemoveUserFromGroupAsync(RemoveUserFromGroupCommand command, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<ServerConfigurationsDto>> GetServerConfigurationsAsync(GetServerConfigurationsRequest request, CancellationToken cancellationToken = default);

        Task<SugarChatResponse<bool>> CheckUserIsInGroupAsync(CheckUserIsInGroupCommand command, CancellationToken cancellationToken = default);
    }
}
