using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace парсер_с_ооп
{
    class Parse1
    {
        protected string s;
        private int index;
        public override string ToString()
        {
            return "s: {s}";
        }

        public virtual int Parser(string s)
        {
            this.s = s;
            index = 0;
            return Sub();
        }



        private int Sub()
        {
            int num = MulDiv();
            while (index < s.Length)
            {
                if (s[index] == '+')
                {
                    index++;
                    int b = MulDiv();
                    num += b;
                }
                else if (s[index] == '-')
                {
                    index++;
                    int b = MulDiv();
                    num -= b;
                }
                else
                {
                    Console.WriteLine("Error");
                    return 0;
                }
            }
            return num;
        }
        private int Num()
        {
            string buff = "0";
            for (; index < s.Length && char.IsDigit(s[index]); index++)
            {
                buff += s[index];
            }

            return int.Parse(buff);//01
        }



        private int MulDiv()
        {
            int numirbl = Fact();
            while (index < s.Length)
            {
                if (s[index] == '*')
                {
                    index++;
                    int q = Fact();
                    numirbl *= q;
                }
                else if (s[index] == '/')
                {
                    index++;
                    int q = Fact();
                    numirbl /= q;
                }
                else
                {
                    return numirbl;
                }
            }
            return numirbl;
        }

        private int Fact()
        {
            int numirbl = Num();
            while (index < s.Length)
            {
                if (s[index] == '!')
                {
                    index++;
                    numirbl = RaschFact(numirbl);
                }
                else
                {
                    return numirbl;
                }
            }
            return numirbl;
        }

        private int RaschFact(int numirbl)
        {
            int proizv = 1;
            while (numirbl > 0)
            {
                proizv *= numirbl;
                --numirbl;
            }


            return proizv;
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var dateNow = DateTime.Now;
                Console.WriteLine(dateNow);
                var s = Console.ReadLine();
                Parse1 prs1 = new Parse1();
                Console.WriteLine(prs1.Parser(s));
                var dateNow2 = DateTime.Now;
                Console.WriteLine(dateNow - dateNow2);

            }
        }
    }
    class Parse2 : Parse1
    {
        public override int Parser(string s)
        {
            var time12 = DateTime.Now;
            var r = base.Parser(s);
            Console.WriteLine((DateTime.Now - time12).TotalMilliseconds);
            return r;
        }

        public void PrintS()
        {
            Console.WriteLine("PrintS: {s}");
        }
    }

}

