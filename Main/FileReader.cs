/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the file reader class for the server side of the game. It is used to
 * read local text files as well as files from the web (if necessary).
 * 
 * The most important files being read are local text files containing user
 * information such as the UserID and password. These files are currently
 * unencrypted for ease-of-use.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

static class FileReader
{
    /* Get the lines of text from a file at a given path as a string array. */
    public static string[] GetFileData(string location)
    {
        try
        {
            return File.ReadAllLines(location);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("No file found at " + location);
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to read lines of file " + location);
        }
        return new string[0];
    }
}