using System;
using System.IO;
using StormLibSharp;

namespace mpq_packer
{
    class Logger
    {
        /// <summary>
        /// Prints out the provided text in an Aqua Colour.
        /// </summary>
        /// <param name="message">The Message Itself</param>
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Write(message);
        }

        /// <summary>
        /// Prints out the provided text in a Red Colour.
        /// </summary>
        /// <param name="message">The Message Itself</param>
        public static void Danger(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Write(message);
        }

        /// <summary>
        /// Prints out the provided text in a Yellow Colour.
        /// </summary>
        /// <param name="message">The Message Itself</param>
        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Write(message);
        }
        

        /// <summary>
        /// Prints out the provided text in a Green Colour.
        /// </summary>
        /// <param name="message">The Message Itself</param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Write(message);
        }

        /// <summary>
        /// Actually write out the message and reset console.
        /// </summary>
        /// <param name="message"></param>
        private static void Write(string message)
        {
            Console.WriteLine(message.PadRight(Console.WindowWidth - 1));

            Console.ResetColor();
        }
    }
}