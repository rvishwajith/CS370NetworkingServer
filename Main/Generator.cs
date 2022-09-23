/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * This class is used to generate random tokens for devices authenticating
 * themselves for a certain account.
 * 
 * The token format is:
 * XXXX-XXXX-XXXX-XXXX-XXXX (X is any alphanumeric character)
 * 
 * The number of possible combinations (chances of accidental collision or
 * guessing correct local password) is 62^20 or ~7.02 x 10^35.
 */

using System;

public static class Generator
{
    private static int EMAIL_2FA_DIGITS = 7;
    private static int SUSTAINED_TOKEN_SECTIONS = 5;
    private static int SUSTAINED_TOKEN_CHARS_PER_SECTION = 4;

    private static Random SEED = new Random();

    public static string GenerateEmail2FACode()
    {
        string code = "" + SEED.Next(1, 10);
        for (int i = 0; i < EMAIL_2FA_DIGITS - 1; i++)
        {
            code += RandomNumber() + "";
        }
        Console.WriteLine(code);
        return code;
    }

    public static string GenerateSustainedToken()
    {
        string token = "";
        for (int i = 0; i < SUSTAINED_TOKEN_SECTIONS; i++)
        {
            for (int j = 0; j < SUSTAINED_TOKEN_CHARS_PER_SECTION; j++)
            {
                token += RandomAlphanumeric();
            }
            token += "-";
        }
        return token;
    }

    private static int RandomNumber()
    {
        return SEED.Next(0, 10);
    }

    private static char RandomAlphanumeric()
    {
        int randNum = SEED.Next(0, 62); // 0 <= x <= 62
        if (randNum < 10) // Numbers
        {
            return (char)(randNum + 48);
        }
        else if (randNum < 36) // Uppercase Letters
        {
            return (char)(randNum + 64);
        }
        return (char)(randNum + 97); // Lowercase Letters
    }
}