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


namespace AriCliModel	
{
	public partial class AnestheticTicket : Ticket
	{
		private Professional surgeon;
		public virtual Professional Surgeon 
		{ 
		    get
		    {
		        return this.surgeon;
		    }
		    set
		    {
		        this.surgeon = value;
		    }
		}
		
		private Procedure procedure;
		public virtual Procedure Procedure 
		{ 
		    get
		    {
		        return this.procedure;
		    }
		    set
		    {
		        this.procedure = value;
		    }
		}
		
		private AnestheticServiceNote anestheticServiceNote;
		public virtual AnestheticServiceNote AnestheticServiceNote 
		{ 
		    get
		    {
		        return this.anestheticServiceNote;
		    }
		    set
		    {
		        this.anestheticServiceNote = value;
		    }
		}
		
	}
}
