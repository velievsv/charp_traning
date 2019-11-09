using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
   public class ApplicationManager
    {
        protected LoginHelper loginHelper;
        protected NavigateHelper navigator;
        protected GroupHelper groupHelper;
        protected IWebDriver driver;
        protected string baseURL;
        protected ContactHelper contactHelper;

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigator = new NavigateHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver);
        }

        public LoginHelper auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigateHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }
        public ContactHelper Contact
        {
            get
            {
                return contactHelper;
            }
        }
    }
    
}
