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
	public partial class ProfessionalInvoice
	{
		private int invoiceId;
		public virtual int InvoiceId 
		{ 
		    get
		    {
		        return this.invoiceId;
		    }
		    set
		    {
		        this.invoiceId = value;
		    }
		}
		
		private DateTime invoiceDate;
		public virtual DateTime InvoiceDate 
		{ 
		    get
		    {
		        return this.invoiceDate;
		    }
		    set
		    {
		        this.invoiceDate = value;
		    }
		}
		
		private int year;
		public virtual int Year 
		{ 
		    get
		    {
		        return this.year;
		    }
		    set
		    {
		        this.year = value;
		    }
		}
		
		private int invoiceNumber;
		public virtual int InvoiceNumber 
		{ 
		    get
		    {
		        return this.invoiceNumber;
		    }
		    set
		    {
		        this.invoiceNumber = value;
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
		
		private string serial;
		public virtual string Serial 
		{ 
		    get
		    {
		        return this.serial;
		    }
		    set
		    {
		        this.serial = value;
		    }
		}
		
		private decimal taxWithHoldingPercentage;
		public virtual decimal TaxWithHoldingPercentage 
		{ 
		    get
		    {
		        return this.taxWithHoldingPercentage;
		    }
		    set
		    {
		        this.taxWithHoldingPercentage = value;
		    }
		}
		
		private Professional professional;
		public virtual Professional Professional 
		{ 
		    get
		    {
		        return this.professional;
		    }
		    set
		    {
		        this.professional = value;
		    }
		}
		
		private IList<ProfessionalInvoiceLine> professionalInvoiceLines = new List<ProfessionalInvoiceLine>();
		public virtual IList<ProfessionalInvoiceLine> ProfessionalInvoiceLines 
		{ 
		    get
		    {
		        return this.professionalInvoiceLines;
		    }
		}
		
		private IList<ServiceNote> serviceNotes = new List<ServiceNote>();
		public virtual IList<ServiceNote> ServiceNotes 
		{ 
		    get
		    {
		        return this.serviceNotes;
		    }
		}
		
		private IList<AnestheticServiceNote> anestheticServiceNotes = new List<AnestheticServiceNote>();
		public virtual IList<AnestheticServiceNote> AnestheticServiceNotes 
		{ 
		    get
		    {
		        return this.anestheticServiceNotes;
		    }
		}
		
	}
}
