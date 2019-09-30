using System;
using System.Linq;

namespace Tests.PageAssist
{
    public class RandomString
    {
        private static Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string numbers = "0123456789";


        public static string StringSize(int length) => new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        public static string Numbers(int length) => new string(Enumerable.Repeat(numbers, length).Select(s => s[random.Next(s.Length)]).ToArray());
        public static string NumberValue(int max) => new Random().Next(1, max).ToString();

    }
}
