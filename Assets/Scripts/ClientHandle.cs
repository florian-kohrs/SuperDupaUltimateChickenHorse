﻿using Server;
using ServerData;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{

    public static void Welcome(Packet p)
    {
        string msg = p.ReadString();
        int id = p.ReadInt();

        Debug.Log(msg);
        Client.instance.myId = id;

        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet p)
    {
        PlayerData data = (PlayerData)p.ReadObject();

        GameManager.instance.SpawnPlayer(data);
    }

}
