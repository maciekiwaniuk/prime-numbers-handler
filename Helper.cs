using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_numbers_handler
{
    public static class Helper
    {
        /**
         * Check if passed number is prime number
         */ 
        public static bool isPrimeNumber(int number)
        {
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /**
         * Spread prime factors from given number
         */
        public static List<int> spreadPrimeFactors(int number)
        {
            List<int> list = new List<int>();

            if (number > 1)
            {
                if (Helper.isPrimeNumber(number))
                {
                    list.Add(0);
                }
                else
                {
                    for (int i = 2; i <= number; i++)
                    {
                        while (number % i == 0)
                        {
                            list.Add(i);
                            number = number / i;
                        }
                    }
                }
            }
            else
            {
                list.Add(0);
            }

            return list;
        }

        /**
         * Check if given range is correct
         */
        public static bool isCorrectRange(string range)
        {
            try
            {
                int rangeNumber = Convert.ToInt32(range);
                return true;
            }
            catch (Exception) { }
            

            try
            {
                string[] numbers = range.Split("-");

                int rangeFrom = Convert.ToInt32(numbers[0]);
                int rangeTo = Convert.ToInt32(numbers[1]);

                if (rangeFrom < 2)
                {
                    return false;
                }

                if (rangeTo > rangeFrom)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /**
         * Return list of range from-to from string
         */
        public static List<int> getRangeFromString(string range)
        {
            List<int> list = new List<int>();

            try
            {
                int rangeNumber = Convert.ToInt32(range);
                list.Add(2);
                list.Add(rangeNumber);
                return list;
            }
            catch (Exception) { }

            string[] numbers = range.Split("-");
            int rangeFrom = Convert.ToInt32(numbers[0]);
            int rangeTo = Convert.ToInt32(numbers[1]);

            list.Add(rangeFrom);
            list.Add(rangeTo);

            return list;
        }

        /**
         * Return list of prime numbers from passed range
         */
        public static List<int> getPrimeNumbersFromRange(string range)
        {
            List<int> listPrimeNumbers = new List<int>();
            List<int> listRange = Helper.getRangeFromString(range);

            for (int i = listRange[0]; i <= listRange[1]; i++)
            {
                if (Helper.isPrimeNumber(i))
                {
                    listPrimeNumbers.Add(i);
                }
            }

            return listPrimeNumbers;
        }

    }
}
