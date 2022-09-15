/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This file contains all of the the constants classes for the server side of
 * the networking part of the game, such as the port listening ranges.
 */

using System;

/*
 * The public IP may change depending on what connection is used (wired or
 * wireless) and will be wired for the final prject once port forwarding it set
 * up.
 * 
 * In order to make sure that clients can connect to the server even if the IP
 * address changes, there is an additional GitHub repository for fetching
 * files with data such as the Server IP addresses from online so they can be
 * changed easily for any device.
 * 
 * For now, the IP address is set to the localhost address (127.0.0.1) for
 * testing purposes.
 */
public class ServerConstants
{
    public static string PUBLIC_IP = "127.0.0.1";
}

/*
 * The current port ranges are being used for UDP. These values are temporary:
 * 25600 to 26000 (400 ports / 400 threads)
 * 
 * Since UDP ports don't use a connection, the theoretical max number of
 * connections is much more ambiguous.
*/
static class UDPConstants
{
    public static int STARTING_PORT = 25600;
    public static int PORT_RANGE = 400;
}

/*
 * The current port ranges are being used for TCP. These values are temporary:
 * 25600 to 25700 (100 ports / 100 threads)
 * 
 * Each TCP port can theoretically handle a large number of connections (65535),
 * so the number of ports used is minimized to save performance because it
 * reduces the number of threads.
*/
static class TCPConstants
{
    public static int STARTING_PORT = 25600;
    public static int PORT_RANGE = 100;
    public static int MAX_PORT_CONNECTIONS = 16000;
}

/*
 * A client attempting to login must send all of its information to the server
 * within 10 seconds (10000 ms) or else it will be automatically disconnected.
 * This is an easy measure to prevent random computers from trying to overwhelm
 * the server by flooding it with connections.
 * 
 * The max number of failed login attempts before temporary barring a computer
 * from authenticating itself is 5. This is a basic account security measure,
 * as it prevents the brute forcing of passwords.
 */
static class AuthenticationConstants
{
    public static int INITIAL_AUTHENTICATION_TIMEOUT = 10000;
    public static int MAX_LOGIN_ATTEMPTS = 5;
}