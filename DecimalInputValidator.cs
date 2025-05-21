namespace ConversorCalculator
{
    public class DecimalInputValidator : InputValidator
    {
        public override void validate(string input)
        {
            for(int i = 0; i< input.Length;i++)
            {
                if(!char.IsDigit(input[i]))
                {
                    throw new FormatException("Bad format");
                }
            }
        }
    }
}