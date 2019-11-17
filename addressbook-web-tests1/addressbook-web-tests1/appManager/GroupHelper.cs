using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTest
{
    public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager)
                                                : base(manager)
        {

        }

        public GroupHelper UpdateGroup(GroupData group)
        {
            manager.Navigator.GoToGroupePage();
            SelectGroupCheckbox();
            ClickEditOnGroupPage();
            FillGroupFieldUpdate(group);
            InitUpdateGroup();
            BackToTheGroupPage();
            return this;
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.Navigator.GoToGroupePage();
            InitNewGroupCreation();
            FillGroupField(group);
            SubmitGroupCreation();
            return this;
        }
        public GroupHelper DeleteGroups()
        {
            SelectGroupCheckbox();
            DeleteGroup();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupField(GroupData group)
        {
            
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
           
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
           
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }
        public GroupHelper FillGroupFieldUpdate(GroupData group)
        {
            type(By.Name("group_name"), group.Name);
            type(By.Name("group_header"), group.Header);
            type(By.Name("group_footer"), group.Footer);
            return this;

        }



        public GroupHelper InitUpdateGroup()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper SelectGroupCheckbox()
        {
            driver.FindElement(By.XPath($"(//input[@type='checkbox'])[1]")).Click();
            return this;
        }
        public GroupHelper DeleteGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
        public GroupHelper BackToTheGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper ClickEditOnGroupPage()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}   
