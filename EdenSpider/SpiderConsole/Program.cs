using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderConsole
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("输出：");
            Console.ReadKey();
        }

        public static int Fo(int a)
        {
            if (a<1)
            {
                return 0;
            }
            else if (a == 1||a==2)
            {
                return 1;
            }
            else
            {
                return Fo(a - 1) + Fo(a - 2);
            }
        }
    }
}
