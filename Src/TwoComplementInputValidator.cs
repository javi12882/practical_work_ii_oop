using System.ComponentModel.DataAnnotations;

namespace ConversorCalculator
{
    public class TwoComplementInputValidator: InputValidator
    {
        public override void validate(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c != '0' && c != '1')
                {
                    throw new FormatException("Bad format");
                }
            }
        } 
    }
}