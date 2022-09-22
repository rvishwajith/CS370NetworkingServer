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

public class AuthenticationServer
{
    public int startingPort;
    public int portRange;

    public AuthenticationServer()
    {
        startingPort = 33000;
        portRange = 500;
    }

    public void Run()
    {
        // Listen on TCP ports for all device connections.
        // On connection, identify the device if it sends its credentials within
        // X seconds and save its IP address.
        // If the credentials are correct, check if the account has 2FA enabled.
        // If not, generate a random ID for the client and send it to the
        // client.
        // If yes, then send the 2FA request to the client and generate/send
        // the 2FA code to the user, then wait for 2FA code (or expire in 15
        // minutes).
    }
}