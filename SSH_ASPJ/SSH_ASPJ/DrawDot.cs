using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Imagin2
{
    public class DrawDot : Hub
    {
        public Task Join(string roomCode)
        {
            return Groups.Add(Context.ConnectionId, roomCode);
        }

        public void UpdateCanvas(string roomCode, int x, int y, string ink, int size)
        {
            Clients.Group(roomCode).updateDot(x, y, ink, size);
        }
    }
}