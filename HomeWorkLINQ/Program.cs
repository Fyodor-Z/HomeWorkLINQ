using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWorkLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate array
            Random rndm = new Random();
            int[] givenArray = new int[rndm.Next(11, 21)];
            for (int i = 0; i < givenArray.Length; i++)
            {
                givenArray[i] = rndm.Next(51);
                var sign = rndm.Next(2);
                if (sign == 0) givenArray[i] *= -1;
            }
            Console.WriteLine($"Given array: {string.Join(", ", givenArray)}");
            
            //a. 3 biggest array elements
            var threeBiggest = givenArray.OrderByDescending(g => g).Take(3);
            Console.WriteLine($"3 biigest of given array: {string.Join(", ", threeBiggest)}");
            
            //b Exclude 2 smallest value, return new array
            var twoSmallest = givenArray.OrderBy(g => g).Take(2);
            var croppedArray = givenArray.Where(g => !twoSmallest.Contains(g)).ToArray();
            Console.WriteLine($"cropped array: {string.Join(", ", croppedArray)}");
            
            //c Array of sums even and odd elements of array
            int[] elementsSums = {givenArray.Where(g => g % 2 == 0).Sum(), givenArray.Where(g => Math.Abs(g % 2) == 1).Sum()};
            Console.WriteLine($"sum of even elements: {elementsSums[0]}; sum of odd elements: {elementsSums[1]}");
            
            //d average excluding min and max elements
            var average = givenArray.Where(g => g != givenArray.Min() && g != givenArray.Max()).Average();
            Console.WriteLine($"average excluding min and max elements: {average}");

            //e delete all vowels from the string
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var vowels = "AEIOUYaeiouy";
            //generate sting
            var stringChars = new char[rndm.Next(31)];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[rndm.Next(chars.Length)];
            }
            var givenString = new String(stringChars);
            Console.WriteLine($"Given string: {givenString}");
            //exclude vowels
            string finalString = new string (givenString.Where(g => !vowels.Contains(g)).ToArray());
            Console.WriteLine($"string without vowels: {finalString}");

            //f exponentiation list
            var outputList = givenArray.Select(g => (g % 2 == 0) ? (g = g * g) : (g = g * g * g)).ToList();
            Console.WriteLine($"exponential list: {string.Join(", ", outputList)}");
        }
    }
}
