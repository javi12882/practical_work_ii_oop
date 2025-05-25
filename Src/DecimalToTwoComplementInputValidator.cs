namespace ConversorCalculator
{
    public class DecimalToTwoComplementInputValidator: InputValidator
    {
        public override void validate(string input)
        {
            for(int i = 0; i< input.Length;i++)
            {
                if(input[i]=='-' && i>0)
                {
                    throw new FormatException("Bad format");
                }
                else if(!char.IsDigit(input[i])  && i>0)
                {
                    throw new FormatException("Bad format");
                }
            }
        }
    }
}