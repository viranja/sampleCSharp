using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Username))
            {
                throw new Exception("Username can not be blank");
            }
        }
    }


    public class SupperUser : User
    {
        public override void Validate()
        {
            if (string.IsNullOrEmpty(Password))
            {
                throw new Exception("Password can not be blank");
            }

            base.Validate();

            
        }
    }
}
