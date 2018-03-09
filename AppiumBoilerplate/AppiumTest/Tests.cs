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


    }

    [TearDown]
    public void End()
    {
        driver.CloseApp();
    }
}