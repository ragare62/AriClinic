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
	public partial class ProfessionalInvoiceLine
	{
		private int invoiceLineId;
		public virtual int InvoiceLineId 
		{ 
		    get
		    {
		        return this.invoiceLineId;
		    }
		    set
		    {
		        this.invoiceLineId = value;
		    }
		}
		
		private string description;
		public virtual string Description 
		{ 
		    get
		    {
		        return this.description;
		    }
		    set
		    {
		        this.description = value;
		    }
		}
		
		private decimal taxPercentage;
		public virtual decimal TaxPercentage 
		{ 
		    get
		    {
		        return this.taxPercentage;
		    }
		    set
		    {
		        this.taxPercentage = value;
		    }
		}
		
		private decimal amount;
		public virtual decimal Amount 
		{ 
		    get
		    {
		        return this.amount;
		    }
		    set
		    {
		        this.amount = value;
		    }
		}
		
		private ProfessionalInvoice professionalInvoice;
		public virtual ProfessionalInvoice ProfessionalInvoice 
		{ 
		    get
		    {
		        return this.professionalInvoice;
		    }
		    set
		    {
		        this.professionalInvoice = value;
		    }
		}
		
		private Ticket ticket;
		public virtual Ticket Ticket 
		{ 
		    get
		    {
		        return this.ticket;
		    }
		    set
		    {
		        this.ticket = value;
		    }
		}
		
		private TaxType taxType;
		public virtual TaxType TaxType 
		{ 
		    get
		    {
		        return this.taxType;
		    }
		    set
		    {
		        this.taxType = value;
		    }
		}
		
	}
}
