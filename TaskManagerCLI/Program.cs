using System;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    internal static class Program
    {
        public const string ExitCommand = "exit";
        public static void Main(string[] args)
        {
            Console.WriteLine("greeting");
            
            var executor = new CommandExecutor();
            string userInput;
            do
            {
                //Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("> ");
                userInput = Console.ReadLine()?.Trim();
                Console.WriteLine(executor.Execute(userInput));
                // Save changes after each command.
                TaskManagerAPI.TaskManager.GetInstance().CommitChanges();
            } while (userInput != ExitCommand);


        }
    }
}