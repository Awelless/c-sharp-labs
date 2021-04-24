using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Fraction
{
    public class Fraction : IComparable<Fraction>, IConvertible, IFormattable
    {
        private static Regex _standartFractionRegex = new Regex(@"^(-?\d+)/(\d+)$");
        private static Regex _mixedFractionRegex = new Regex(@"^(-?\d+)\((\d+)/(\d+)\)$");
        private static Regex _doubleRegex = new Regex(@"^(-?\d+)[,\.](\d+)$");

        public long Numerator { get; private set; }
        public long Denominator { get; private set; }
        private Fraction(long numerator, long denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public static Fraction Of(long numerator, long denominator)
        {
            Fraction fraction = new Fraction(numerator, denominator);
            fraction.Simplify();
            return fraction;
        }

        public static Fraction Parse(string s, FractionFormat format)
        {
            if (format == FractionFormat.Standart)
            {
                return ParseStandartFormat(s);
            }
            if (format == FractionFormat.Mixed)
            {
                return ParseMixedFormat(s);
            }
            if (format == FractionFormat.DoubleValue)
            {
                return ParseDouble(s);
            }
            if (format == FractionFormat.IntegerValue)
            {
                return ParseInteger(s);
            }

            throw new FormatException($"Unknown format: {format}");
        }

        public static Fraction ParseStandartFormat(string s)
        {
            Match match = _standartFractionRegex.Match(s);
            long numerator = long.Parse(match.Groups[1].Value);
            long denominator = long.Parse(match.Groups[2].Value);
            return Of(numerator, denominator);
        }

        public static Fraction ParseMixedFormat(string s)
        {
            Match match = _mixedFractionRegex.Match(s);
            long integer = long.Parse(match.Groups[1].Value);
            long numerator = Math.Abs(long.Parse(match.Groups[2].Value));
            long denominator = long.Parse(match.Groups[3].Value);
            return Of(integer * denominator + numerator, denominator);
        }

        public static Fraction ParseDouble(string s)
        {
            Match match = _doubleRegex.Match(s);
            long integer = long.Parse(match.Groups[1].Value);
            string decimalPart = match.Groups[2].Value;
            long denominator = (long)Math.Pow(10, decimalPart.Length);
            long numerator = Math.Abs(long.Parse(decimalPart));
            return Of(integer * denominator + numerator, denominator);
        }

        public static Fraction ParseInteger(string s)
        {
            long integer = long.Parse(s);
            return Of(integer, 1);
        }

        public int CompareTo(Fraction other)
        {
            long lcm = MathUtils.Lcm(Denominator, other.Denominator);
            long numerator = lcm / Denominator * Numerator;
            long otherNumerator = lcm / other.Denominator * other.Numerator;
            return numerator.CompareTo(otherNumerator);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            Fraction fraction = (Fraction) obj;

            return Numerator == fraction.Numerator && Denominator == fraction.Denominator;
        }

        public override int GetHashCode()
        {
            return (int) (Numerator * 31 + Denominator);
        }

        public override string ToString()
        {
            return ToString(FractionFormat.Standart);
        }
        
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "S")
            {
                return ToString(FractionFormat.Standart);
            }
            if (format == "M")
            {
                return ToString(FractionFormat.Mixed);
            }
            if (format == "D")
            {
                return ToString(FractionFormat.DoubleValue);
            }
            if (format == "I")
            {
                return ToString(FractionFormat.IntegerValue);
            }

            throw new FormatException($"Unknown format: {format}");
        }

        public string ToString(FractionFormat format)
        {
            if (Denominator == 1 && format == FractionFormat.Mixed)
            {
                format = FractionFormat.IntegerValue;
            }
            
            if (format == FractionFormat.Standart)
            {
                return $"{Numerator}/{Denominator}";
            }
            if (format == FractionFormat.Mixed)
            {
                long numerator = Math.Abs(Numerator % Denominator);
                long integer = Numerator / Denominator;
                return $"{integer}({numerator}/{Denominator})";
            }
            if (format == FractionFormat.IntegerValue)
            {
                return ToInt64(null).ToString();
            }
            if (format == FractionFormat.DoubleValue)
            {
                return ToDouble(null).ToString(CultureInfo.InvariantCulture);
            }

            throw new FormatException($"Unknown format: {format}");
        }
        private void Simplify()
        {
            long gcd = MathUtils.Gcd(Math.Abs(Numerator), Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }
        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(Numerator, provider);
        }
        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(ToDouble(provider), provider);
        }
        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(ToDouble(provider), provider);
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(ToDouble(provider), provider);
        }
        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(ToDouble(provider), provider);
        }
        public double ToDouble(IFormatProvider provider)
        {
            return ((double) Numerator) / Denominator;
        }
        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(ToDouble(provider), provider);
        }
        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(ToDouble(provider), provider);
        }
        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(ToDouble(provider), provider);
        }
        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(ToDouble(provider), provider);
        }
        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(ToDouble(provider), provider);
        }
        public string ToString(IFormatProvider provider)
        {
            return ToString();
        }
        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(ToDouble(provider), conversionType, provider);
        }
        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(ToDouble(provider), provider);
        }
        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(ToDouble(provider), provider);
        }
        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(ToDouble(provider), provider);
        }
        public static explicit operator byte(Fraction fraction)
        {
            return fraction.ToByte(null);
        }
        public static explicit operator short(Fraction fraction)
        {
            return fraction.ToInt16(null);
        }
        public static explicit operator int(Fraction fraction)
        {
            return fraction.ToInt32(null);
        }
        public static explicit operator long(Fraction fraction)
        {
            return fraction.ToInt64(null);
        }
        public static explicit operator float(Fraction fraction)
        {
            return fraction.ToSingle(null);
        }
        public static explicit operator double(Fraction fraction)
        {
            return fraction.ToDouble(null);
        }
        public static explicit operator decimal(Fraction fraction)
        {
            return fraction.ToDecimal(null);
        }
        
        public static Fraction operator +(Fraction fraction)
        {
            return fraction;
        }
        public static Fraction operator -(Fraction fraction)
        {
            return Of(-fraction.Numerator, fraction.Denominator);
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return Of(a.Numerator * b.Denominator + b.Numerator * a.Denominator, 
                a.Denominator * b.Denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return Of(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }
        public static Fraction operator *(Fraction a, long b)
        {
            return Of(a.Numerator * b, a.Denominator);
        }
        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return Of(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }
        public static Fraction operator /(Fraction a, long b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException();
            }
            return Of(a.Numerator, a.Denominator * b);
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }
    }
}