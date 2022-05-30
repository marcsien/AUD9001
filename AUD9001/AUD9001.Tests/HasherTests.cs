using AUD9001.ApplicationServices.API.Hasher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace AUD9001.Tests
{
    [TestClass]
    public class HasherTests
    {
        [TestMethod]
        public async Task GenerateSalt_ProperParameters_ReturnsSalt()
        {
            //Arrange
            byte[] salt = null;
            Hasher hasher = new Hasher();

            //Act
            salt = await hasher.GenerateSalt();

            //Assert
            Assert.IsNotNull(salt);
        }

        [TestMethod]
        public async Task GenerateHash_ProperParameters_ReturnsHash()
        {
            //Arrange
            Hasher hasher = new Hasher();
            byte[] salt = await hasher.GenerateSalt();
            string password = "testpassword";
            string hash = null;

            //Act
            hash = await hasher.GenerateHash(salt, password);

            //Assert
            Assert.IsNotNull(hash);
        }
    }
}
