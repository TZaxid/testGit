using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    class Program
    {
        private static List<string> chatLog = new List<string>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            string input;
            string[] parcedInput;
            string filepath;
            while (true)
            {
                input = Console.ReadLine();
                parcedInput = parceUserInput(input);
                switch (parcedInput[0])
                {
                    case "Hello":
                        string userName = Environment.UserName;
                        Console.WriteLine(myWrite("Привіт, " + userName));
                        break;
                    case "Goodbye":
                        Console.WriteLine(myWrite("Bye"));
                        System.Threading.Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    case "Time":
                        Console.Write(myWrite(DateTime.Now.ToString("hh:mm:ss") + '\n'));
                        break;
                    case "Date":
                        Console.Write(myWrite(DateTime.Now.ToString("dd:MM:yyyy") + '\n'));
                        break;
                    case "OS":
                        Console.WriteLine(myWrite(Environment.OSVersion.ToString()));
                        break;
                    case "Color":
                        if (parcedInput.Length > 1)
                        {
                            Console.ForegroundColor = changeConsoleColor(parcedInput[1]);
                            Console.WriteLine(myWrite("Console color was changed"));
                        }

                        else
                            Console.WriteLine(myWrite("Please, write color name"));
                        break;
                    case "Save":
                        if (parcedInput.Length > 1)
                        {
                            filepath = parcedInput[1];
                            writeLogToFile(filepath);
                        }
                        else
                            Console.WriteLine(myWrite("Please, write file path"));
                        break;
                }
            }
        }

        static string[] parceUserInput(string input)
        {
            string[] inputArray;
            inputArray = input.Split(' ');
            return inputArray;
        }

        static ConsoleColor changeConsoleColor(string color)
        {
            ConsoleColor consoleColor;
            switch (color)
            {
                case "red":
                    consoleColor = ConsoleColor.Red;
                    break;
                case "blue":
                    consoleColor = ConsoleColor.Blue;
                    break;
                case "green":
                    consoleColor = ConsoleColor.Green;
                    break;
                case "gray":
                    consoleColor = ConsoleColor.Gray;
                    break;
                default:
                    consoleColor = ConsoleColor.White;
                    break;
            }
            return consoleColor;
        }

        static string myWrite(string line)
        {
            chatLog.Add(line);
            return line;
        }

        static void writeLogToFile(string filePath)
        {
            try
            {
                System.IO.File.WriteAllLines(filePath, chatLog);
            }
            catch (System.IO.IOException exception)
            {
                Console.WriteLine(myWrite("Problem with writing log to file"));
            }
            catch (SystemException)
            {
                Console.WriteLine(myWrite("Internal error"));
            }
            return;
        } 
    }
}
