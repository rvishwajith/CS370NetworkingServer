/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * The account class is used to store all of the savable data of a single user.
 * 
 * This is a list of all of the data that can be stored in a user account:
 * 
 * Required Account Data:
 * - User ID (long) - Hidden from the user. Used as a unique identifier for an
 *   account for all server operations.
 * - Password (string) - Created by the user, used by client devices to retrieve
 *   user data from the server along with an identifier such as a username.
 * - Username (string) - Created by the user, used alongside the password as a 
 *   credential toaccess data as well as a unique in-game identifier.
 * - Email Addresses (string[]) - Chosen by the user as a credential for logging
 *   in and retrieving information. Multiple emails can be added to an account.
 * 
 * Optional Account Data:
 * - Authenticated Device IDs (string[]) - Hidden from the user. Stores the
 *   unique ID of any devices currently authenticated with a user, which in turn
 *   can be used to reference information about the device.
 * - Match History IDs (long[]) - Hidden from the user. Stores the unique ID of a
 *   completed match, which in turn can be used to lookup the match data.
 */

using System;
using System.Collections;
using System.Collections.Generic;

public class Account
{
    /* Required Account Data */
    public long? userID;
    public string? password;
    public string? username;
    public string[]? email;

    /* Optional Data */
    public string[]? authenticatedDeviceIDs;
    public long[]? matchHistoryIDs;

    public Account(long uid, string pwd)
    {
        userID = uid;
        password = pwd;
    }
}