#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
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
	public partial class AmendmentInvoiceLine
	{
		private int amendmentInvoiceLineId;
		public virtual int AmendmentInvoiceLineId
		{
			get
			{
				return this.amendmentInvoiceLineId;
			}
			set
			{
				this.amendmentInvoiceLineId = value;
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
		
		private AmendmentInvoice amendmentInvoice;
		public virtual AmendmentInvoice AmendmentInvoice
		{
			get
			{
				return this.amendmentInvoice;
			}
			set
			{
				this.amendmentInvoice = value;
			}
		}
		
		private User user;
		public virtual User User
		{
			get
			{
				return this.user;
			}
			set
			{
				this.user = value;
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
#pragma warning restore 1591
