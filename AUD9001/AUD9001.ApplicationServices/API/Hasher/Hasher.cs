using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace AUD9001.ApplicationServices.API.Hasher
{
    public class Hasher : IHasher
    {
        public async Task<string> GenerateHash(byte[] salt, string password)
        {
            string hashed = "";
            await Task.Run(() =>
                            hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA1,
                            iterationCount: 10000,
                            numBytesRequested: 256 / 8)));
            return hashed;
        }

        public async Task<byte[]> GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                await Task.Run(()=> rng.GetBytes(salt));
            }
            return salt;
        }
    }
}
