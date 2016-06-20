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
        public virtual string Password
        {
            set
            {
                Salt = Hasher.GenerateSalt(8 * 16);
                Hasher.PBKDF2Sha256GetBytes(8 * 32, Hasher.GetBytes(value), Salt, 20000);
            }
        }

        public byte[] Salt { get; private set; }
        public byte[] Hash { get; private set; }
        public int IterationCount { get; private set; }
    }
}
