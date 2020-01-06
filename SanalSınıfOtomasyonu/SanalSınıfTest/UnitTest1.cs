using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Extensions.Forms;
using SanalSınıfOtomasyonu;

namespace SanalSınıfTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Login login=new Login();
            login.Show();
        }
        [TestMethod]
        public void TestMethod2()
        {
            ButtonTester buttonTester=new ButtonTester("button1");
            buttonTester.Click();
        }
        [TestMethod]
        public void TestMethod3()
        {
            Login login = new Login();
            login.Show();
        }
    }
}
