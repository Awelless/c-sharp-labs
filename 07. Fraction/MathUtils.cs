namespace Fraction
{
    public class MathUtils
    {
        public static long Gcd(long a, long b)
        {
            while (a > 0 && b > 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }
            return a + b;
        }

        public static long Lcm(long a, long b)
        {
            long gcd = MathUtils.Gcd(a, b);
            return a / gcd * b;
        }
    }
}