using System;
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
        protected IWebDriver driver;
        protected ApplicationManager app;
      


        [SetUp]
        public void SetupTest()
        {
            app = ApplicationManager.GetInstance();
               
        }
    }

}

