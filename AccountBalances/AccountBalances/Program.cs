using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalances
{
    class Program
    {
        private static int S = 15000;
        private static int C = 3500;
        private static int M = 45000;

        static void Main(string[] args)
        {
            string answer = "";
            do
            {
                string accountName = "";
                Console.Clear();
                Console.WriteLine(showAccountBalances(S, C, M));
                Console.WriteLine("\nWhich balance has changed? [S/C/M]\n\t[S]avings\n\t[C]hecking\n\t[M]ortgage");
                accountName = Console.ReadLine();
                accountName = accountName.ToUpper();

                FieldInfo field = typeof(Program).GetField(accountName, BindingFlags.NonPublic | BindingFlags.Static);

                if (field != null)
                {
                    Console.WriteLine("\nThe current balance of " + field.Name + " is " + field.GetValue(null) + ".\nEnter new balance: ");
                    string newValue = Console.ReadLine();
                    int newInt;
                    if (int.TryParse(newValue, out newInt))
                    {
                        field.SetValue(null, newInt);
                        Console.WriteLine("\nThe new balance of " + field.Name + " is " + field.GetValue(null) + ".");
                    }
                    Console.WriteLine("\nDo you wish to change another balance? [Y/N]");
                    answer = Console.ReadLine();
                }
            } while (answer == "y" || answer == "Y");

            Console.WriteLine(showAccountBalances(S, C, M));
            Console.Read();
        }

        public static string showAccountBalances(int S, int C, int M)
        {
            return "\nYour account balances are:\n\tSavings  = " + S + "\n\tChecking = " + C + "\n\tMortgage = " + M;
        }
    }
}
