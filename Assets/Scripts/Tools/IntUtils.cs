using System;

namespace Tools
{
    public static class IntUtils
    {
        public static int GetNumberOfWholeDivisions(this int number, int divider)
        {
            var count = 0;

            if (number < divider)
                throw new ArgumentOutOfRangeException(nameof(divider));
            
            if (number <= 0) 
                throw new ArgumentOutOfRangeException(nameof(number));
            
            if (divider <= 0) 
                throw new ArgumentOutOfRangeException(nameof(divider));

            while (number % divider == 0)
            {
                count++;
            }

            return count;
        }
    }
}