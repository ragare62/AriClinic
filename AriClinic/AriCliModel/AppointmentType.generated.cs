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
	public partial class AppointmentType
	{
		private int appointmentTypeId;
		public virtual int AppointmentTypeId 
		{ 
		    get
		    {
		        return this.appointmentTypeId;
		    }
		    set
		    {
		        this.appointmentTypeId = value;
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
		
		private int duration;
		public virtual int Duration 
		{ 
		    get
		    {
		        return this.duration;
		    }
		    set
		    {
		        this.duration = value;
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
		
		private IList<AppointmentInfo> appointmentsRelated = new List<AppointmentInfo>();
		public virtual IList<AppointmentInfo> AppointmentsRelated 
		{ 
		    get
		    {
		        return this.appointmentsRelated;
		    }
		}
		
		private IList<BaseVisit> baseVisits = new List<BaseVisit>();
		public virtual IList<BaseVisit> BaseVisits 
		{ 
		    get
		    {
		        return this.baseVisits;
		    }
		}
		
	}
}
