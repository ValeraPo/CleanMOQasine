using CleanMOQasine.Business.Security;
using NUnit.Framework;
using System;
using System.Security.Cryptography;

namespace CleanMOQasine.Business.Tests
{
    public class PasswordHashTests
    {
        [TestCase("pipi12")]
        [TestCase("")]
        [TestCase("     ")]
        public void HashPasswordTest(string passwordForTest)
        {
            //given
            string password = passwordForTest;

            //when
            string actual = PasswordHash.HashPassword(password);
            string expected = CalcHash(password);

            //then
            Assert.AreEqual(actual.Split(":")[0], expected.Split(":")[0]);
            Assert.AreEqual(actual.Split(":")[1].Length, expected.Split(":")[1].Length);
            Assert.AreEqual(actual.Split(":")[2].Length, expected.Split(":")[2].Length);
            Assert.AreEqual(Convert.FromBase64String(actual.Split(":")[1]).Length, PasswordHash.SaltByteSize);
            Assert.AreEqual(Convert.FromBase64String(actual.Split(":")[2]).Length, PasswordHash.HashByteSize);
        }

        [TestCase("pipi12", true)]
        [TestCase("nepizda", false)]
        public void ValidatePasswordTest(string currentPassword, bool expected)
        {
            //given
            string validPassword = "pipi12";

            //when
            bool actual = PasswordHash.ValidatePassword(validPassword, CalcHash(currentPassword));

            //then
            Assert.AreEqual(actual, expected);
        }

        private string CalcHash(string password)
        {
            var salt = new byte[PasswordHash.SaltByteSize];
            var provider = new RNGCryptoServiceProvider();
            provider.GetBytes(salt);
            var hash = new Rfc2898DeriveBytes(password, salt)
            {
                IterationCount = PasswordHash.Pbkdf2Iterations
            }
            .GetBytes(PasswordHash.HashByteSize);
            return $"{PasswordHash.Pbkdf2Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }
    }
}
