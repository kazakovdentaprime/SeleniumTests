using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests;

public class Tests
{
    public const string Url = "https://the-internet.herokuapp.com/inputs";
    IWebDriver driver;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver($"{AppContext.BaseDirectory}/Drivers");
    }

    [Test]
    public void VerifyInputVisible()
    {
        driver.Navigate().GoToUrl(Url);

        Assert.IsTrue(driver.FindElement(By.CssSelector("input[type=\"number\"]")).Displayed);
    }

    [Test]
    public void VerifyInputProperties()
    {
        driver.Navigate().GoToUrl(Url);

        var input = driver.FindElement(By.CssSelector("input[type=\"number\"]"));
        var initialInputValue = input.GetAttribute("value");

        Assert.Multiple(() =>
        {
            Assert.IsTrue(input.Enabled);
            Assert.IsEmpty(initialInputValue);
        });
    }

    [Test]
    public void VerifyInputValueChangesOnNumberPressed()
    {
        driver.Navigate().GoToUrl(Url);

        var input = driver.FindElement(By.CssSelector("input[type=\"number\"]"));

        input.SendKeys("123");

        Assert.That(input.GetAttribute("value")!, Is.EqualTo("123"));
    }

    [Test]
    public void VerifyInputValueDoesNotChangeOnNonNumberPressed()
    {
        driver.Navigate().GoToUrl(Url);

        var input = driver.FindElement(By.CssSelector("input[type=\"number\"]"));

        input.SendKeys("~!@#$%^&/*-qazvwinadspvnVCBOSBADBRNEF");

        Assert.IsEmpty(input.GetAttribute("value"));
    }

    [Test]
    [TestCase(new object[] {"123wicubsapvina", "123"})]
    [TestCase(new object[] {"4avbsnfgd8svdnm,u2", "482"})]
    [TestCase(new object[] {"asfzdva0vythrg8fsvbg  6", "086"})]
    [TestCase(new object[] { "5e2eeee", "5e2" })]
    public void VerifyInputValueChangesOnlyOnNumberPressed(string keys, string expected)
    {
        driver.Navigate().GoToUrl(Url);

        var input = driver.FindElement(By.CssSelector("input[type=\"number\"]"));

        input.Clear();
        input.SendKeys(keys);

        Assert.That(input.GetAttribute("value")!, Is.EqualTo(expected));
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
