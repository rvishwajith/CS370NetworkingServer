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
    public long userID = 0;
    public string password = "";
    public string email = "";
    public string username = "";

    public long[] friends = new long[0];
    public long[] matches = new long[0];
    public long[] reports = new long[0];

    public string[] devices = new string[0];

    public Account(long uid, string pwd)
    {
        userID = uid;
        password = pwd;
    }

    /* Prints out a formatted version of an account with all of its saved data.
     * Some of the data has not been implemented yet. This is an example:
     * 
     * username#tag {
     *     Unique ID: 38247493
     *     Email: example123@domain.com
     *     Password: xxxxxXXXX
     *     Friends: [ 172720138 2249 447493 ]
     *     Match History: [ 18303 1740287 ]
     *     Report History: [ 23 ]
     *     Authenticated Devices: [ ehwh-daui-dha2-155x 7fhd-27dh7-n3u8-woeq]
     * }
     */
    public override string ToString()
    {
        var count = 0;
        var wrapNumber = 10;

        string output = username + " {\n\t";
        output += "UID: " + userID + "\n\t";
        output += "Email: " + email + "\n\t";
        output += "Password: " + password + "\n\t";

        count = 0;
        output += "Friends (" + friends.Length + "): [ ";
        foreach (long friend in friends!)
        {
            output += friend + " ";
            count = count == wrapNumber ? 0 : count + 1;
            output = count == wrapNumber ? output : output + "\n\t";
        }
        output += " ]\n\t";

        count = 0;
        output += "Match History (" + matches.Length + "): [ ";
        foreach (long matches in matches!)
        {
            output += matches + " ";
            count = count == wrapNumber ? 0 : count + 1;
            output = count == wrapNumber ? output : output + "\n\t";
        }
        output += " ]\n\t";

        count = 0;
        output += "Report History (" + reports.Length + "): [ ";
        foreach (long report in reports!)
        {
            output += report + " ";
            count = count == wrapNumber ? 0 : count + 1;
            output = count == wrapNumber ? output : output + "\n\t";
        }
        output += " ]\n\t";

        count = 0;
        output += "Authenticated Devices (" + devices.Length + "): [ ";
        foreach (string device in devices!)
        {
            output += device + " ";
            count = count == wrapNumber ? 0 : count + 1;
            output = count == wrapNumber ? output : output + "\n\t";
        }
        output += " ]\n";

        return output + "}";
    }
}