using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint,uint?> dict = new Dictionary<uint, uint?>();

            uint idCount = 0;
            bool added = false;

            for (uint i = 0; i < 10; i++)
            {
                dict.Add(i,i);
                idCount++;
            }

            dict[5] = null;
            idCount--;

            foreach (var entry in dict)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }

            for (uint i = 0; i < dict.Count; i++)
            {
                if (dict[i].Equals(null))
                {
                    dict[i] = i;
                    added = true;
                }
            }

            if (!added)
            {
                dict.Add(idCount,idCount);
            }

            foreach (var entry in dict)
            {
                Console.WriteLine(entry.Key + " : " + entry.Value);
            }
        }
    }
}
