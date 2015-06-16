using System;

namespace FractCalculator
{
    public class FractionCalculator
    {
        static void Main()
        {
            try
            {
                Fraction fraction1 = new Fraction(22, 7);
                Fraction fraction2 = new Fraction(40, 4);

                Fraction result = fraction1 + fraction2;

                Console.WriteLine(result.Numerator);
                Console.WriteLine(result.Denominator);
                Console.WriteLine(result);
            }

            catch (ArgumentOutOfRangeException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            catch (DivideByZeroException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine();
                Console.WriteLine("Thnak you to use my program. Have a nice day!");
                Console.WriteLine();
            }
        }
    }
}
