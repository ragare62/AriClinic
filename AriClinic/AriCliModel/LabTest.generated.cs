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
	public partial class LabTest
	{
		private int labTestId;
		public virtual int LabTestId 
		{ 
		    get
		    {
		        return this.labTestId;
		    }
		    set
		    {
		        this.labTestId = value;
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
		
		private decimal minValue;
		public virtual decimal MinValue 
		{ 
		    get
		    {
		        return this.minValue;
		    }
		    set
		    {
		        this.minValue = value;
		    }
		}
		
		private decimal maxValue;
		public virtual decimal MaxValue 
		{ 
		    get
		    {
		        return this.maxValue;
		    }
		    set
		    {
		        this.maxValue = value;
		    }
		}
		
		private string generalType;
		public virtual string GeneralType 
		{ 
		    get
		    {
		        return this.generalType;
		    }
		    set
		    {
		        this.generalType = value;
		    }
		}
		
		private UnitType unitType;
		public virtual UnitType UnitType 
		{ 
		    get
		    {
		        return this.unitType;
		    }
		    set
		    {
		        this.unitType = value;
		    }
		}
		
		private IList<LabTestAssigned> labTestAssigneds = new List<LabTestAssigned>();
		public virtual IList<LabTestAssigned> LabTestAssigneds 
		{ 
		    get
		    {
		        return this.labTestAssigneds;
		    }
		}
		
	}
}
