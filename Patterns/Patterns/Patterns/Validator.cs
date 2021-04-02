using System;
using System.IO;

namespace Patterns
{
    class Validator
    {
        static void Main()
        {
            string[] arguments = Environment.GetCommandLineArgs();
            if (arguments.Length == 0)
            {
                Console.WriteLine("Args is null.\n");
                return;
            }

            int i = 1;
            while (i != arguments.Length)
            {
                GetResult(arguments[i++]);
            }
        }

        private static void GetResult(string args)
        {
            Value value = new Value();
            string text = File.ReadAllText(args);
            Console.WriteLine("Json is valid. {0}", value.Match(text).Success());
            Console.WriteLine("Remaining text is empty. {0}", value.Match(text).RemainingText().Length == 0);
        }
    }
}