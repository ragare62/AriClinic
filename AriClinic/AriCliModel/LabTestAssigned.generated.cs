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


namespace AriCliModel	
{
	public partial class LabTestAssigned
	{
		private int labTestAssignedId;
		public virtual int LabTestAssignedId 
		{ 
		    get
		    {
		        return this.labTestAssignedId;
		    }
		    set
		    {
		        this.labTestAssignedId = value;
		    }
		}
		
		private DateTime labTestDate;
		public virtual DateTime LabTestDate 
		{ 
		    get
		    {
		        return this.labTestDate;
		    }
		    set
		    {
		        this.labTestDate = value;
		    }
		}
		
		private string comments;
		public virtual string Comments 
		{ 
		    get
		    {
		        return this.comments;
		    }
		    set
		    {
		        this.comments = value;
		    }
		}
		
		private decimal numValue;
		public virtual decimal NumValue 
		{ 
		    get
		    {
		        return this.numValue;
		    }
		    set
		    {
		        this.numValue = value;
		    }
		}
		
		private string stringValue;
		public virtual string StringValue 
		{ 
		    get
		    {
		        return this.stringValue;
		    }
		    set
		    {
		        this.stringValue = value;
		    }
		}
		
		private LabTest labTest;
		public virtual LabTest LabTest 
		{ 
		    get
		    {
		        return this.labTest;
		    }
		    set
		    {
		        this.labTest = value;
		    }
		}
		
		private Patient patient1;
		public virtual Patient Patient 
		{ 
		    get
		    {
		        return this.patient1;
		    }
		    set
		    {
		        this.patient1 = value;
		    }
		}
		
		private Visit visit;
		public virtual Visit Visit 
		{ 
		    get
		    {
		        return this.visit;
		    }
		    set
		    {
		        this.visit = value;
		    }
		}
		
	}
}
