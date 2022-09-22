/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the manager class for the server side of the game. It stores static
 * variables for manager objects to make them easily accessible, since each
 * manager will only ever have a single instance.
 */

using System;

public static class Managers
{
    public static AccountManager AccountManager = new AccountManager();

    // public static AuthenticationServer
    // public static InGameEventServer
    // public static InGameVoiceChatServer
    // public static InGameTextChatServer 

    public static Server? SERVER = null;
}

