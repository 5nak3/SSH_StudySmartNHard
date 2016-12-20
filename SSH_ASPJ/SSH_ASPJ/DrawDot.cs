using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace Imagin
{
    public class DrawDot : Hub
    {
        //public void UpdateCanvas(int x, int y, string ink, int size)
        //{
        //    Clients.All.updateDot(x, y, ink, size);
        //}

        public void UpdateCanvas(int x, int y)
        {
            Clients.All.updateDot(x, y);
        }
        public void ClearCanvas()
        {
            Clients.All.clearCanvas();
        }

    }
}