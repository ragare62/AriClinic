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


namespace AriCliModel	
{
	public partial class Email
	{
		private int emailId;
		public virtual int EmailId 
		{ 
		    get
		    {
		        return this.emailId;
		    }
		    set
		    {
		        this.emailId = value;
		    }
		}
		
		private string type;
		public virtual string Type 
		{ 
		    get
		    {
		        return this.type;
		    }
		    set
		    {
		        this.type = value;
		    }
		}
		
		private string url;
		public virtual string Url 
		{ 
		    get
		    {
		        return this.url;
		    }
		    set
		    {
		        this.url = value;
		    }
		}
		
		private Clinic clinic;
		public virtual Clinic Clinic 
		{ 
		    get
		    {
		        return this.clinic;
		    }
		    set
		    {
		        this.clinic = value;
		    }
		}
		
		private Person person;
		public virtual Person Person 
		{ 
		    get
		    {
		        return this.person;
		    }
		    set
		    {
		        this.person = value;
		    }
		}
		
		private HealthcareCompany healthcareCompany;
		public virtual HealthcareCompany HealthcareCompany 
		{ 
		    get
		    {
		        return this.healthcareCompany;
		    }
		    set
		    {
		        this.healthcareCompany = value;
		    }
		}
		
	}
}
