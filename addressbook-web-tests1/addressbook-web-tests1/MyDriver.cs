using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAddressbookTest
{
    public static class MyDriver
    {
        public static IWebDriver Driver {get; set;}
        static MyDriver()
        {
            Driver = new FirefoxDriver();
        }
        
    }
}
