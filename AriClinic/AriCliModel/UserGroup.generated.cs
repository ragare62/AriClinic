#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using AriCliModel;


namespace AriCliModel	
{
	public partial class UserGroup
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
		
		private IList<Permission> permissions = new List<Permission>();
		public virtual IList<Permission> Permissions 
		{ 
		    get
		    {
		        return this.permissions;
		    }
		}
		
	}
}
