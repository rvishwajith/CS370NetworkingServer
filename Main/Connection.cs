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
using System.Text;

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

    /* Read any data from a conencted client and write it to a byte array for
     * processing. */
    public void HandleConnectedClient()
    {
        Console.WriteLine("Authentication - Client connected.");

        // Write data from the client's stream to a byte array.
        var maximumClientDataSize = 256;
        var data = new byte[maximumClientDataSize];

        var dataLength = stream.Read(data, 0, data.Length);
        while (dataLength != 0)
        {
            // Console.WriteLine("Connection recieved " + dataLength + " bytes " + "of data.");

            // Decode data
            var recievedEvent = Encoding.UTF8.GetString(data);
            Process(recievedEvent);

            dataLength = 0;
        }
    }

    public void Process(string data)
    {

        string[] dataParts = data.Trim().Split(" ");
        if (dataParts[0] == "UPWD" && dataParts.Length == 3)
        {
            var username = dataParts[1];
            var password = dataParts[2];
            Console.WriteLine("Validating username/password " + username + " "
                + password);

        }
    }

    public void Validate(string username, string password)
    {

    }
}

