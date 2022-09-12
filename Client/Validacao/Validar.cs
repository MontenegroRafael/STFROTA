using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Validacao
{
    public class Validar
    {
        public static bool Login(string login)
        {
            if (login == "admin")
            {
                return true;
            }
            return false;
        }
    }
}
