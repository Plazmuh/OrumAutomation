using OpenQA.Selenium;
using OrumAutomation.Helpers.PageObjects;
using OrumAutomation.Helpers;

namespace OrumAutomation.Tests.WebTests.StaticTests
{
	[Author("Raymond Dasilva", "raymond.dasilva@outlook.com")]
	[NonParallelizable] // RD: We need this to be run sequentially for the CI containers it runs on.
	public class StaticOrumTest : BaseTest
	{
		[SetUp]
		public async Task BeforeEachTest()
		{
			try
			{
				// RD: Navigate to the homepage at the start of each test.
				var page = new OrumHomePage(Driver);
				await page.GoToHomePage().ConfigureAwait(false);
			}
			catch (Exception exception)
			{
				Assert.Fail($"Failed going to Home Page... Error: {exception.Message}");
			}
		}

		#region Test Case

		/// <summary>
		/// TEST: Homepage loads successfully.
		/// </summary>
		[Test, Order(1)]
		public void OrumHomePageIsAccessible()
		{
			// RD: If we reached here, the homepage loaded successfully.
			Assert.Pass();
		}

		/// <summary>
		/// TEST: Homepage contains the sign in button, and is visible.
		/// </summary>
		/// <returns></returns>
		[Test, Order(2)]
		public async Task OrumHomePageSignInButtonAsync()
		{
			// Interact with the Sign-In button.
			var elem = ElementUtility.GetElement(Driver, By.CssSelector("#__next > header > div.mx-auto.flex.min-h-\\[4rem\\].w-full.max-w-\\[1310px\\].items-center.justify-between.px-\\[15px\\] > div.hidden.lg\\:flex.z-\\[10\\].items-center.gap-\\[30px\\] > a.t-15.font-medium.leading-\\[1\\.2\\].false"), 60);
			elem.Click();
			await ElementUtility.PauseAsync(3000).ConfigureAwait(false);

			Assert.Pass();
		}

		/// <summary>
		/// TEST: Simulates multiple page interactions for a user in the homepage.
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
