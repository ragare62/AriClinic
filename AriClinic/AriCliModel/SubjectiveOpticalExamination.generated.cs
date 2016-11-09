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
	public partial class SubjectiveOpticalExamination : OpticalTest
	{
		private int id;
		public virtual int Id 
		{ 
		    get
		    {
		        return this.id;
		    }
		    set
		    {
		        this.id = value;
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
		
		private string farSphericityRightEye;
		public virtual string FarSphericityRightEye 
		{ 
		    get
		    {
		        return this.farSphericityRightEye;
		    }
		    set
		    {
		        this.farSphericityRightEye = value;
		    }
		}
		
		private string farCylinderRightEye;
		public virtual string FarCylinderRightEye 
		{ 
		    get
		    {
		        return this.farCylinderRightEye;
		    }
		    set
		    {
		        this.farCylinderRightEye = value;
		    }
		}
		
		private string farAxisRightEye;
		public virtual string FarAxisRightEye 
		{ 
		    get
		    {
		        return this.farAxisRightEye;
		    }
		    set
		    {
		        this.farAxisRightEye = value;
		    }
		}
		
		private string farPrimsRightEye;
		public virtual string FarPrimsRightEye 
		{ 
		    get
		    {
		        return this.farPrimsRightEye;
		    }
		    set
		    {
		        this.farPrimsRightEye = value;
		    }
		}
		
		private string farVisualAcuityRightEye;
		public virtual string FarVisualAcuityRightEye 
		{ 
		    get
		    {
		        return this.farVisualAcuityRightEye;
		    }
		    set
		    {
		        this.farVisualAcuityRightEye = value;
		    }
		}
		
		private string farSphericityLeftEye;
		public virtual string FarSphericityLeftEye 
		{ 
		    get
		    {
		        return this.farSphericityLeftEye;
		    }
		    set
		    {
		        this.farSphericityLeftEye = value;
		    }
		}
		
		private string farCylinderLeftEye;
		public virtual string FarCylinderLeftEye 
		{ 
		    get
		    {
		        return this.farCylinderLeftEye;
		    }
		    set
		    {
		        this.farCylinderLeftEye = value;
		    }
		}
		
		private string farAxisLeftEye;
		public virtual string FarAxisLeftEye 
		{ 
		    get
		    {
		        return this.farAxisLeftEye;
		    }
		    set
		    {
		        this.farAxisLeftEye = value;
		    }
		}
		
		private string farPrismLeftEye;
		public virtual string FarPrismLeftEye 
		{ 
		    get
		    {
		        return this.farPrismLeftEye;
		    }
		    set
		    {
		        this.farPrismLeftEye = value;
		    }
		}
		
		private string farVisualAcuityLeftEye;
		public virtual string FarVisualAcuityLeftEye 
		{ 
		    get
		    {
		        return this.farVisualAcuityLeftEye;
		    }
		    set
		    {
		        this.farVisualAcuityLeftEye = value;
		    }
		}
		
		private string closeSphericityRightEye;
		public virtual string CloseSphericityRightEye 
		{ 
		    get
		    {
		        return this.closeSphericityRightEye;
		    }
		    set
		    {
		        this.closeSphericityRightEye = value;
		    }
		}
		
		private string closeSphericityLeftEye;
		public virtual string CloseSphericityLeftEye 
		{ 
		    get
		    {
		        return this.closeSphericityLeftEye;
		    }
		    set
		    {
		        this.closeSphericityLeftEye = value;
		    }
		}
		
		private string closeCylinderRightEye;
		public virtual string CloseCylinderRightEye 
		{ 
		    get
		    {
		        return this.closeCylinderRightEye;
		    }
		    set
		    {
		        this.closeCylinderRightEye = value;
		    }
		}
		
		private string closeCylinderLeftEye;
		public virtual string CloseCylinderLeftEye 
		{ 
		    get
		    {
		        return this.closeCylinderLeftEye;
		    }
		    set
		    {
		        this.closeCylinderLeftEye = value;
		    }
		}
		
		private string closeAxisRightEye;
		public virtual string CloseAxisRightEye 
		{ 
		    get
		    {
		        return this.closeAxisRightEye;
		    }
		    set
		    {
		        this.closeAxisRightEye = value;
		    }
		}
		
		private string closeAxisLeftEye;
		public virtual string CloseAxisLeftEye 
		{ 
		    get
		    {
		        return this.closeAxisLeftEye;
		    }
		    set
		    {
		        this.closeAxisLeftEye = value;
		    }
		}
		
		private string closePrismRightEye;
		public virtual string ClosePrismRightEye 
		{ 
		    get
		    {
		        return this.closePrismRightEye;
		    }
		    set
		    {
		        this.closePrismRightEye = value;
		    }
		}
		
		private string closePrismLeftEye;
		public virtual string ClosePrismLeftEye 
		{ 
		    get
		    {
		        return this.closePrismLeftEye;
		    }
		    set
		    {
		        this.closePrismLeftEye = value;
		    }
		}
		
		private string closeAcuityRightEye;
		public virtual string CloseAcuityRightEye 
		{ 
		    get
		    {
		        return this.closeAcuityRightEye;
		    }
		    set
		    {
		        this.closeAcuityRightEye = value;
		    }
		}
		
		private string closeAcuityLeftEye;
		public virtual string CloseAcuityLeftEye 
		{ 
		    get
		    {
		        return this.closeAcuityLeftEye;
		    }
		    set
		    {
		        this.closeAcuityLeftEye = value;
		    }
		}
		
		private string bothSphericityRightEye;
		public virtual string BothSphericityRightEye 
		{ 
		    get
		    {
		        return this.bothSphericityRightEye;
		    }
		    set
		    {
		        this.bothSphericityRightEye = value;
		    }
		}
		
		private string bothSphericityLeftEye;
		public virtual string BothSphericityLeftEye 
		{ 
		    get
		    {
		        return this.bothSphericityLeftEye;
		    }
		    set
		    {
		        this.bothSphericityLeftEye = value;
		    }
		}
		
		private string bothCylinderRightEye;
		public virtual string BothCylinderRightEye 
		{ 
		    get
		    {
		        return this.bothCylinderRightEye;
		    }
		    set
		    {
		        this.bothCylinderRightEye = value;
		    }
		}
		
		private string bothCylinderLeftEye;
		public virtual string BothCylinderLeftEye 
		{ 
		    get
		    {
		        return this.bothCylinderLeftEye;
		    }
		    set
		    {
		        this.bothCylinderLeftEye = value;
		    }
		}
		
		private string bothAxisRightEye;
		public virtual string BothAxisRightEye 
		{ 
		    get
		    {
		        return this.bothAxisRightEye;
		    }
		    set
		    {
		        this.bothAxisRightEye = value;
		    }
		}
		
		private string bothAxisLeftEye;
		public virtual string BothAxisLeftEye 
		{ 
		    get
		    {
		        return this.bothAxisLeftEye;
		    }
		    set
		    {
		        this.bothAxisLeftEye = value;
		    }
		}
		
		private string bothPrismRightEye;
		public virtual string BothPrismRightEye 
		{ 
		    get
		    {
		        return this.bothPrismRightEye;
		    }
		    set
		    {
		        this.bothPrismRightEye = value;
		    }
		}
		
		private string bothPrismLeftEye;
		public virtual string BothPrismLeftEye 
		{ 
		    get
		    {
		        return this.bothPrismLeftEye;
		    }
		    set
		    {
		        this.bothPrismLeftEye = value;
		    }
		}
		
		private string bothAcuityRightEye;
		public virtual string BothAcuityRightEye 
		{ 
		    get
		    {
		        return this.bothAcuityRightEye;
		    }
		    set
		    {
		        this.bothAcuityRightEye = value;
		    }
		}
		
		private string bothAcuityLeftEye;
		public virtual string BothAcuityLeftEye 
		{ 
		    get
		    {
		        return this.bothAcuityLeftEye;
		    }
		    set
		    {
		        this.bothAcuityLeftEye = value;
		    }
		}
		
		private string farCenters;
		public virtual string FarCenters 
		{ 
		    get
		    {
		        return this.farCenters;
		    }
		    set
		    {
		        this.farCenters = value;
		    }
		}
		
		private string closeCenters;
		public virtual string CloseCenters 
		{ 
		    get
		    {
		        return this.closeCenters;
		    }
		    set
		    {
		        this.closeCenters = value;
		    }
		}
		
		private string bothCenters;
		public virtual string BothCenters 
		{ 
		    get
		    {
		        return this.bothCenters;
		    }
		    set
		    {
		        this.bothCenters = value;
		    }
		}
		
		private string farAcuity;
		public virtual string FarAcuity 
		{ 
		    get
		    {
		        return this.farAcuity;
		    }
		    set
		    {
		        this.farAcuity = value;
		    }
		}
		
		private string closeAcuity;
		public virtual string CloseAcuity 
		{ 
		    get
		    {
		        return this.closeAcuity;
		    }
		    set
		    {
		        this.closeAcuity = value;
		    }
		}
		
		private string bothAcuity;
		public virtual string BothAcuity 
		{ 
		    get
		    {
		        return this.bothAcuity;
		    }
		    set
		    {
		        this.bothAcuity = value;
		    }
		}
		
		private decimal closeSphericityCenters;
		public virtual decimal CloseSphericityCenters 
		{ 
		    get
		    {
		        return this.closeSphericityCenters;
		    }
		    set
		    {
		        this.closeSphericityCenters = value;
		    }
		}
		
		private Refractometry refractometry1;
		public virtual Refractometry Refractometry 
		{ 
		    get
		    {
		        return this.refractometry1;
		    }
		    set
		    {
		        this.refractometry1 = value;
		    }
		}
		
	}
}
