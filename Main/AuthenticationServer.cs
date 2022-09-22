/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the Authentication server. It manages incoming and outgoing events
 * for user authentication, account data retrieval, and account registration.
 * It also identifies devices that may have previously been authenticated with
 * an account or have been banned (implementing bans is not currently planned).
 * It is currently set to use 1 port and 1 thread, for a theoretical max of
 * 65535 simultaneous connections, which will liekly change.
 */

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Collections.Generic;

public class AuthenticationServer
{
    public int startingPort;
    public int portRange;

    public AuthenticationServer()
    {
        startingPort = 33000;
        portRange = 500;
    }

    /* 1. Await connections
     * 2. Validate the credentials.
     * 3. Validate 2-Factor Authentication
     * 4. Generate a Random Hardware ID for the client.
     */
    public void Run()
    {
        Thread connectionsThread = new Thread(() =>
        {
            AwaitConnections();
        });
        //connectionsThread.IsBackground = true;
        connectionsThread.Start();
    }

    /* Listen on TCP ports for any device connections. On connection, identify
     * the device and save its IP address. If the device does not send its
     * credentials within 5 seconds, forcefully disconnect it.
     */
    public void AwaitConnections()
    {
        int port = 23761;
        try
        {
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            Console.WriteLine("Authentication - Listening @ " + port);

            while (true)
            {
                var connection = new Connection(listener.AcceptTcpClient());
                connection.HandleConnectedClient();

                connection.client.Close();
            }
        }
        catch (Exception)
        {
            Console.WriteLine("AwaitConnections - Failed to listen on " + port);
        }
    }

    /* If the credentials are correct, check if the account has 2FA enabled. If
     * not, skip to step 4.
     */
    public bool ValidateCredentials(string[] credentials)
    {
        return true;
    }

    public bool Is2FAEnabled(long userID)
    {
        return false;
    }

    /* Generate a 7-digit random number ID and send an email to the user's saved
     * address with it. If the client does not send a valid ID within 15 minutes
     * or 5 tries, send an error message and forcefully disconnect it. If the
     * client is a remembered device, it can also send a previously generated
     * device ID which can be validated the same way as the credentials.
     */
    public void Handle2FA(long userID)
    {
        Console.WriteLine("Send a 2FA email or open the mobile app.");
    }

    /* Generate a random 16-digit alphanumerical ID and sends it to the client,
     * which can be used as a token to skip the login process next time if the
     * user opts to remember their account.
     */
    public string GenerateDeviceToken()
    {
        return "2562-sh72-dhwk-cak5";
    }
}