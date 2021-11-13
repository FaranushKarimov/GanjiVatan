using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Common
{
    public class JwtSettings
    {
        public const string KEY = "th!s !$ very l0ng key t0 gen@rate the t0ken";
        public const string AUDIENCE = "zooplanet.tj";
        public const string ISSUER = "zooplanet.tj";
        public const int DURATION = 40; // in minutes
    }
}
