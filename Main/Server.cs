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
    public Server()
    {
        Console.WriteLine("Creating server.");
    }

    /*
     * Start listening on the Server ports.
     */
    public void Start()
    {
        Console.WriteLine("Server beginning listening.");
        ManageTCPConnections();
    }

    /*
     * Create and manage the TCP connection threads. Later on, only create new
     * TCP threads if necessary, by creating a new thread only if the current
     * thread reaches a maximum number of occupants (from TCPConstants).
     */
    public void ManageTCPConnections()
    {
        int port = TCPConstants.STARTING_PORT;
        while (port < TCPConstants.STARTING_PORT + TCPConstants.PORT_RANGE)
        {
            Console.WriteLine("Creating TCP thread on port " + port);
            Thread thread = new Thread(() =>
            {
                CreateTCPListener(port);
            });
            thread.IsBackground = true;
            thread.Start();
        }
    }

    /*
     * Create and manage the single TCP connection. The threading is handled by
     * the ManageTCPConnections method already.
     */
    public void CreateTCPListener(int port)
    {
        TcpListener listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        while (true)
        {
            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("Accepted a TCP connection for authentication.");

            // Stream to recieve the data from the client and a byte array to
            // write the data to for processing.
            int maximumDataSize = 256;
            byte[] clientData = new byte[maximumDataSize];
            NetworkStream clientStream = client.GetStream();

            // Keep polling the stream to see if any data has been sent, if it
            // has, then read it to the array and process it.
            int clientDataLength = clientStream.Read(clientData, 0, clientData.Length);
            while (clientDataLength != 0)
            {

            }

            while (((i = stream.Read(bytes, 0, bytes.Length)) != 0)

            // Start the authentication timer here for automatic disconnection.


            client.Close();
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