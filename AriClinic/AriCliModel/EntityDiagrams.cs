﻿#pragma warning disable 1591
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
using AriCliModel;
using Telerik.OpenAccess.Metadata;


namespace AriCliModel	
{	
	public partial class AriClinicContext : OpenAccessContext
	{
		private static string connectionStringName = "AriClinicContext";
			
		private static BackendConfiguration backend = GetBackendConfiguration();
		
			
		private static MetadataSource metadataSource = XmlMetadataSource.FromAssemblyResource("EntityDiagrams.rlinq");
	
		public AriClinicContext()
			:base(connectionStringName, backend, metadataSource)
		{ }
		
		public AriClinicContext(string connection)
			:base(connection, backend, metadataSource)
		{ }
	
		public AriClinicContext(BackendConfiguration backendConfiguration)
			:base(connectionStringName, backendConfiguration, metadataSource)
		{ }
			
		public AriClinicContext(string connection, MetadataSource metadataSource)
			:base(connection, backend, metadataSource)
		{ }
		
		public AriClinicContext(string connection, BackendConfiguration backendConfiguration, MetadataSource metadataSource)
			:base(connection, backendConfiguration, metadataSource)
		{ }
			
		public IQueryable<User> Users 
		{
	    	get
	    	{
	        	return this.GetAll<User>();
	    	}
		}
		
		public IQueryable<UserGroup> UserGroups 
		{
	    	get
	    	{
	        	return this.GetAll<UserGroup>();
	    	}
		}
		
		public IQueryable<HealthcareCompany> HealthcareCompanies 
		{
	    	get
	    	{
	        	return this.GetAll<HealthcareCompany>();
	    	}
		}
		
		public IQueryable<Telephone> Telephones 
		{
	    	get
	    	{
	        	return this.GetAll<Telephone>();
	    	}
		}
		
		public IQueryable<Email> Emails 
		{
	    	get
	    	{
	        	return this.GetAll<Email>();
	    	}
		}
		
		public IQueryable<Log> Logs 
		{
	    	get
	    	{
	        	return this.GetAll<Log>();
	    	}
		}
		
		public IQueryable<Process> Processes 
		{
	    	get
	    	{
	        	return this.GetAll<Process>();
	    	}
		}
		
		public IQueryable<Permission> Permissions 
		{
	    	get
	    	{
	        	return this.GetAll<Permission>();
	    	}
		}
		
		public IQueryable<Address> Addresses 
		{
	    	get
	    	{
	        	return this.GetAll<Address>();
	    	}
		}
		
		public IQueryable<Clinic> Clinics 
		{
	    	get
	    	{
	        	return this.GetAll<Clinic>();
	    	}
		}
		
		public IQueryable<Person> People 
		{
	    	get
	    	{
	        	return this.GetAll<Person>();
	    	}
		}
		
		public IQueryable<ServiceCategory> ServiceCategories 
		{
	    	get
	    	{
	        	return this.GetAll<ServiceCategory>();
	    	}
		}
		
		public IQueryable<TaxType> TaxTypes 
		{
	    	get
	    	{
	        	return this.GetAll<TaxType>();
	    	}
		}
		
		public IQueryable<Service> Services 
		{
	    	get
	    	{
	        	return this.GetAll<Service>();
	    	}
		}
		
		public IQueryable<Insurance> Insurances 
		{
	    	get
	    	{
	        	return this.GetAll<Insurance>();
	    	}
		}
		
		public IQueryable<InsuranceService> InsuranceServices 
		{
	    	get
	    	{
	        	return this.GetAll<InsuranceService>();
	    	}
		}
		
		public IQueryable<Patient> Patients 
		{
	    	get
	    	{
	        	return this.GetAll<Patient>();
	    	}
		}
		
		public IQueryable<Customer> Customers 
		{
	    	get
	    	{
	        	return this.GetAll<Customer>();
	    	}
		}
		
		public IQueryable<Policy> Policies 
		{
	    	get
	    	{
	        	return this.GetAll<Policy>();
	    	}
		}
		
		public IQueryable<Ticket> Tickets 
		{
	    	get
	    	{
	        	return this.GetAll<Ticket>();
	    	}
		}
		
		public IQueryable<Invoice> Invoices 
		{
	    	get
	    	{
	        	return this.GetAll<Invoice>();
	    	}
		}
		
		public IQueryable<InvoiceLine> InvoiceLines 
		{
	    	get
	    	{
	        	return this.GetAll<InvoiceLine>();
	    	}
		}
		
		public IQueryable<PaymentMethod> PaymentMethods 
		{
	    	get
	    	{
	        	return this.GetAll<PaymentMethod>();
	    	}
		}
		
		public IQueryable<Payment> Payments 
		{
	    	get
	    	{
	        	return this.GetAll<Payment>();
	    	}
		}
		
		public IQueryable<TaxWithholdingType> TaxWithholdingTypes 
		{
	    	get
	    	{
	        	return this.GetAll<TaxWithholdingType>();
	    	}
		}
		
		public IQueryable<Professional> Professionals 
		{
	    	get
	    	{
	        	return this.GetAll<Professional>();
	    	}
		}
		
		public IQueryable<Procedure> Procedures 
		{
	    	get
	    	{
	        	return this.GetAll<Procedure>();
	    	}
		}
		
		public IQueryable<AnestheticTicket> AnestheticTickets 
		{
	    	get
	    	{
	        	return this.GetAll<AnestheticTicket>();
	    	}
		}
		
		public IQueryable<AnestheticServiceNote> AnestheticServiceNotes 
		{
	    	get
	    	{
	        	return this.GetAll<AnestheticServiceNote>();
	    	}
		}
		
		public IQueryable<Parameter> Parameters 
		{
	    	get
	    	{
	        	return this.GetAll<Parameter>();
	    	}
		}
		
		public IQueryable<ServiceNote> ServiceNotes 
		{
	    	get
	    	{
	        	return this.GetAll<ServiceNote>();
	    	}
		}
		
		public IQueryable<Diary> Diaries 
		{
	    	get
	    	{
	        	return this.GetAll<Diary>();
	    	}
		}
		
		public IQueryable<AppointmentType> AppointmentTypes 
		{
	    	get
	    	{
	        	return this.GetAll<AppointmentType>();
	    	}
		}
		
		public IQueryable<AppointmentInfo> AppointmentInfos 
		{
	    	get
	    	{
	        	return this.GetAll<AppointmentInfo>();
	    	}
		}
		
		public IQueryable<Diagnostic> Diagnostics 
		{
	    	get
	    	{
	        	return this.GetAll<Diagnostic>();
	    	}
		}
		
		public IQueryable<External_invoice> External_invoices 
		{
	    	get
	    	{
	        	return this.GetAll<External_invoice>();
	    	}
		}
		
		public IQueryable<DiagnosticAssigned> DiagnosticAssigneds 
		{
	    	get
	    	{
	        	return this.GetAll<DiagnosticAssigned>();
	    	}
		}
		
		public static BackendConfiguration GetBackendConfiguration()
		{
			BackendConfiguration backend = new BackendConfiguration();
			backend.Backend = "mysql";
			return backend;
		}
	}
}
#pragma warning restore 1591
