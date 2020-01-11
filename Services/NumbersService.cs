using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace BluestoneApi.Services
{
    public class NumbersService: INumbersService
    {
        private const char commaSeparator = ',';
        private const string rowNumberRegexPattern = "^[\\d,]+$";
        private const string badRequestExceptionMessage = "Submit a list of numbers seperated by comma ! ";

        public List<int> ExtractNumbers(string numbers)
        {
            List<int> result = new List<int>();

            Regex rgx = new Regex(rowNumberRegexPattern);

            if (numbers.Trim().Length > 0)
            {
                numbers = numbers.Replace(" ", "");

                if (!rgx.IsMatch(numbers))
                {
                    throw new Exception(badRequestExceptionMessage);
                }

                result = numbers.Split(commaSeparator, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();

            }
            return result;
        }
        public List<int> SortNumbers(List<int> numbers)
        {
            numbers.Sort();
            return numbers;
        }

        public List<int> FilterNumbers(List<int> numbers)
        {
            List<int> filteredNumbers = new List<int>();

            foreach (var item in numbers)
            {
                if (!isPrime(item))
                {
                    filteredNumbers.Add(item);
                }

            }
            return filteredNumbers;
        }


        private bool isPrime(int n)
        {
            if (n < 2) return false;

            int sqrtValue = (int)Math.Sqrt(n);

            for (int i = 2; i <= sqrtValue; ++i)
            {
                if (n % i == 0) return false;
            }

            return true;
        }


    }
}
