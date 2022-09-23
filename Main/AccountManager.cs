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

    Dictionary<long, string> IDtoEmail2FA;

    public AccountManager()
    {
        IDToAccount = new();
        usernameToID = new();
        emailToID = new();
        IDtoEmail2FA = new();
    }

    public void Add(Account account)
    {
        try
        {
            IDToAccount.Add(account.userID, account);
        }
        catch (Exception)
        {
            Console.WriteLine("Already added account with ID: " + account.userID);
        }
    }

    public void SetEmail(Account account, string email)
    {
        account.email = email;
        emailToID.Add(account.email, account.userID);
    }

    public void SetUsername(Account account, string username)
    {
        account.username = username;
        usernameToID.Add(account.username, account.userID);
    }

    public void AddEmail2FACode(Account account, string code)
    {
        IDtoEmail2FA.Add(account.userID, code);
    }

    public bool ValidateEmail2FACode(Account account, string code)
    {
        try
        {
            var actualCode = IDtoEmail2FA[account.userID];
            Console.WriteLine("Checking code " + code);
            return code.Equals(actualCode);
        }
        catch
        {
            return false;
        }
    }

    public Account FindWithID(long ID)
    {
        try
        {
            return IDToAccount[ID];
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("ERROR: Can't find account with ID " + ID);
            return null!;
        }
    }

    public Account GetAccountWithUsername(string username)
    {
        try
        {
            return IDToAccount[usernameToID[username]];
        }
        catch (KeyNotFoundException)
        {
            return null!;
        }
    }

    public Account GetAccountWithEmail(string email)
    {
        try
        {
            return IDToAccount[emailToID[email]];
        }
        catch (KeyNotFoundException)
        {
            return null!;
        }
    }

    public void LogAllAccounts()
    {
        foreach (Account account in IDToAccount.Values)
        {
            Console.WriteLine(account + "\n");
        }
    }
}

