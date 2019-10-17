// 
// 
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using OdinTechnology.Axe.Runtime;
using OdinTechnology.Axe.Harness;
using OdinTechnology.Axe.TEX.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
            namespace OdinTechnology.Axe
{  
    class SeleniumTest
    {
        static bool executeTestEnd=true;
  
        [STAThread]
        static void Main(string[] args)
        {
            try {
                Test axe = new Test();
                axe.UseDefaultScreenshotHandling = false;
                axe.InitSuite(@"C:\Users\knzul\OneDrive\Documents\Axe Projects\Example\Example.tpj", "debug");    
                
                if (axe.IsDataDriven(""))
                {
                    axe.DataFileLoad(
                        @"C:\\Users\\knzul\\OneDrive\\Documents\\Axe Projects\\Example\\scripts\\debug\\Data\\OPRG100_02.xml",
                        "");
                    while (axe.DataFileGetNextRow() != -1)
                    {
                        Test(axe);
                    }        
                }
                else
                {
                    Test(axe);
                }
            }
            catch(Exception ex) { Console.WriteLine("ERROR: " + ex.Message); }
        }
        
        static void Test(Test axe)
        {
            axe.InitializeTestDataSource("OPRG100_02", "", (axe.IsDataDriven("") ? axe.DataFileRowCount : 0),(axe.IsDataDriven("") ? axe.DataFileCurrentRow : 0));
            if(!axe.AssertIterationInScope(true)) return;
            AxeHarness harness = new AxeHarness(new Settings(axe.GetRunCategoryOptions("AxeHarness")));
            Driver driver = null;
            try {
                driver = new Driver(axe, @"C:\Program Files (x86)\Odin Technology\Axe\Selenium","Example", "OPRG100_02");
                axe.jobId=driver.GetRemoteSessionId().ToString();
            }
            catch(Exception e)
            {
                   axe.TraceError("Cannot initialize Selenium "  + e.ToString());
                   Environment.Exit(1);
            } 
			try
			{
				axe.TestBegin("OPRG100_02" ,"Login as a newly registered user", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "MyTests", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/results/debug/results.xml","");
				axe.CheckDependency("OPRG100_01");

				axe.BasestateBegin("Restart.Home");
				driver.WebDriver.Navigate().GoToUrl(axe.GetRunCategoryOption("website", "Home"));
				axe.BasestateEnd();

// 
// 
				axe.SubtestBegin("selectLogin", "Select Login from the main menu", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Home");
				axe.StepBegin("[]Home", @"set", @"");
				driver.SetWindow("title=Odin Portal");
				axe.StepEnd();

				axe.StepBegin("MenuLogin", @"set", @"");
				driver.FindElement("//a[text()='Login']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("withUser100", "Enter valid login credentials for a new user", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Login");
				axe.StepBegin("[]Login", @"set", @"");
				driver.SetWindow("title=Odin Portal - Login");
				axe.StepEnd();

				axe.StepBegin("UserID", @"set", @"f.white@testing.com");
				driver.FindElement("name=TextBoxUserId").SendKeys("f.white@testing.com");
				axe.StepEnd();

				axe.StepBegin("Password", @"load", @"");
				axe.DataLoad("Password", "");
				axe.StepEnd();

				axe.StepBegin("Password", @"set", @"");
				driver.FindElement("name=TextBoxPassword").SendKeys(axe.Data);
				axe.StepEnd();

				axe.StepBegin("Login", @"set", @"");
				driver.FindElement("//input[@value='Login']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("pageDisplayed", "Check that the Home page is displayed", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Home");
				axe.StepBegin("[]Home", @"set", @"");
				driver.SetWindow("title=Odin Portal");
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
                        }
            catch (Exception ex)
            {
                axe.StepInfo(ex.Message);
                driver.TakeScreenshot(axe.FilenameForScreenshot());
                axe.TestAbort();               
                executeTestEnd = false;                        
            }
            finally
            {
               driver.Abort();
            }
            if (executeTestEnd)
            {
                axe.TestEnd();
            }
            else
            {
                executeTestEnd = true;
            }
        }
    }
}
