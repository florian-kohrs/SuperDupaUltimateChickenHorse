﻿using Server;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend
{
    
    private static void SendTCPData(Packet p)
    {
        p.WriteLength();
        Client.instance.tcp.SendData(p);
    }

    public static void WelcomeReceived()
    {
        using(Packet p = new Packet((int)ClientPackets.welcomeReceived))
        {
            p.Write(Client.instance.myId);
            p.Write(UIManager.instance.usernameField.text);

            SendTCPData(p);
        }
    }

}