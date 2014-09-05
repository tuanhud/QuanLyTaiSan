using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SHARED.Libraries;

namespace UnitTest
{
    [TestClass]
    public class Libraries
    {
        [TestMethod]
        public void Test_SHA1()
        {
            string expected = "d033e22ae348aeb5660fc2140aec35850c4da997";
            String actual = StringHelper.SHA1("admin").ToLower();
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void Test_CoDauKhongDau()
        {
            string expected = "ban di choi. CHUNG TOI O LAI~!@#$%^&*()_+";
            String actual = StringHelper.CoDauThanhKhongDau("bạn đi chơi. CHÚNG TÔI Ở LẠI~!@#$%^&*()_+");
            Assert.AreEqual(expected, actual);

            Assert.AreEqual("", StringHelper.CoDauThanhKhongDau(""));
        }
        [TestMethod]
        public void Test_DateTimeToMiliSec()
        {
            Assert.AreEqual(true, DateTimeHelper.toMilisec(new DateTime(2014,1,1,1,1,1))>0);
        }
    }
}
