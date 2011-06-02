using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliControl
{
    class User
    {
        private int userId;
        public virtual int UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private string name;
        public virtual string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        private string login;
        public virtual string Login
        {
            get
            {
                return this.login;
            }
            set
            {
                this.login = value;
            }
        }

        private string password;
        public virtual string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }

        private UserGroup userGroup;
        public virtual UserGroup UserGroup
        {
            get
            {
                return this.userGroup;
            }
            set
            {
                this.userGroup = value;
            }
        }

    }
}
