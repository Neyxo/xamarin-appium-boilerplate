using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;

[TestFixture()]
public class Tests
{
    public AndroidDriver<AppiumWebElement> driver;

    [SetUp]
    public void SetUp()
    {
        DesiredCapabilities capabilities = new DesiredCapabilities();
        // Set device capabilities
        capabilities.SetCapability("platformName", "Android");
        capabilities.SetCapability("platformVersion", "7.0");
        capabilities.SetCapability("deviceName", "mydevice");
        // Set application capabilities
        capabilities.SetCapability("appPackage", "com.companyname.AppiumBoilerplate");
        capabilities.SetCapability("appActivity", "md5d297de0b36d5377ccc45b847c53a985d.MainActivity");

        driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        driver.LaunchApp();
    }

    [Test()]
    public void DetailTest()
    {
        AppiumWebElement el1 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.ListView/android.widget.LinearLayout[1]/android.view.ViewGroup/android.view.ViewGroup");
        el1.Click();
        AppiumWebElement el2 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.TextView");
        AppiumWebElement el3 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.widget.ImageButton");
        el3.Click();
        Assert.IsTrue(el2.Text.Equals("First item"));
    }

    [Test()]
    public void AddTest()
    {
        AppiumWebElement el4 = (AppiumWebElement)driver.FindElementByAccessibilityId("Add");
        el4.Click();
        AppiumWebElement el5 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup[1]/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.ListView/android.widget.LinearLayout[1]/android.view.ViewGroup/android.view.ViewGroup");
        el5.Click();
        el5.Clear();
        el5.SendKeys("New item");
        AppiumWebElement el6 = (AppiumWebElement)driver.FindElementByAccessibilityId("Save");
        el6.Click();
        AppiumWebElement el7 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup/android.widget.ListView/android.widget.LinearLayout[7]/android.view.ViewGroup/android.view.ViewGroup");
        el7.Click();
        AppiumWebElement el8 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[2]/android.widget.TextView");
        AppiumWebElement el9 = (AppiumWebElement)driver.FindElementByXPath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.FrameLayout/android.widget.RelativeLayout/android.view.ViewGroup/android.view.ViewGroup/android.support.v4.view.ViewPager/android.view.ViewGroup/android.view.ViewGroup/android.view.ViewGroup[1]/android.widget.ImageButton");
        el9.Click();
        Assert.IsTrue(el8.Text.Equals("New item"));
    }

    [TearDown]
    public void End()
    {
        driver.CloseApp();
    }
}