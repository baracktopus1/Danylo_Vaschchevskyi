﻿using NUnit.Framework;
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
        public int count_pair_target_sum(int[] inp)
        {

        }
    }
}
