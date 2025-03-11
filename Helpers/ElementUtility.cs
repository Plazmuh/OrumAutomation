using OpenQA.Selenium;

namespace OrumAutomation.Helpers
{
	/// <summary>
	/// A class I've created to Extrapolate the base Element functions and Objectify it.
	/// This helps tremendously with repitition and isolation.
	/// </summary>
	public class ElementUtility {

		// RD: 1 Minute seems reasonable for now...
		private const int TIMEOUT = 1;

		/// <summary>
		/// Gets an element using the 'By' Enum, within a timeout period.
		/// </summary>
		/// <param name="driver"></param>
		/// <param name="cssSelector"></param>
		/// <param name="Timeout"></param>
		/// <returns>IWebElement of the visible element</returns>
		public static IWebElement GetElement(IWebDriver driver, By locator, int Timeout = TIMEOUT)
		{
			var element = driver.FindElement(locator);

			// RD: Sometimes an Element isn't returned, and that's okay -- Let's set a timeout period to account for Browser Latency.
			DateTime start = DateTime.Now;
			while (DateTime.Now.Subtract(start).Minutes < Timeout && element == null || (element != null && !element.Displayed))
			{
				// RD: If we are in here, we haven't found it yet, but are retrying
				element = driver.FindElement(locator);
			}

			if (element == null)
				throw new ArgumentException($"Element was not found after {TIMEOUT} seconds. Locator was: {locator}");

			return element;
		}

		/// <summary>
		/// Much like GetElement, this function is going to use an array of locators for parallelism.
		/// </summary>
		/// <param name="driver"></param>
		/// <param name="cssSelector"></param>
		/// <param name="Timeout"></param>
		/// <returns>A value indicating if all elements are found</returns>
		public static bool GetElements(IWebDriver driver, string[] locators, int Timeout = TIMEOUT)
		{
			// RD: Leave early if there are no locators
			if (driver == null || locators.Length == 0)
				return false;

			foreach (var field in locators)
			{
				if (!string.IsNullOrEmpty(field))
				{
					var element = driver.FindElement(By.CssSelector(field));

					DateTime start = DateTime.Now;
					while (DateTime.Now.Subtract(start).Minutes < Timeout && element == null || (element != null && !element.Displayed))
						element = driver.FindElement(By.CssSelector(field));

					if (element == null)
						return false;
				}
				else
					return false;
			}

			return true;
		}

		#region Processors

		/// <summary>
		/// Will check any given uri, and ensure it's valid
		/// </summary>
		/// <param name="url"></param>
		/// <returns>A bool indicating success or failure of Uri</returns>
		public bool IsValidUrl(string url)
		{
			if (!string.IsNullOrEmpty(url))
			{
				Uri uriResult;
				
				// RD: This isn't a great way to do this, but time constraints in interviewing for orum.
				bool result = Uri.TryCreate(url, UriKind.Absolute, out uriResult)
					&& (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
				return result;
			}
			else
				return false;
		}

		/// <summary>
		/// Will cause an asynchronous await based on miliseconds, we prefer this so we can take control of threading.
		/// </summary>
		/// <param name="miliseconds"></param>
		/// <returns></returns>
		public static async Task PauseAsync(int miliseconds)
		{
			await Task.Delay(miliseconds).ConfigureAwait(false);
		}

		/// <summary>
		/// Tear down any driver
		/// </summary>
		public static async Task TearDown(IWebDriver driver)
		{
			driver.Quit();
			await PauseAsync(100);
		}

		#endregion Processors
	} 
}
