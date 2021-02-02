﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    class ServerSend
    {

        public static void Welcome(int toClient, string msg)
        {
            using(Packet p = new Packet((int)ServerPackets.welcome))
            {
                p.Write(msg);
                p.Write(toClient);
                SendTCPData(toClient, p);
            }
        }

        private static void SendTCPDataToAll(Packet p)
        {
            p.WriteLength();
            for (int i = 1; i < Server.MaxPlayers; i++)
            {
                Server.clients[i].tcp.SendData(p);
            }
        }

        private static void SendTCPDataToAllExcept(int id, Packet p)
        {
            p.WriteLength();
            for (int i = 1; i < Server.MaxPlayers; i++)
            {
                if (Server.clients[i].id != id)
                {
                    Server.clients[i].tcp.SendData(p);
                }
            }
        }

        private static void SendTCPData(int toClient, Packet p)
        {
            p.WriteLength();
            Server.clients[toClient].tcp.SendData(p);
        }
    }
}
