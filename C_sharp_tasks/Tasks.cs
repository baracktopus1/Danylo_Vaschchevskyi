using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace C_sharp_tasks
{
    [TestFixture]

    public class Tasks
    {
        [Test]
        public void test1()
        {
            List<object> inp = new List<object> { 1, 2, 'a', 'b' };
            Assert.AreEqual(GetIntegersFromList(inp), 
                new List<object>{ 1,2});
        }
        [Test]
        public void test2()
        {
            List<object> inp = new List<object> { 1, 2, 'a', 'b', 0, 15 };
            Assert.AreEqual(GetIntegersFromList(inp),
                new List<object> { 1, 2, 0, 15 });
        }
        [Test]
        public void test3()
        {
            List<object> inp = new List<object> { 1, 2, 'a', 'b', "aasf", '1', "123", 231 };
            Assert.AreEqual(GetIntegersFromList(inp),
                new List<object> { 1, 2, 231 });
        }
        public List<object> GetIntegersFromList(List<object> inp)
        {
            for(int i = 0;i<inp.Count;  i++)
            {
                if (!(inp[i] is int))
                {
                    inp.RemoveAt(i);
                    i--;
                }     
            }
            return inp;
        }
    }

    public class Task2
    {
        [Test]
        public void test1()
        {
            string inp = "stress";
            Assert.AreEqual(first_non_repeating_letter(inp),"t");
        }
        [Test]
        public void test2()
        {
            string inp = "sTreSS";
            Assert.AreEqual(first_non_repeating_letter(inp), "T");
        }
        [Test]
        public void test3()
        {
            string inp = "";
            Assert.AreEqual(first_non_repeating_letter(inp), "");
        }
        [Test]
        public void test4()
        {
            string inp = "Inn";
            Assert.AreEqual(first_non_repeating_letter(inp), "I");
        }
        [Test]
        public void test5()
        {
            string inp = "aAbB";
            Assert.AreEqual(first_non_repeating_letter(inp), "");
        }
        public string first_non_repeating_letter(string inp)
        {
            for(int i = 0;i<inp.Length;i++)
            {
                if((inp.ToUpper().Split(inp[i]).Length - 1 == 1) ||(inp.ToLower().Split(inp[i]).Length - 1 == 1))
                {
                    return inp[i].ToString();
                }
            }
            return "";
        }
    }
    public class Task3
    {
        [Test]
        public void Test1()
        {
            int inp = 16;
            Assert.AreEqual(digital_root(inp),7);
        }
        [Test]
        public void Test2()
        {
            int inp = 942;
            Assert.AreEqual(digital_root(inp), 6);
        }
        [Test]
        public void Test3()
        {
            int inp = 132189;
            Assert.AreEqual(digital_root(inp), 6);
        }
        [Test]
        public void Test4()
        {
            int inp = 493193;
            Assert.AreEqual(digital_root(inp), 2);
        }
        [Test]
        public void Test5()
        {
            int inp = 0;
            Assert.AreEqual(digital_root(inp), 0);
        }
        public int digital_root(int inp)
        {
            if(inp / 10 == 0)
            {
                return inp;
            }
            int sum = 0;
            while(inp>0)
            {
                sum += inp % 10;
                inp = inp / 10;
            }

            return digital_root(sum);
        }
    }
    
    public class Task4
    {
        [Test]
        public void Test1()
        {
            int[] inp = { 1, 1, 1, 1, 1, 1 };
            Assert.AreEqual(count_pair_target_sum(inp, 2), 15);
        }
        [Test]
        public void Test2()
        {
            int[] inp = { 1, 3, 6, 2, 2, 0, 4, 5 };
            Assert.AreEqual(count_pair_target_sum(inp, 5), 4);
        }
        public int count_pair_target_sum(int[] inp, int target)
        {
            int cnt = 0;
            for(int i=0;i<inp.Length-1;i++)
                for(int j = i+1;j<inp.Length;j++)
                    if (inp[i] + inp[j] == target)
                        cnt++;
            
            return cnt;
        }
    }

    public class Task5
    {
        [Test]
        public void Test1()
        {
            string inp = "Fred:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
            Assert.AreEqual(happy_list(inp), "(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)");
        }
        [Test]
        public void Test2()
        {
            string inp = "AAB:A;AAC:A;AAA:A;A:AA;A:AA";
            Assert.AreEqual(happy_list(inp), "(A, AAA)(A, AAB)(A, AAC)(AA, A)(AA, A)");
        }
        public string happy_list(string inp)
        {
            List<Tuple<string, string>> names = new List<Tuple<string, string>>();
            string[] full_names = inp.Split(';');
            foreach(string x in full_names)
            {
                names.Add(new Tuple<string, string>
                    (x.Split(':')[1].ToUpper(), x.Split(':')[0].ToUpper()));
            }
            names.Sort((x, y) =>
            {
                int result = x.Item1.CompareTo(y.Item1);
                return result == 0 ? x.Item2.CompareTo(y.Item2) : result;
            });
            string str = "";
            foreach(Tuple<string,string> x in names)
            {
                str += x.ToString();
            }
            return str;
        }
    }
}
