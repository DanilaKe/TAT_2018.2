using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DEV_1
{
    internal class MaximumNumberOfUnequalCharacters
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length != 1)
                {
                    if (args.Length == 0)
                    {
                        throw new WrongNumberOfArguments("You have not used any arguments in the console line.");
                    }
                    else
                    {
                        throw new WrongNumberOfArguments($"You used {args.Length} arguments instead of 1 argument.");
                    }
                }

                int lengthUniqueSubsequence = args[0].GetLengthUniqueSubsequence();
                
                Console.WriteLine(lengthUniqueSubsequence);
            }
            catch (WrongNumberOfArguments e)
            {
                Console.WriteLine($"Error : {e.Message}");
            }
        }
    }
}    
/*
if (sequence[i - 1] != sequence[i])
{
counter++;
}
else
{
counter = 1;
}

if (counter > maxLength)
{
maxLength = counter;
}*/