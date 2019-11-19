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
        {   if (driver.Url == baseUrl + "/ addressbook / group.php"
                    && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToHomePage()
        {
            if (driver.Url == baseUrl)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseUrl);
        }
        public void BackToHomePage()
        {
            if (driver.Url == baseUrl)
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();

        }
        public void GotoAddNewContactPage()
        {   if (driver.Url == baseUrl + "/addressbook/edit.php"
                && IsElementPresent(By.Name("Enter")))
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
