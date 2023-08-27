using BusinessLogic.POCO;
using Microsoft.AspNetCore.SignalR;
using NetHangfireDB.Entities;

namespace NetHangfireApp.Hub
{

    public interface IUsersHubHelper
    {
        void SendData(UserModel data);
    }
    public class UsersHubHelper : IUsersHubHelper
    {
        private readonly IHubContext<UsersHub> _hubContext;
        public UsersHubHelper(IHubContext<UsersHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        public void SendData(UserModel data)
        {
            _hubContext.Clients.All.SendAsync("NewUser", data);
        }
    }
}
