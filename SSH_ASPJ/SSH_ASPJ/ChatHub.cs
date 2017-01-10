using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Imagin2
{
    public class ChatHub : Hub
    {
        public Task JoinRoom(string roomCode)
        {
            return Groups.Add(Context.ConnectionId, roomCode);
        }

        public void Send(string roomCode, string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.Group(roomCode).broadcastMessage(name, message);
        }
    }
}