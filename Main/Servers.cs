/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This is the servers class for the server side of the game. It contains
 * static references to easily access all of the game's servers, listed below:
 * 
 * - Authentication Server (TCP)
 * - In-Game Events Server (TCP & UDP)
 * - Live Voice Chat Server (TCP)
 * - Live Text Chat Server (TCP)
 * - Party Management Server (TCP)
 * - Cosmetics Store Server (TCP)
 */

using System;

public static class Servers
{
    public static Server Primary = new();
    public static Server AuthServer = new();
}

