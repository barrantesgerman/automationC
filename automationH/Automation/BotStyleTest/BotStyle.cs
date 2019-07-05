using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AutomationH.Automation.BotStyleTest
{
    class BotStyle
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
            set
            {
                this.driver = value;
            }
        }

        public BotStyle(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void SendKeys(IWebElement element, String text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public void Check(IWebElement element)
        {
            if(!element.Selected)
            {
                element.Click();
            }
        }
        
        public void UnCheck(IWebElement element)
        {
            if (element.Selected)
            {
                element.Click();
            }
        }

        public IWebElement FindByXPath(String xPath, params Object[] objects)
        {
            try
            {
                return this.Driver.FindElement(By.XPath(String.Format(xPath, objects)));
            } catch (Exception ex)
            {
                return null;
            }
            
        }

        public Boolean IsXPathDisplayed(String xPath, params Object[] objects)
        {
            IWebElement element = this.FindByXPath(xPath, objects);
            if(element != null)
            {
                return element.Displayed;
            } else
            {
                return false;
            }            
        }
    }
}
