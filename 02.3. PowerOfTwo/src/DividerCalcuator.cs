using System;

namespace PowerOfTwo
{
    public class DividerCalcuator
    {
        public ulong FindDividerPower(ulong rBorder)
        {
            ulong totalPower = 0;
            ulong currentDivider = 2;
            
            for (int currentPower = 1; currentPower < 64; ++currentPower, currentDivider *= 2)
            {
                totalPower += rBorder / currentDivider;
            }

            return totalPower;
        }
    }
}