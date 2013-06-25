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
	public partial class Patient : Person
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
		
		private string surname1;
		public virtual string Surname1 
		{ 
		    get
		    {
		        return this.surname1;
		    }
		    set
		    {
		        this.surname1 = value;
		    }
		}
		
		private string surname2;
		public virtual string Surname2 
		{ 
		    get
		    {
		        return this.surname2;
		    }
		    set
		    {
		        this.surname2 = value;
		    }
		}
		
		private DateTime bornDate;
		public virtual DateTime BornDate 
		{ 
		    get
		    {
		        return this.bornDate;
		    }
		    set
		    {
		        this.bornDate = value;
		    }
		}
		
		private string sex;
		public virtual string Sex 
		{ 
		    get
		    {
		        return this.sex;
		    }
		    set
		    {
		        this.sex = value;
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
		
		private DateTime lastUpdate;
		public virtual DateTime LastUpdate 
		{ 
		    get
		    {
		        return this.lastUpdate;
		    }
		    set
		    {
		        this.lastUpdate = value;
		    }
		}
		
		private string insuranceInformation;
		public virtual string InsuranceInformation 
		{ 
		    get
		    {
		        return this.insuranceInformation;
		    }
		    set
		    {
		        this.insuranceInformation = value;
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
		
		private DateTime openDate;
		public virtual DateTime OpenDate 
		{ 
		    get
		    {
		        return this.openDate;
		    }
		    set
		    {
		        this.openDate = value;
		    }
		}
		
		private Customer customer;
		public virtual Customer Customer 
		{ 
		    get
		    {
		        return this.customer;
		    }
		    set
		    {
		        this.customer = value;
		    }
		}
		
		private Clinic clinic;
		public virtual Clinic Clinic 
		{ 
		    get
		    {
		        return this.clinic;
		    }
		    set
		    {
		        this.clinic = value;
		    }
		}
		
		private IList<Treatment> treatments = new List<Treatment>();
		public virtual IList<Treatment> Treatments 
		{ 
		    get
		    {
		        return this.treatments;
		    }
		}
		
		private IList<ExaminationAssigned> examinationAssigneds = new List<ExaminationAssigned>();
		public virtual IList<ExaminationAssigned> ExaminationAssigneds 
		{ 
		    get
		    {
		        return this.examinationAssigneds;
		    }
		}
		
		private IList<LabTestAssigned> labTestAssigneds1 = new List<LabTestAssigned>();
		public virtual IList<LabTestAssigned> LabTestAssigneds 
		{ 
		    get
		    {
		        return this.labTestAssigneds1;
		    }
		}
		
		private IList<ProcedureAssigned> procedureAssigneds = new List<ProcedureAssigned>();
		public virtual IList<ProcedureAssigned> ProcedureAssigneds 
		{ 
		    get
		    {
		        return this.procedureAssigneds;
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
		
		private IList<DiagnosticAssigned> diagnosticAssigneds = new List<DiagnosticAssigned>();
		public virtual IList<DiagnosticAssigned> DiagnosticAssigneds 
		{ 
		    get
		    {
		        return this.diagnosticAssigneds;
		    }
		}
		
		private IList<PreviousMedicalRecord> previousMedicalRecords = new List<PreviousMedicalRecord>();
		public virtual IList<PreviousMedicalRecord> PreviousMedicalRecords 
		{ 
		    get
		    {
		        return this.previousMedicalRecords;
		    }
		}
		
		private IList<BackPersonal> backPersonals = new List<BackPersonal>();
		public virtual IList<BackPersonal> BackPersonals 
		{ 
		    get
		    {
		        return this.backPersonals;
		    }
		}
		
		private IList<BackFamily> backFamilies = new List<BackFamily>();
		public virtual IList<BackFamily> BackFamilies 
		{ 
		    get
		    {
		        return this.backFamilies;
		    }
		}
		
		private IList<BackGinecology> backGinecologies = new List<BackGinecology>();
		public virtual IList<BackGinecology> BackGinecologies 
		{ 
		    get
		    {
		        return this.backGinecologies;
		    }
		}
		
		private IList<AppointmentInfo> appointmentInfos = new List<AppointmentInfo>();
		public virtual IList<AppointmentInfo> AppointmentInfos 
		{ 
		    get
		    {
		        return this.appointmentInfos;
		    }
		}
		
		private IList<Request> requests = new List<Request>();
		public virtual IList<Request> Requests 
		{ 
		    get
		    {
		        return this.requests;
		    }
		}
		
	}
}
