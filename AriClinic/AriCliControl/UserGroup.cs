using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliControl
{
    class UserGroup
    {
        private int userGroupId;
        public virtual int UserGroupId
        {
            get
            {
                return this.userGroupId;
            }
            set
            {
                this.userGroupId = value;
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

        private IList<User> users = new List<User>();
        public virtual IList<User> Users
        {
            get
            {
                return this.users;
            }
        }

    }
}
