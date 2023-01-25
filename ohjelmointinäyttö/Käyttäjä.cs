using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace ohjelmointinäyttö
{
    class Käyttäjä
    {
        public string KäyttäjäTunnus { get; set; }
        public SecureString Salasana { get; set; }
    }
}
