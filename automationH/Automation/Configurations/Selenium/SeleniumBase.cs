using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationH.Automation.Configurations
{
    class SeleniumBase
    {

        private IWebDriver driver;
        public IWebDriver Driver {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public IWebDriver SetUpBase(String BrowserName, String Url)
        {
            switch (BrowserName)
            {
                case "Firefox":
                    InitFirefox();
                    break;
                case "Chrome":
                    InitChrome();
                    break;
                case "IE":
                    InitInternetExplorer();
                    break;
                default:
                    InitChrome();
                    break;
            }
            try
            {
                this.Driver.Manage().Window.Maximize();
            }
            catch
            {
                Console.Out.WriteLine("It was not possible to maximize the browser, but the test will continue!!");
            }
            this.Driver.Manage().Cookies.DeleteAllCookies();
            //this.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            this.Driver.Url = Url;
            return this.Driver;
        }

        public void TearDownBase()
        {
            this.Driver.Quit();
        }

        private void InitChrome()
        {
            this.Driver = new ChromeDriver();
        }

        private void InitFirefox()
        {
            this.Driver = new FirefoxDriver();
        }

        private void InitInternetExplorer()
        {
            this.Driver = new InternetExplorerDriver();
        }
    }
}
