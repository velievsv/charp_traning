﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class TestBase
    {

        protected ApplicationManager app;
      


        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();


        }
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 223 + 32)));
            }
            return builder.ToString();
        }
    }

}

