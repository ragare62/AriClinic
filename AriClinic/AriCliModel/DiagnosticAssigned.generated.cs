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
	public partial class DiagnosticAssigned
	{
		private DateTime diagnosticDate;
		public virtual DateTime DiagnosticDate 
		{ 
		    get
		    {
		        return this.diagnosticDate;
		    }
		    set
		    {
		        this.diagnosticDate = value;
		    }
		}
		
		private int diagnosticAssignedId;
		public virtual int DiagnosticAssignedId 
		{ 
		    get
		    {
		        return this.diagnosticAssignedId;
		    }
		    set
		    {
		        this.diagnosticAssignedId = value;
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
		
		private BaseVisit baseVisit;
		public virtual BaseVisit BaseVisit 
		{ 
		    get
		    {
		        return this.baseVisit;
		    }
		    set
		    {
		        this.baseVisit = value;
		    }
		}
		
		private Diagnostic diagnostic;
		public virtual Diagnostic Diagnostic 
		{ 
		    get
		    {
		        return this.diagnostic;
		    }
		    set
		    {
		        this.diagnostic = value;
		    }
		}
		
		private Patient patient;
		public virtual Patient Patient 
		{ 
		    get
		    {
		        return this.patient;
		    }
		    set
		    {
		        this.patient = value;
		    }
		}
		
	}
}
