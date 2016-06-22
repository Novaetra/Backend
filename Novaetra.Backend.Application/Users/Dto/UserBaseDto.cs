using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Novaetra.Backend.Cryptography;

namespace Novaetra.Backend.Users.Dto
{
    public abstract class UserBaseDto
    {
        protected UserBaseDto()
        {
            IterationCount = 20000;
        }

        public virtual string Password
        {
            set
            {
                Salt = Hasher.GenerateSalt(8 * 16);
                PasswordHash = Hasher.PBKDF2Sha256GetBytes(8 * 32, Hasher.GetBytes(value), Salt, IterationCount);
            }
        }

        public byte[] Salt { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public int IterationCount { get; }
    }
}
