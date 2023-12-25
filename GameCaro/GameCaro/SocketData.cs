using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameCaro
{
    [Serializable]
    public class SocketData
    {
        private int command;
        private Point point;
        private string message;

        public int Command { get => command; set => command = value; }
        public Point Point { get => point; set => point = value; }
        public string Message { get => message; set => message = value; }

        

        public SocketData(int command,string message, Point point)
        {
            Command = command;
            Point = point;
            Message = message;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT,
        NOTITY,
        NEW_GAME,
        UNDO,
        QUIT
    }
}
