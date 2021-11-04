using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Size of int: {0}", sizeof(int));
            Console.WriteLine("Size of long: {0}", sizeof(long));
            Console.WriteLine("Size of bool: {0}", sizeof(bool));
            Console.ReadLine();
        }
    }
}
