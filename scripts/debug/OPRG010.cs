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
                        @"C:\\Users\\knzul\\OneDrive\\Documents\\Axe Projects\\Example\\scripts\\debug\\Data\\OPRG010.xml",
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
            axe.InitializeTestDataSource("OPRG010", "", (axe.IsDataDriven("") ? axe.DataFileRowCount : 0),(axe.IsDataDriven("") ? axe.DataFileCurrentRow : 0));
            if(!axe.AssertIterationInScope(true)) return;
            AxeHarness harness = new AxeHarness(new Settings(axe.GetRunCategoryOptions("AxeHarness")));
            Driver driver = null;
            try {
                driver = new Driver(axe, @"C:\Program Files (x86)\Odin Technology\Axe\Selenium","Example", "OPRG010");
                axe.jobId=driver.GetRemoteSessionId().ToString();
            }
            catch(Exception e)
            {
                   axe.TraceError("Cannot initialize Selenium "  + e.ToString());
                   Environment.Exit(1);
            } 
			try
			{
				axe.TestBegin("OPRG010" ,"Check default field values for new user registration", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "MyTests", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/results/debug/results.xml","");
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
				axe.SubtestBegin("checkDefault", "Check registration defaults", "C:/Users/knzul/OneDrive/Documents/Axe Projects/Example/data/ExampleTests.xlsx", "Register");
				axe.StepBegin("[]Register", @"set", @"");
				driver.SetWindow("title=Odin Portal - Register");
				axe.StepEnd();

				axe.StepBegin("Title", @"get", @"Mr");
				axe.Value = driver.FindSelectElement("name=title").AllSelectedOptions.Count > 0 ? driver.FindSelectElement("name=title").SelectedOption.Text : "";
				axe.StepEnd();

				axe.StepBegin("Title", @"val", @"Mr");
				axe.StepValidateEqual(@"Mr", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Name", @"get", @"");
				axe.Value =driver.FindElement("name=TextBoxName").GetAttribute("value");
				axe.StepEnd();

				axe.StepBegin("Name", @"val", @"");
				axe.StepValidateEqual(@"", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Male", @"get", @"0");
				axe.Value = Convert.ToInt32(driver.FindElement("//input[@value='male']").Selected).ToString();
				axe.StepEnd();

				axe.StepBegin("Male", @"val", @"0");
				axe.StepValidateEqual(@"0", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Female", @"get", @"0");
				axe.Value = Convert.ToInt32(driver.FindElement("//input[@value='female']").Selected).ToString();
				axe.StepEnd();

				axe.StepBegin("Female", @"val", @"0");
				axe.StepValidateEqual(@"0", axe.Value);
				axe.StepEnd();
				axe.StepBegin("DOB", @"get", @"");
				axe.Value =driver.FindElement("name=DOB").GetAttribute("value");
				axe.StepEnd();

				axe.StepBegin("DOB", @"val", @"");
				axe.StepValidateEqual(@"", axe.Value);
				axe.StepEnd();
				axe.StepBegin("Email", @"get", @"");
				axe.Value =driver.FindElement("name=email").GetAttribute("value");
				axe.StepEnd();

				axe.StepBegin("Email", @"val", @"");
				axe.StepValidateEqual(@"", axe.Value);
				axe.StepEnd();
				axe.StepBegin("MailingList", @"get", @"0");
				axe.Value = Convert.ToInt32(driver.FindElement("name=MailingList").Selected).ToString();
				axe.StepEnd();

				axe.StepBegin("MailingList", @"val", @"0");
				axe.StepValidateEqual(@"0", axe.Value);
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
