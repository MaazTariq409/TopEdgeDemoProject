using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TopEdgeDemoProject.Models;

namespace TopEdgeDemoProject.Services
{
    public class ScrapperService : IScrapperService
    {
        private readonly IConfiguration _configuration;
        public ScrapperService(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }

        public ScrapDataDto Scrapper(string url)
        {
            var data = new ScrapDataDto();

            try
            {
                var options = new ChromeOptions();
                options.AddArgument("--headless");
                using (var driver = new ChromeDriver(options))
                {
                    driver.Navigate().GoToUrl("https://www.linkedin.com/login?fromSignIn=true&trk=guest_homepage-basic_nav-header-signin");

                    var email = driver.FindElement(By.XPath("//*[@id=\"username\"]"));
                    email.SendKeys(_configuration["credentials:linkedin:email"]);
                    var password = driver.FindElement(By.XPath("//*[@id=\"password\"]"));
                    password.SendKeys(_configuration["credentials:linkedin:password"]);

                    var submit = driver.FindElement(By.XPath("//*[@id=\"organic-div\"]/form/div[3]/button"));
                    submit.Click();

                    driver.Navigate().GoToUrl(url);

                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
                    var TitleNode = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"ember32\"]/h1")));
                    var imageNode = wait.Until(driver => driver.FindElement(By.XPath("//*[@id=\"ember30\"]")));

                    var Title = TitleNode.Text;
                    var imageUrl = imageNode.GetAttribute("src");
                    data.ImageUrl = imageUrl;
                    data.Name = Title;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while scraping data: {ex.Message}");
            }

            return data;
        }
    }
}
