using System;
using System.Collections.Generic;

namespace WaniKani.Windows.Screensaver.Util
{
    public static class ListExtensions
    {
        private static Random Rand = new Random();

        //https://stackoverflow.com/questions/273313/randomize-a-listt
        public static void Shuffle<T>(this IList<T> list, Random rand = null)
        {
            //use supplied random instance
            if (rand != null) Rand = rand;

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Rand.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
