using Funda_NL_Assignment.Helpers;
using Funda_NL_Assignment.Utilities;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Funda_NL_Assignment.Steps
{
    [Binding]
    public class KoopFeatureSteps : Base
    {
        [Given(@"Open koop tab")]
        public void GivenOpenKoopTab()
        {
            ClickElement(read("kooplink"));
        }

        [When(@"Fill textbox ""(.*)"" as ""(.*)""")]
        public void WhenFillTextboxAs(string element, string text)
        {
            SetValue(element, text);
        }

        [When(@"Click button ""(.*)""")]
        public void WhenClickButton(string element)
        {
            ClickElement(element);

        }

        [Then(@"Url path contains ""(.*)""")]
        public void ThenUrlPathContains(string path)
        {
            Assert.AreEqual(Constants.Url + path, GetUrl());
        }

        [Then(@"Page contains element ""(.*)""")]
        public void ThenPageContainsElement(string element)
        {
            FindElement(element);
        }

    }
}
