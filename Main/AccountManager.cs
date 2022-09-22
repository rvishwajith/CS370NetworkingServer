/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the account manager class for the server side of the game. It stores
 * all of the accounts, and has the methods to query or edit account data:
 * 
 * Query Accounts:
 * 1. Lookup account by user ID - for all internal server operations.
 * 2. Lookup account by unique username - for external requests (ex. username
 *    login and checking for duplicate users).
 * 3. Lookup account by email - for external requests (ex. email login).
 * 
 * Editing Accounts:
 * 1. Add / remove accounts themselves.
 * 2. Edit an account's username or password.
 * 3. Add or remove the following:
 *    - Friends
 *    - Authenticated Devices
 *    - Reports
 */

using System;

public class AccountManager
{
    Dictionary<long, Account> IDToAccount;
    Dictionary<string, long> usernameToID;
    Dictionary<string, long> emailToID;

    public AccountManager()
    {
        IDToAccount = new();
        usernameToID = new();
        emailToID = new();
    }

    public void AddAccount(Account account)
    {
        IDToAccount.Add(account.userID, account);
        usernameToID.Add(account.username, account.userID);
        emailToID.Add(account.email, account.userID);
    }

    public Account GetAccountWithID(long ID)
    {
        try
        {
            return IDToAccount[ID];
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("ERROR: Can't find account with ID " + ID);
        }
        return null!;
    }

    public Account GetAccountWithUsername(string username)
    {
        try
        {
            return IDToAccount[usernameToID[username]];
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("ERROR: Can't find account with username " + username);
        }
        return null!;
    }

    public Account GetAccountWithEmail(string email)
    {
        try
        {
            return IDToAccount[usernameToID[email]];
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("ERROR: Can't find account with the email " + email);
        }
        return null!;
    }
}

