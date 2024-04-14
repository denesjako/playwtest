using System.Text;

namespace PlaywrightTests;
    public class Tools
    {

        public Tools()
        {
        }

        public static string GenerateRandomNumberWithLength(int length)
        {
            Random random = new Random();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                output.Append(random.Next(0, 10));
            }
                         
            return output.ToString();
        }

        public static string GenerateRandomNumberUpToHundred()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 101);
            return randomNumber.ToString();
        }
    }
