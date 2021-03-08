using System;

namespace PowerOfTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong lBorder;
            ulong rBorder;
            
            while (true)
            {
                Console.Write("Enter L border: ");
                lBorder = DataReader.ReadUlong();
            
                Console.Write("Enter R border: ");
                rBorder = DataReader.ReadUlong();

                if (lBorder <= rBorder)
                {
                    break;
                }
                
                Console.WriteLine("L mustn't be bigger than R");
            }

            DividerCalcuator dividerCalcuator = new DividerCalcuator();

            ulong lValue = dividerCalcuator.FindDividerPower(lBorder - 1);
            ulong rValue = dividerCalcuator.FindDividerPower(rBorder);
            
            Console.WriteLine("Max power of 2: " + (rValue - lValue));
        }
    }
}