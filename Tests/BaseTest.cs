using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace OrumAutomation.Tests
{
	[TestFixture]
	[NonParallelizable] // RD: We need this to be run sequentially for the CI containers it runs on.
	public class BaseTest
	{
		protected IWebDriver Driver { get; private set; }
		private string userDataDir;

		[SetUp]
		public void Setup()
		{
			// Generate a unique user-data directory for this test instance.
			userDataDir = Path.Combine(Path.GetTempPath(), "chrome-profile-" + Guid.NewGuid().ToString());
			Directory.CreateDirectory(userDataDir);

			// RD: Best practice Arguments taking into account containers.
			var options = new ChromeOptions();
			options.AddArgument("--headless");
			options.AddArgument("--no-sandbox");
			options.AddArgument("--disable-dev-shm-usage");
			options.AddArgument("--disable-gpu");
			options.AddArgument("--no-first-run");
			options.AddArgument("--disable-extensions");
			options.AddArgument("--remote-debugging-port=0");
			options.AddArgument($"--user-data-dir={userDataDir}");
			options.AddArgument("--window-size=1920,1080");
			options.AddArgument("--ignore-certificate-errors");

			Driver = new ChromeDriver(options);

			// RD: Set a page load timeout to avoid infinite waiting.
			Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		}

		/// <summary>
		/// Tear down the Driver responsibily...
		/// </summary>
		[TearDown]
		public void TearDown()
		{
			if (Driver != null)
			{
				Driver.Quit();
				Driver.Dispose();
			}

			// RD: We need to make sure the userDataDir is removed if it exists on every tear down
			// This is to combat multiple tests sharing the same dir on ChromeDriver.
			if (Directory.Exists(userDataDir))
			{
				try
				{
					Directory.Delete(userDataDir, true);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error deleting user data directory: {ex.Message}");
				}
			}
		}
	}
}
