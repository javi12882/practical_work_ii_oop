using System;
using System.Collections.Generic;

namespace ConversorCalculator
{
    public class Converter
    {
        private List<Conversion> operations;

        public Converter()
        {
            this.operations = new List<Conversion>();

            this.operations.Add(new DecimalToBinary("Binary", "Decimal to Binary"));
            this.operations.Add(new DecimalToOctal("Octal", "Decimal to Octal"));
            this.operations.Add(new DecimalToHexadecimal("Hexadecimal", "Decimal to Hexadecimal"));
            this.operations.Add(new DecimalToTwoComplement("TwoComplement", "Decimal to Binary (TwoComplement)"));
            this.operations.Add(new BinaryToDecimal("Decimal", "Binary to Decimal"));
            this.operations.Add(new OctalToDecimal("Decimal", "octal to Decimal"));
            this.operations.Add(new HexadecimalToDecimal("Decimal", "hexadecimal to Decimal"));
            
        }

        public int Exit()
        {
            return this.operations.Count + 1;
        }

        public int GetNumberOperations()
        {
            return this.operations.Count;
        }

        public int PrintOperations()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------");

            for (int i = 1; i <= this.operations.Count; i++)
            {
                Console.WriteLine($"{i}. {this.operations[i - 1].GetDefinition()}");
            }

            Console.WriteLine($"{this.Exit()}. Exit");
            Console.WriteLine("--------------------------------------------------");

            string tmp = Console.ReadLine();

            if (tmp == "") return this.Exit();

            int option = int.Parse(tmp);

            return (option < 1 || option > this.GetNumberOperations()) ? this.Exit() : option;
        }

        public string PerformConversion(int op, string input)
        {
            this.operations[op-1].validate(input);
            
            if(this.operations[op-1].NeedBitSize())
            {

                return this.operations[op - 1].Change(input);
            }
            return this.operations[op - 1].Change(input);
        }

        public void PrintConversion(int op, string input, string output)
        {
            this.operations[op - 1].PrintConversion(input, output);
        }
    }
}
