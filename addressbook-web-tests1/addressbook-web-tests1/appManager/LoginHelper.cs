using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager)
                                            :base(manager)
        {

        }
      
       public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }
            type(By.Name("user"), account.Username);
            type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
               

        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.XPath("//form[@name='logout']")).FindElement(By.XPath("//b")).Text;
            return text.Substring(1, text.Length - 2);
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
               driver.FindElement(By.LinkText("Logout")).Click();
            }
            
        }
    }
}
