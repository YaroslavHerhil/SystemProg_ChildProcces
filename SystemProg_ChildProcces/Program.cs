using System.Diagnostics;
using System.IO;

namespace SystemProg_ChildProcces
{
    public class Calc
    {
        public char Operation {  get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public Calc() 
        {
            Number1 = 0;
            Number2 = 0;
            Operation = '+';
        }

        public Calc(string[] arguments)
        {
                int temp = default;

                int.TryParse(arguments[0], out temp);
                Number1 = temp;

                int.TryParse(arguments[1], out temp);
                Number2 = temp;

                Operation = arguments[2][0];
            

        }

        public int OperationResult()
        {
            int result = default;
            switch (Operation) 
            {
                case '+':
                    result = Number1 + Number2;
                    break;
                case '-':
                    result = Number1 - Number2;
                    break; ;
                case '*':
                    result = Number1 * Number2;
                    break;
                case '/':
                    result = Number1 / Number2;
                    break;

                default: break;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{Number1} {Operation} {Number2}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************NEW PROCESS**********************");
            if (args.Length == 3)
            {
                Calc calc = new Calc(args);

                int result = calc.OperationResult();

                Console.WriteLine($"{calc} = {result}");
            }
            else if (args.Length == 2) 
            {
                int wordCounter = 0;
                string filePath = args[0];
                string word = args[1];
                string[] files = Directory.GetFiles(filePath);

                foreach( string file in files ) 
                {
                    if (file.Contains(word)) wordCounter++; 
                }

                Console.WriteLine($"Found '{word}' {wordCounter} times in {filePath}");
            }
            else { Console.WriteLine("Press any key to continue"); }

            Console.ReadKey();
            Console.WriteLine("********************NEW PROCESS END********************");
        }
    }
}