using System;

namespace lab_1
{
    class TruthTable
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose mode: 1. Automatic 2. Manual");
            int mode = int.Parse(Console.ReadLine());

            if (mode == 1)
            {
                // Automatic mode - predefined statements
                Console.WriteLine("Truth table for the formula: (x → (y ∨ z)) → (x → (y ∨ z))");
                Console.WriteLine(" x | y | z | (x → (y ∨ z)) → (x → (y ∨ z)) ");
                Console.WriteLine("---------------------------------------------");

                bool[] values = { true, false };
                foreach (bool x in values)
                {
                    foreach (bool y in values)
                    {
                        foreach (bool z in values)
                        {
                            bool implication1 = Implication(x, Or(y, z));
                            bool result = Implication(implication1, implication1);
                            Console.WriteLine($" {x,1} | {y,1} | {z,1} | {result,30}");
                        }
                    }
                }
            }
            else if (mode == 2)
            {
                Console.WriteLine("Enter the number of variables (2 or 3): ");
                int variables = int.Parse(Console.ReadLine());

                if (variables != 2 && variables != 3)
                {
                    Console.WriteLine("Invalid number of variables. Must be 2 or 3.");
                    return;
                }

                bool[] values = { true, false };

                Console.WriteLine("Choose the operation to combine variables:");
                Console.WriteLine("1. OR (∨)");
                Console.WriteLine("2. AND (∧)");
                Console.WriteLine("3. Implication (→)");

                int operation = int.Parse(Console.ReadLine());

                if (operation < 1 || operation > 3)
                {
                    Console.WriteLine("Invalid operation. Must be 1, 2, or 3.");
                    return;
                }

                Console.WriteLine("Truth table for the manual input:");
                if (variables == 2)
                {
                    Console.WriteLine(" x | y | Result ");
                    Console.WriteLine("-----------------");
                    foreach (bool x in values)
                    {
                        foreach (bool y in values)
                        {
                            bool result = ComputeResult(x, y, operation);
                            Console.WriteLine($" {x,1} | {y,1} | {result,6}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" x | y | z | Result ");
                    Console.WriteLine("--------------------");
                    foreach (bool x in values)
                    {
                        foreach (bool y in values)
                        {
                            foreach (bool z in values)
                            {
                                bool intermediate = ComputeResult(y, z, operation);
                                bool result = Implication(x, intermediate);
                                Console.WriteLine($" {x,1} | {y,1} | {z,1} | {result,6}");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid mode. Choose either 1 or 2.");
            }
        }

        static bool Implication(bool a, bool b)   // Logical implication (→)
        {
            return !a || b;
        }

        static bool Or(bool a, bool b)  // Logical OR (∨)
        {
            return a || b;
        }

        static bool And(bool a, bool b)   //Logical AND (∧)
        {
            return a && b;
        }

        static bool ComputeResult(bool a, bool b, int operation)
        {
            switch (operation)
            {
                case 1:
                    return Or(a, b);
                case 2:
                    return And(a, b);
                case 3:
                    return Implication(a, b);
                default:
                    throw new ArgumentException("Invalid operation.");
            }
        }
    }
}
