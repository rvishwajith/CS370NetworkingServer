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
using System.Security.Principal;
using System.Text;

public class Connection
{
    public TcpClient client;
    public NetworkStream stream;
    public string IP = "";

    public int maxTimeout = 500000;

    public Account validAccount = null!;

    public Connection(TcpClient tcpClient)
    {
        client = tcpClient;
        client.SendTimeout = maxTimeout;
        client.ReceiveTimeout = maxTimeout;
        stream = client.GetStream();
        IP = ((IPEndPoint)client.Client.RemoteEndPoint!).ToString();
        Console.WriteLine("Connected to client with IP Address: " + IP);
    }

    /* Read any data from a conencted client and write it to a byte array for
     * processing. */
    public void HandleClient()
    {
        while (true)
        {
            int bufferSize = 256;
            byte[] data = new byte[bufferSize];
            var dataLength = stream.Read(data, 0, data.Length);
            if (dataLength != 0)
            {
                Console.WriteLine("Recieved " + dataLength + " bytes.");

                var trimmedData = new byte[dataLength];
                Array.Copy(data, trimmedData, dataLength);

                var recievedEvent = Encoding.UTF8.GetString(trimmedData);
                Process(recievedEvent.Trim());
            }
        }
    }

    public void Process(string data)
    {
        string[] dataParts = data.Split(" ");
        if (dataParts[0] == "UPWD" && dataParts.Length == 3)
        {
            var username = dataParts[1];
            var password = dataParts[2];

            if (ValidateCredentials(username, password))
            {
                if (validAccount.email2FA)
                {
                    var code = Generator.GenerateEmail2FACode();
                    Console.WriteLine("Generated code is " + code);
                    Managers.Accounts.AddEmail2FACode(validAccount, code);
                    Send("Email2FACode");
                }
            }
        }
        else if (dataParts[0] == "Email2FACode")
        {
            var code = dataParts[1];
            var correctCode = Managers.Accounts.ValidateEmail2FACode(validAccount, code);
            Console.WriteLine("Correct 2FA Code: " + correctCode);
        }
    }

    public bool ValidateCredentials(string username, string password)
    {
        var account = Managers.Accounts.GetAccountWithUsername(username);
        if (account == null)
        {
            Send("Username does not exist.");
            return false!;
        }
        else if (!account.password.Equals(password))
        {
            Send("Password is incorrect.");
            return false!;
        }
        validAccount = account;
        return true;
    }

    public void Send(string message)
    {
        Console.WriteLine("Sending: " + message);
        var messageData = Encoding.UTF8.GetBytes(message);
        stream.Write(messageData, 0, messageData.Length);
    }
}

