using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OrumAutomation.Helpers.PageObjects;
using OrumAutomation.Helpers;

namespace OrumAutomation.Tests.WebTests.StaticTests
{
	[Parallelizable(ParallelScope.Fixtures)]
	[Author("Raymond Dasilva", "raymond.dasilva@outlook.com")]
	public class StaticOrumTest : BaseTest
	{
		/// <summary>
		/// Starts every Test on the HomePage, since that is what this folder is for.
		/// </summary>
		/// <returns></returns>
		[SetUp]
		public async Task BeforeEachTest()
		{
			try
			{
				var Page = new OrumHomePage(Driver);
				await Page.GoToHomePage().ConfigureAwait(false);
			}
			catch (Exception exception)
			{
				Assert.Fail($"Failed going to Home Page... Error: {exception.Message}");
			}
		}

		#region Test Cases
		/// <summary>
		/// Test: Go through a few different pages and make sure elements are visible
		/// </summary>
		/// <returns></returns>
		[Test, Order(1)]
		public void OrumHomePageIsAccessible()
		{
			// If we made it here, our base test and homepage passed, let's mark that.
			Assert.Pass();
		}

		[Test, Order(2)]
		public async Task OrumHomePageSignInButtonAsync()
		{
			// Are we able to see the sign in page or is it down?
			var elem = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.lg\\:flex.z-\\[10\\].items-center.gap-\\[30px\\] > a.t-15.font-medium.leading-\\[1\\.2\\].false"), 60);
			elem.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// Test Passed.
			Assert.Pass();
		}

		/// <summary>
		/// Simulates multiple pages for a user in the homepage.
		/// </summary>
		/// <returns></returns>
		[Test, Order(3)]
		public async Task OrumHomePageMultiplePageStatusAsync()
		{
			// -- Product
			var productsLink = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.flex-col.py-4.lg\\:flex > nav > ul > li:nth-child(1) > button > span"), 60);
			productsLink.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// -- Solutions
			var solutionsLink = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.flex-col.py-4.lg\\:flex > nav > ul > li:nth-child(2) > button > span"), 60);
			solutionsLink.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// -- Customers
			var customersLink = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.flex-col.py-4.lg\\:flex > nav > ul > li:nth-child(3) > a > button > span"), 60);
			customersLink.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// -- Resources
			var resourcesLink = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.flex-col.py-4.lg\\:flex > nav > ul > li:nth-child(4) > button > span"), 60);
			resourcesLink.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// -- Pricing
			var pricingLink = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.flex-col.py-4.lg\\:flex > nav > ul > li:nth-child(6) > a > button > span"), 60);
			pricingLink.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			// Test Passed.
			Assert.Pass();
		}

		#endregion Test Case
	}
}
