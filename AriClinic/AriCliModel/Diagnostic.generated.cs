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
	public partial class Diagnostic
	{
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
		
		private int diagnosticId;
		public virtual int DiagnosticId 
		{ 
		    get
		    {
		        return this.diagnosticId;
		    }
		    set
		    {
		        this.diagnosticId = value;
		    }
		}
		
		private int oftId;
		public virtual int OftId 
		{ 
		    get
		    {
		        return this.oftId;
		    }
		    set
		    {
		        this.oftId = value;
		    }
		}
		
		private IList<DiagnosticAssigned> diagnosticAssigneds = new List<DiagnosticAssigned>();
		public virtual IList<DiagnosticAssigned> DiagnosticAssigneds 
		{ 
		    get
		    {
		        return this.diagnosticAssigneds;
		    }
		}
		
	}
}
