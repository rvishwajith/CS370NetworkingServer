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
using System.Net;
using System.Net.Sockets;

public class Server
{
    public Server()
    {
        Console.WriteLine("Creating server.");
    }

    public void Start()
    {
        Console.WriteLine("Starting server.");

        // For each port, create a thread.
        for (int i = TCPConstants.STARTING_PORT; i < TCPConstants.PORT_RANGE; i++)
        {
            // For each thread, create a TCP listener.
        }

        // Creade UDP threads.
    }
}