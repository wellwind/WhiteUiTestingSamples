using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TestStack;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace AddCalculator.Tests
{
    [TestClass]
    public class CalculatorFormUITest
    {
        private Application application { get; set; }
        private Window window { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var applicationPath = "C:\\temp\\AddCalculator.exe";
            application = Application.Launch(applicationPath);
            window = application.GetWindow("加法器", InitializeOption.NoCache);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            application.Close();
        }

        [TestMethod]
        public void TestMedthod_Num1_Is_3_And_Num1_Is_5_Then_Result_Is_8()
        {
            // Arrange
            var txtNum1 = window.Get<TextBox>("txtNum1");
            txtNum1.Text = "3";

            var txtNum2 = window.Get<TextBox>("txtNum2");
            txtNum2.Text = "5";

            var expected = "8";

            // Act
            var button = window.Get<Button>("btnAdd");
            button.Click();

            // Assert
            var lblResult = window.Get<Label>("lblResult");
            var actual = lblResult.Text;

            Assert.AreEqual(expected, actual);
        }
    }
}