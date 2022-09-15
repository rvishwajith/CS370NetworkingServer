/*
 * Rohith Vishwajith (EID: rv24456)
 * 
 * Dr. Abraham
 * CS 370F | Undergraduate Reading & Research
 * 
 * The DataTranslator class is used for converting data back and forth between
 * strings, bytes, floats, etc. so that they can be used for:
 * 
 * Events: byte[] to String
 * Events are recieved as byte arrays, but are actually strings. For example,
 * an event for the player firing a weapon may be in the format:
 * PlayerID,Fire
 * 
 * Voice Data: byte[] to float[]
 * Unity uses a float[] for the AudioListener component as well as recording
 * microphone input. However, this will probably be done on the client side.
 */

class DataTranslator
{
    public DataTranslator()
    {

    }

    public static string ToString(byte[] data)
    {
        return "";
    }
}