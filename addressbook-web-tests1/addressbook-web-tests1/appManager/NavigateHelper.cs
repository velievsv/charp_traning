using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class NavigateHelper : HelperBase
    {
        private string baseUrl;

        public NavigateHelper(ApplicationManager manager, string baseUrl) 
                                                : base(manager)
        {
            this.baseUrl = baseUrl;
        }
        public void GoToGroupePage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }
        public void BackToHomePage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GotoAddNewContactPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
