using System;
using System.Collections.Generic;
using System.Numerics;

namespace FractCalculator
{
    public struct Fraction
    {
        private BigInteger numerator;
        private BigInteger denominator;

        public Fraction(BigInteger numerator, BigInteger denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public BigInteger Numerator
        {
            get { return this.numerator; }

            set
            {
                if (value < -9223372036854775808 || value > 9223372036854775807)
                {
                    throw new ArgumentOutOfRangeException("value", "Your numerator must be between" +
                                                                   "-9223372036854775808 and 9223372036854775807");
                }

                this.numerator = value;
            }
        }

        public BigInteger Denominator
        {
            get { return this.denominator; }

            set
            {
                if (value < -9223372036854775808 || value > 9223372036854775807)
                {
                    throw new ArgumentOutOfRangeException("value", "Your denominator must be between" +
                                                                   "-9223372036854775808 and 9223372036854775807");
                }

                else if (value == 0)
                {
                    throw new DivideByZeroException("Your denominator can not be 0! Division by 0 is not allowed");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction frack1, Fraction frack2)
        {
            BigInteger leastcommonmultiple = Leastcommonmultiple(frack1.Denominator, frack2.Denominator);
            BigInteger denominator = leastcommonmultiple;

            BigInteger temp1 = leastcommonmultiple / frack1.Denominator;
            BigInteger temp2 = leastcommonmultiple / frack2.Denominator;

            BigInteger numerator = (temp1 * frack1.Numerator) + (temp2 * frack2.Numerator);
            Fraction frack3 = new Fraction(numerator, denominator);

            return frack3;
        }

        public static Fraction operator -(Fraction frack1, Fraction frack2)
        {
            BigInteger leastcommonmultiple = Leastcommonmultiple(frack1.Denominator, frack2.Denominator);
            BigInteger denominator = leastcommonmultiple;

            BigInteger temp1 = leastcommonmultiple / frack1.Denominator;
            BigInteger temp2 = leastcommonmultiple / frack2.Denominator;

            BigInteger numerator = (temp1 * frack1.Numerator) - (temp2 * frack2.Numerator);
            Fraction frack3 = new Fraction(numerator, denominator);

            return frack3;
        }

        public override string ToString()
        {
            decimal result = (decimal) this.Numerator / (decimal) this.Denominator;
            return String.Format("{0}", result);
        }

        private static BigInteger Leastcommonmultiple(BigInteger denom1, BigInteger denom2)
        {
            if (denom1 == 0)
            {
                if (denom2 == 0)
                {
                    return 0;
                }

                else
                {
                    return denom2;
                }
            }

            else if (denom2 == 0)
            {
                if (denom1 == 0)
                {
                    return 0;
                }

                else
                {
                    return denom1;
                }
            }

            BigInteger greatscommondevisitor = GreatestCommonDivisor(denom1, denom2);
            BigInteger leastcommonmultiple = (denom1 * denom2) / greatscommondevisitor;
            return leastcommonmultiple;
        }

        private static BigInteger GreatestCommonDivisor(BigInteger denom1, BigInteger denom2)
        {
            BigInteger greatestCommonDivisor = 0;

            if (denom1 == 0 && denom2 == 0)
            {
                return 0;
            }

            else if (denom1 == 0 && denom2 != 0)
            {
                return denom2;
            }

            else if (denom1 != 0 && denom2 == 0)
            {
                return denom1;
            }

            else
            {
                BigInteger minValue = denom1;

                if (denom2 < minValue)
                {
                    minValue = denom2;
                }

                BigInteger maxDevider = minValue;
                List<BigInteger> multipliers = new List<BigInteger>();

                for (BigInteger i = 1; i <= maxDevider; i++)
                {
                    BigInteger temp1 = denom1 % i;
                    BigInteger temp2 = denom2 % i;

                    if (temp1 == 0 && temp2 == 0)
                    {
                        multipliers.Add(i);

                    }

                    else
                    {
                        continue;
                    }
                }

                BigInteger maxValue = -9223372036854775808;

                foreach (BigInteger value in multipliers)
                {
                    if (value > maxValue)
                    {
                        maxValue = value;
                    }
                }

                greatestCommonDivisor = maxValue;
            }

            return greatestCommonDivisor;
        }
    }
}