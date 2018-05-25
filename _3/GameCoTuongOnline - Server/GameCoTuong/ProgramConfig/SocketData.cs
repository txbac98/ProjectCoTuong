﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoTuong.ProgramConfig
{
    [Serializable]
    public class SocketData
    {
        public int Command { get; set; }
        public string Message { get; set; }
        public Point DepartureLocation { get; set; }
        public Point DestinationLocation { get; set; }

        public SocketData() { }

        public SocketData(int command, string message)
        {
            this.Command = command;
            this.Message = message;
        }
        public SocketData(int command, string message, Point departureLocation, Point destinationLocation)
        {
            this.Command = command;
            this.Message = message;
            this.DepartureLocation = departureLocation;
            this.DestinationLocation = destinationLocation;
        }

        public enum SocketCommand
        {
            SEND_MOVE,
            NOTIFY,
            ASK_NEW_GAME,
            ACCEPT_NEW_GAME,
            ASK_UNDO,
            ACCEPT_UNDO,
            SURRENDER,
            EXIT
        }
    }
}