using System;

namespace konsolowe.Models
{
    public class Delegates
    {
        public delegate void Write(string message);

        public void Test()
        {
            Write writer = WriteMessage;
            writer("DOMINIK");
        }

        public static void WriteMessage(string message)
        { 
            Console.WriteLine($"Hello ! {message} ");
        }
    }
}