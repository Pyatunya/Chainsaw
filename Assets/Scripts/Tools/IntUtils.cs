using System;

namespace Tools
{
    public static class IntUtils
    {
        public static int GetNumberOfWholeDivisions(this int number, int divider)
        {
            var count = 0;

            if (number <= 0) 
                throw new ArgumentOutOfRangeException(nameof(number));
            
            if (divider <= 0) 
                throw new ArgumentOutOfRangeException(nameof(divider));
            
            if (number < divider)
                return 0;

            while (number % divider == 0)
            {
                count++;
                number -= divider;

                if(number == 0)
                    break;
            }

            return count;
        }
    }
}