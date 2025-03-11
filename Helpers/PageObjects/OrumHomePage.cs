using OpenQA.Selenium;
using System;
using System.Threading.Tasks;

namespace OrumAutomation.Helpers.PageObjects
{
	/// <summary>
	/// A class to control Orums Homepage, this can be further expanded.
	/// </summary>
	public class OrumHomePage : ElementUtility
	{
		private string orumHomePage = "https://www.Orum.com/";
		private string orumSignInButton = "#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.lg\\:flex.z-\\[10\\].items-center.gap-\\[30px\\] > a.t-15.font-medium.leading-\\[1\\.2\\].false";
		private IWebDriver driver;

		public OrumHomePage(IWebDriver driver)
		{
			this.driver = driver;
		}

		#region Homepage functions

		/// <summary>
		/// Goes to Orum's HomePage and wait until an element is visible, confirming it's loaded.
		/// </summary>
		/// <returns>A boolean indicating whether we successfully navigated to the homepage</returns>
		public async Task<bool> GoToHomePage()
		{
			try
			{
				// Navigate to Homepage
				driver.Navigate().GoToUrl(orumHomePage);
				//driver.Manage().Window.Maximize();
				await PauseAsync(300);

				// Make sure there's a button visible before we assume the page has loaded.
				// This will help to keep our team at Orum accountable to any potential HTML/CSS Selector changes.
				GetElement(driver, By.CssSelector(orumSignInButton), 15);
				return true;
			}
			catch (Exception ex)
			{
				throw new Exception($"Unable to locate the Sign in Button located in Orums homepage... Has something changed!? Error: {ex.Message}");
			}
		}

		#endregion Homepage functions
	}
}
