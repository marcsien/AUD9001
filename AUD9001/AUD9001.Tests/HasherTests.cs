using AUD9001.ApplicationServices.API.Hasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace AUD9001.Tests
{
    [TestClass]
    public class HasherTests : TestBase
    {
        public string test_password { get; set; }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HasherTests")]
        public async Task GenerateSalt_ProperParameters_ReturnsSalt()
        {
            //Arrange
            byte[] salt = null;
            Hasher hasher = new Hasher();
            SetGoodFileName();

            //Act
            TestContext.WriteLine("Generating salt");
            test_password = TestContext.Properties["password"].ToString();
            TestContext.WriteLine($"Using password: {test_password}");
            salt = await hasher.GenerateSalt();

            //Assert
            Assert.IsNotNull(salt);
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HasherTests")]
        public async Task GenerateHash_ProperParameters_ReturnsHash()
        {
            //Arrange
            Hasher hasher = new Hasher();
            byte[] salt = await hasher.GenerateSalt();
            string hash = null;

            //Act
            TestContext.WriteLine("Generating hash");
            test_password = TestContext.Properties["password"].ToString();
            TestContext.WriteLine($"Using password: {test_password}");
            hash = await hasher.GenerateHash(salt, test_password);

            //Assert
            Assert.IsNotNull(hash);
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HasherTests")]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public async Task GenerateHash_EmptySalt_ThrowsException1()
        {
            //Arrange
            Hasher hasher = new Hasher();
            string hash = null;

            //Act
            test_password = TestContext.Properties["password"].ToString();
            TestContext.WriteLine($"Using password: {test_password}");
            hash = await hasher.GenerateHash(null, test_password);
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HasherTests")]
        public async Task GenerateHash_EmptySalt_ThrowsException2()
        {
            //Arrange
            Hasher hasher = new Hasher();
            string hash = null;

            //Act
            try
            {
                test_password = TestContext.Properties["password"].ToString();
                TestContext.WriteLine($"Using password: {test_password}");
                hash = await hasher.GenerateHash(null, test_password);
            }
            catch (System.ArgumentNullException)
            {

                return;
            }

            //Assert
            Assert.Fail("ArgumentNullException was not thrown as expected");
        }

        [TestMethod]
        [Owner("marcsien")]
        [Priority(1)]
        [TestCategory("HasherTests")]
        [DataRow("password1")]
        [DataRow("password2")]
        [DataRow("pasfword8")]
        [DataRow("passwgrd3")]
        [DataRow("pashword5")]
        public async Task GenerateHash_ProperParametersWithMultipleRows_ReturnsHash(string pass)
        {
            //Arrange
            Hasher hasher = new Hasher();
            byte[] salt = await hasher.GenerateSalt();
            string hash = null;

            //Act
            TestContext.WriteLine("Generating hash");
            test_password = pass;
            TestContext.WriteLine($"Using password: {test_password}");
            hash = await hasher.GenerateHash(salt, test_password);

            //Assert
            Assert.IsNotNull(hash);
        }


    }
}
