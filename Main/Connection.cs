/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the Connection class, which represents a connection from a device
 * via TCP. It handles sending and recieving the data over the network stream
 * with the client.
 * 
 * It will also store client authentication keys to re-identify previous clients
 * and their associated accounts. */

using System;
using System.Net;
using System.Net.Sockets;

public class Connection
{
    public TcpClient client;
    public NetworkStream stream;
    public string IP = "";

    public Connection(TcpClient tcpClient)
    {
        client = tcpClient;
        stream = client.GetStream();
        IP = ((IPEndPoint)client.Client.RemoteEndPoint!).ToString();

        Console.WriteLine("Created client with IP Address: " + IP);
    }
}

