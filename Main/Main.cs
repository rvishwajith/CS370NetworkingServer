﻿/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the main class for the server side of the game. It starts the main
 * processes for the server, such as creating accounts and starting the
 * different servers.
 */

using System;

public class Main
{
    /* Setup method called immediately upon the program running. Calls methods
     * to recreate saved account data before any server processes are started.
     */
    public void Setup()
    {
        SetupAccounts();
        Managers.Accounts.LogAllAccounts();
    }

    /* Called after Setup() to enable all server processes once user accounts
     * have been set up. The servers enabled are:
     * - AuthenticationServer (TCP)
     * - InGameEventServer (UDP & TCP)
     * - PartyAndTextChatServer (TCP)
     * - VoiceChatServer (TCP)
     */
    public void Run()
    {
        // Servers.Primary.Run();
        Servers.Authentication.Run();
    }

    /* Load in saved account data that is currently stored in unencrypted plain
     * text files at a fixed directory. The files used are:
     * 1. User ID to Password File - Reads in UIDs to create account objects.
     * 2. User ID to Email File - Adds emails to account objects.
     * 3. User ID to Username File - Adds usernames to account objects.
     */
    public void SetupAccounts()
    {
        var dataRoot = "/Users/rohithvishwajith/Documents/School/UT/CS 370F/" +
            "UserData/";

        var IDtoPassword = FileReader.GetFileData(dataRoot + "IDtoPassword.txt");
        CreateAccounts(IDtoPassword);

        var IDtoEmail = FileReader.GetFileData(dataRoot + "IDtoEmail.txt");
        AddEmails(IDtoEmail);

        var IDtoUsername = FileReader.GetFileData(dataRoot + "IDtoUsername.txt");
        AddUsernames(IDtoUsername);

        var IDtoEmail2FA = FileReader.GetFileData(dataRoot + "IDto2FA.txt");
        AddEmail2FAStatus(IDtoEmail2FA);
    }

    public void CreateAccounts(string[] IDtoPasswordData)
    {
        foreach (string line in IDtoPasswordData)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var password = line.Substring(seperatorIndex + 1);

            Managers.Accounts.Add(new Account(ID, password));
        }
    }

    public void AddEmails(string[] IDtoEmail)
    {
        foreach (string line in IDtoEmail)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var email = line.Substring(seperatorIndex + 1);

            Managers.Accounts.SetEmail(Managers.Accounts.FindWithID(ID), email);
        }
    }

    public void AddUsernames(string[] IDtoUsername)
    {
        foreach (string line in IDtoUsername)
        {
            var seperatorIndex = line.IndexOf('|');
            var ID = long.Parse(line.Substring(0, seperatorIndex));
            var username = line.Substring(seperatorIndex + 1);

            Managers.Accounts.SetUsername(Managers.Accounts.FindWithID(ID), username);
        }
    }

    public void AddEmail2FAStatus(string[] IDtoEmail2FA)
    {
        foreach (string line in IDtoEmail2FA)
        {
            var ID = long.Parse(line);
            Managers.Accounts.FindWithID(ID).email2FA = true;
        }
    }
}