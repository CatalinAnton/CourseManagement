using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ChatAPI.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string firstName, string lastName, string userId, 
            string courseId, string courseTitle, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", firstName, lastName, message, courseTitle);
        }
    }
}