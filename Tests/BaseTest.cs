using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrumAutomation.Tests
{
	/// <summary>
	/// Let's create a base test for Orums new repo. This is super great because we can inherit
	/// the base in all tests and let Selenium handle the Chrome / Firefox Versions and we 
	/// Never have to worry about them. Also for Teardowns and Setups!
	/// </summary>
	[TestFixture]
	public class BaseTest
	{
		protected IWebDriver Driver { get; private set; }

		/// <summary>
		/// Set up the Drivers we need.
		/// </summary>
		[SetUp]
		public void CreateDriver()
		{
			// With Selenium 4.6+, this triggers Selenium Manager to fetch the correct ChromeDriver.
			Driver = new ChromeDriver();
		}

		/// <summary>
		/// Tear down the Drivers and release resources.
		/// </summary>
		[TearDown]
		public void CleanupDriver()
		{
			Driver?.Quit();
			Driver?.Dispose();
		}
	}
}
