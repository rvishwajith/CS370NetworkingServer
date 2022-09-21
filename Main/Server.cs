/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the main class for the server side of the game.
 * 
 * It accepts client connections, and automatically removed them if they
 * fail to authenticate themselves in a reasonable period of time. Currently
 * only local network devices can connect to the server because port forwarding
 * has not been setup for my personal computer.
 * 
 * Clients can be identiifed using Device Unique Identifiers or their
 * public IP address, however the public IP address is much less reliable
 * and can be duplicated easily.
 * 
 * Authentication is handled using TCP as it must be reliable. After a computer
 * is authenticated, the server will send a UDP port for the computer to send
 * packets to (depending on the game session, currently each game is planned to
 * use 2 ports). The client must then send all of its UDP information to that
 * port.
 * 
 * For every port that is being listened on, a unique thread is needed as all of
 * these processes must run simultaneously (each listener waiting for a packet
 * uses a blocking function, so threads are required for multiple simultaneous
 * functions).
 * 
 * Each TCP thread can theoretically handle up to 65535 connections, because
 * each port for TCP has 65535 connections as the theoretical maximum. This is
 * why so few TCP ports are used.
 */

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class Server
{
    /*
     * Called on Server's startup only. Creates all of the manager objects such
     * as the TCP / UDP managers and also begins the process for building user
     * data from files.
     */
    public void Start()
    {
        LoadAccountData();
        ManageTCPConnections();
        Console.WriteLine("Server started listening for TCP Connections.");
    }

    /*
     * Load in saved account data that is currently stored in unencrypted plain
     * text files at a fixed directory. The files used are:
     * 
     * 1. User ID to Password Data File - Used to read in user IDs and create
     * all account objects.
     * 2. User ID to Email Data File - Used to add emails to the account
     * objects.
     * 3. User
     */
    public void LoadAccountData()
    {
        var dataURL = "/Users/rohithvishwajith/Documents/School/UT/CS 370F/" +
            "UserData/";
        var IDtoPassword = FileReader.GetFileData(dataURL + "IDtoPassword.txt");
        var IDtoEmail = FileReader.GetFileData(dataURL + "IDtoEmail.txt");
        var IDtoUsername = FileReader.GetFileData(dataURL + "IDtoUsername.txt");

        CreateAccounts(IDtoPassword);
        AddEmailAddresses(IDtoEmail);
        AddUsernames(IDtoUsername);
    }

    public void CreateAccounts(string[] IDtoPasswordData)
    {
        foreach (string line in IDtoPasswordData)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var password = line.Substring(seperatorIndex + 1);

            Console.WriteLine("ID: " + ID + "\t\t\tPassword: " + password);
        }
        Console.WriteLine();
    }

    public void AddEmailAddresses(string[] IDtoEmail)
    {
        foreach (string line in IDtoEmail)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var email = line.Substring(seperatorIndex + 1);

            Console.WriteLine("ID: " + ID + "\t\t\tEmail: " + email);
        }
        Console.WriteLine();
    }

    public void AddUsernames(string[] IDtoUsername)
    {
        foreach (string line in IDtoUsername)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var username = line.Substring(seperatorIndex + 1);

            Console.WriteLine("ID: " + ID + "\t\t\tUsername: " + username);
        }
        Console.WriteLine();
    }

    /*
     * Create and manage the TCP connection threads. Later on, only create new
     * TCP threads if necessary, by creating a new thread only if the current
     * thread reaches a maximum number of occupants (from TCPConstants).
     */
    public void ManageTCPConnections()
    {
        int port = 25761;

        Thread thread = new Thread(() => { CreateTCPListener(port); });
        thread.IsBackground = true;
        thread.Start();

        /*
        while (port < TCPConstants.STARTING_PORT + TCPConstants.PORT_RANGE)
        {
            Thread thread = new Thread(() => { CreateTCPListener(port); });
            thread.IsBackground = true;
            thread.Start();
            port++;
        }*/
    }

    /*
     * Create and manage the single TCP connection. The threading is handled by
     * the ManageTCPConnections method already.
     */
    public void CreateTCPListener(int port)
    {
        TcpListener listener;
        listener = new TcpListener(IPAddress.Any, port);
        try
        {
            listener.Start();
            Console.WriteLine("Listening for TCP connections on port " + port);

            while (true)
            {
                var client = listener.AcceptTcpClient();
                Console.WriteLine("Accepted a TCP connection for authentication.");

                // Data stream to recieve data from the client, which is written to
                // a byte array.
                var maximumClientDataSize = 256;
                var clientData = new byte[maximumClientDataSize];
                var clientStream = client.GetStream();

                // Keep polling the stream to see if any data has been sent, if it
                // has, then read it to the array and process it.
                var clientDataLength = clientStream.Read(clientData, 0, clientData.Length);
                while (clientDataLength != 0)
                {
                    Console.WriteLine("TCP listener on port " + port +
                        " recieved packet of length: " + clientDataLength);
                    // Convert the packet to a string array.
                }
                // Start the automatic disconnection timer.
                client.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to listen at port " + port);
        }
    }

    /* Create and manage the UDP connection threads.
     */
    public void ManageUDPConnections()
    {
        int port = UDPConstants.STARTING_PORT;
        while (port < UDPConstants.STARTING_PORT + UDPConstants.PORT_RANGE)
        {

        }
    }
}