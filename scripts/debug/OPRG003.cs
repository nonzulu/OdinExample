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
                        @"C:\\Users\\knzul\\OneDrive\\Documents\\Axe Projects\\Example\\scripts\\debug\\Data\\OPRG003.xml",
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
            axe.InitializeTestDataSource("OPRG003", "", (axe.IsDataDriven("") ? axe.DataFileRowCount : 0),(axe.IsDataDriven("") ? axe.DataFileCurrentRow : 0));
            if(!axe.AssertIterationInScope(true)) return;
            AxeHarness harness = new AxeHarness(new Settings(axe.GetRunCategoryOptions("AxeHarness")));
            Driver driver = null;
            try {
                driver = new Driver(axe, @"C:\Program Files (x86)\Odin Technology\Axe\Selenium","Example", "OPRG003");
                axe.jobId=driver.GetRemoteSessionId().ToString();
            }
            catch(Exception e)
            {
                   axe.TraceError("Cannot initialize Selenium "  + e.ToString());
                   Environment.Exit(1);
            } 
			try
			{
				axe.TestBegin("OPRG003" ,"Verify registration of a new user - title of Miss", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "MyTests", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/results/debug/results.xml","");
				axe.BasestateBegin("Home");
				driver.WebDriver.Navigate().GoToUrl(axe.GetRunCategoryOption("website", "Home"));
				axe.BasestateEnd();

// 
// 
				axe.SubtestBegin("selectRegister", "Select Register from the main menu", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Home");
				axe.StepBegin("[]Home", @"set", @"");
				driver.SetWindow("title=Odin Portal");
				axe.StepEnd();

				axe.StepBegin("MenuRegister", @"set", @"");
				driver.FindElement("//a[text()='Register']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("usingNewUser3", "Register a new user with title of Miss", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Register");
				axe.StepBegin("[]Register", @"set", @"");
				driver.SetWindow("title=Odin Portal - Register");
				axe.StepEnd();

				axe.StepBegin("Title", @"set", @"Miss");
				driver.FindSelectElement("name=title").SelectByText("Miss");
				axe.StepEnd();

				axe.StepBegin("Name", @"set", @"Clare Black");
				driver.FindElement("name=TextBoxName").SendKeys("Clare Black");
				axe.StepEnd();

				axe.StepBegin("Female", @"set", @"");
				driver.FindElement("//input[@value='female']").Click();
				axe.StepEnd();

				axe.StepBegin("DOB", @"set", @"11/08/1985");
				driver.FindElement("name=DOB").SendKeys("11/08/1985");
				axe.StepEnd();

				axe.StepBegin("Email", @"set", @"c.black@testing.com");
				driver.FindElement("name=email").SendKeys("c.black@testing.com");
				axe.StepEnd();

				axe.StepBegin("Register", @"set", @"");
				driver.FindElement("//a[text()='Register']").Click();
				axe.StepEnd();

				axe.SubtestEnd();
// 
// 
				axe.SubtestBegin("pageDisplayed", "Check that registration has been successful", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "RegisterSuccess");
				axe.StepBegin("[]RegisterSuccess", @"set", @"");
				driver.SetWindow("title=Odin Portal - Register Success");
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
