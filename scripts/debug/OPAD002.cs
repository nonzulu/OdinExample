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
                        @"C:\\Users\\knzul\\OneDrive\\Documents\\Axe Projects\\Example\\scripts\\debug\\Data\\OPAD002.xml",
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
            axe.InitializeTestDataSource("OPAD002", "", (axe.IsDataDriven("") ? axe.DataFileRowCount : 0),(axe.IsDataDriven("") ? axe.DataFileCurrentRow : 0));
            if(!axe.AssertIterationInScope(true)) return;
            AxeHarness harness = new AxeHarness(new Settings(axe.GetRunCategoryOptions("AxeHarness")));
            Driver driver = null;
            try {
                driver = new Driver(axe, @"C:\Program Files (x86)\Odin Technology\Axe\Selenium","Example", "OPAD002");
                axe.jobId=driver.GetRemoteSessionId().ToString();
            }
            catch(Exception e)
            {
                   axe.TraceError("Cannot initialize Selenium "  + e.ToString());
                   Environment.Exit(1);
            } 
			try
			{
				axe.TestBegin("OPAD002" ,"Check user account details are correct (expected Fail)", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "MyTests", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/results/debug/results.xml","");
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
				axe.SubtestBegin("withUser1", "Enter valid login credentials for an existing user", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Login");
				axe.StepBegin("[]Login", @"set", @"");
				driver.SetWindow("title=Odin Portal - Login");
				axe.StepEnd();

				axe.StepBegin("UserID", @"set", @"j.smith@testing.com");
				driver.FindElement("name=TextBoxUserId").SendKeys("j.smith@testing.com");
				axe.StepEnd();

				axe.StepBegin("Password", @"set", @"abc123");
				driver.FindElement("name=TextBoxPassword").SendKeys("abc123");
				axe.StepEnd();

				axe.StepBegin("Login", @"set", @"");
				driver.FindElement("//input[@value='Login']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("selectAccountDetails", "Select Account Details from the main menu", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Home");
				axe.StepBegin("[]Home", @"set", @"");
				driver.SetWindow("title=Odin Portal");
				axe.StepEnd();

				axe.StepBegin("MenuAccountDetails", @"set", @"");
				driver.FindElement("//a[text()='Account Details']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("checkUser1", "Validate account details for user1 (expected Fail on DOB)", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "AccountDetails");
				axe.StepBegin("[]AccountDetails", @"set", @"");
				driver.SetWindow("title=Odin Portal - Account Details");
				axe.StepEnd();

				axe.StepBegin("Title", @"get", @"Mr");
				axe.Value = driver.FindCellElement("AccountDetails.0.1").Text;
				axe.StepEnd();

				axe.StepBegin("Title", @"val", @"Mr");
				axe.StepValidateEqual(@"Mr", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Name", @"get", @"John Smith");
				axe.Value = driver.FindCellElement("AccountDetails.1.1").Text;
				axe.StepEnd();

				axe.StepBegin("Name", @"val", @"John Smith");
				axe.StepValidateEqual(@"John Smith", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Gender", @"get", @"Male");
				axe.Value = driver.FindCellElement("AccountDetails.2.1").Text;
				axe.StepEnd();

				axe.StepBegin("Gender", @"val", @"Male");
				axe.StepValidateEqual(@"Male", axe.Value);
				axe.StepEnd();
				axe.StepBegin("DOB", @"get", @"04/01/1980");
				axe.Value = driver.FindCellElement("AccountDetails.3.1").Text;
				axe.StepEnd();

				axe.StepBegin("DOB", @"val", @"04/01/1980");
				axe.StepValidateEqual(@"04/01/1980", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Email", @"get", @"j.smith@testing.com");
				axe.Value = driver.FindCellElement("AccountDetails.4.1").Text;
				axe.StepEnd();

				axe.StepBegin("Email", @"val", @"j.smith@testing.com");
				axe.StepValidateEqual(@"j.smith@testing.com", axe.Value);
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
