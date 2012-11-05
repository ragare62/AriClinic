using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriCliModel;
using Telerik.OpenAccess;
using System.Security.Cryptography;

namespace AriCliModel
{
    public static partial class CntAriCli
    {
        public static bool NullDateTime(DateTime dtt)
        {
            string s = String.Format("{0:dd/MM/yyyy HH:mm:ss}", dtt);
            if (s == "01/01/0001 00:00:00")
                return true;
            else
                return false;
        }

        #region Criptography
        public static string GetHashCode(string password)
        {
            byte[] tmpSource = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

            return ByteArrayToString(tmpHash);
        }

        private static string ByteArrayToString(byte[] arrInput)
        {
            int i;
            StringBuilder sOutput = new StringBuilder(arrInput.Length);
            for (i = 0; i < arrInput.Length - 1; i++)
            {
                sOutput.Append(arrInput[i].ToString("X2"));
            }
            return sOutput.ToString();
        }

        #endregion Criptography
        #region User related
        /// <summary>
        /// Checks if there is a user with an specific
        /// login and password
        /// </summary>
        /// <param name="password"> user pasword </param>
        /// <param name="login"> user login </param>
        /// <param name="ctx"> openaccess context </param>
        /// <returns> a user object if password </returns>
        public static User Login(string password, string login, AriClinicContext ctx)
        {
            // first: check if the user exists
            User user = (from u in ctx.Users
                         where u.Login == login
                         select u).FirstOrDefault<User>();
            if (user == null)
                return null; // user doesn't exists
            if (user.Password != GetHashCode(password))
                return null; // incorrect password
            return user;
        }

        /// <summary>
        /// Encrypts a plain text in the password atribute
        /// </summary>
        /// <param name="user"> user to assing password</param>
        /// <param name="plain"> password in plain text</param>
        /// <returns> user with password assigned </returns>
        public static User EncryptPassword(User user, string plain)
        {
            user.Password = GetHashCode(plain);
            return user;
        }

        #endregion User realted
        /// <summary>
        /// Get Health Company information
        /// </summary>
        /// <param name="ctx"> OpenAccess context</param>
        /// <returns> HelthCareCompany object </returns>
        public static HealthcareCompany GetHealthCompany(AriClinicContext ctx)
        {
            var rs = from h in ctx.HealthcareCompanies
                     select h;
            return rs.FirstOrDefault<HealthcareCompany>();
        }

        /// <summary>
        /// Write the application log 
        /// </summary>
        /// <param name="user"> user that causes the log item</param>
        /// <param name="stamp"> event date and time</param>
        /// <param name="remoteAddress"> remote IP </param>
        /// <param name="page"> what page is implied </param>
        /// <param name="action"> what action has been done </param>
        /// <param name="ctx"> openaccess context </param>
        public static void WriteLog(User user, DateTime stamp, string remoteAddress, string page, string action, AriClinicContext ctx)
        {
            Log lg = new Log()
            {
                User = user,
                Stamp = stamp,
                RemoteAddress = remoteAddress,
                Page = page,
                Action = action
            };
            ctx.Add(lg);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Verify that in the permission table all the process have an entry
        /// </summary>
        /// <param name="ug"> user group to wich the permissions are assigned</param>
        /// <param name="ctx"> openaccess context </param>
        public static void VerifyPermissions(UserGroup ug, AriClinicContext ctx)
        {
            foreach (Process pr in ctx.Processes)
            {
                Permission per = (from p in ctx.Permissions
                                  where p.UserGroup.UserGroupId == ug.UserGroupId &&
                                        p.Process.ProcessId == pr.ProcessId
                                  select p).FirstOrDefault<Permission>();
                if (per == null)
                {
                    // permission doesn't exists for this user group
                    // we create one.
                    per = new Permission();
                    per.UserGroup = ug;
                    per.Process = pr;
                    // default permissions are asigned.
                    per.View = true;
                    per.Create = false;
                    per.Modify = false;
                    per.Execute = false;
                    ctx.Add(per);
                }
            }
            ctx.SaveChanges();
        }

        /// <summary>
        /// Returns a list of objects in the format requierd by RadListTree control
        /// </summary>
        /// <param name="ug"></param>
        /// <returns></returns>
        public static IList<PermissionView> GetPermissionsViews(UserGroup ug)
        {
            IList<PermissionView> perviews = new List<PermissionView>();
            foreach (Permission per in ug.Permissions)
            {
                PermissionView pw = new PermissionView();
                pw.PermissionId = per.PermissionId;
                pw.Name = per.Process.Name;
                pw.ProcessId = per.Process.ProcessId;
                if (per.Process.ParentProcess != null)
                    pw.ParentProcessId = per.Process.ParentProcess.ProcessId;
                else
                    pw.ParentProcessId = 0;
                pw.View = per.View;
                pw.Create = per.Create;
                pw.Modify = per.Modify;
                pw.Execute = per.Execute;
                perviews.Add(pw);
            }
            return perviews;
        }

        /// <summary>
        /// Obtain the permisson that an specific group has over a process
        /// </summary>
        /// <param name="ug"> User group </param>
        /// <param name="pr"> Process</param>
        /// <param name="ctx"> Openaccess context</param>
        /// <returns> Permission or null</returns>
        public static Permission GetPermission(UserGroup ug, Process pr, AriClinicContext ctx)
        {
            Permission per = (from p in ctx.Permissions
                              where p.UserGroup.UserGroupId == ug.UserGroupId &&
                                    p.Process.ProcessId == pr.ProcessId
                              select p).FirstOrDefault<Permission>();
            return per;
        }

        public static Clinic GetClinic(int id, AriClinicContext ctx)
        {
            return (from c in ctx.Clinics
                    where c.ClinicId == id
                    select c).FirstOrDefault<Clinic>();
        }

        public static IList<Clinic> GetClinics(AriClinicContext ctx)
        {
            return (from c in ctx.Clinics
                    select c).ToList<Clinic>();
        }

        public static ServiceCategory GetServiceCategory(int id, AriClinicContext ctx)
        {
            return (from sc in ctx.ServiceCategories
                    where sc.ServiceCategoryId == id
                    select sc).FirstOrDefault<ServiceCategory>();
        }

        public static TaxType GetTaxType(int id, AriClinicContext ctx)
        {
            return (from t in ctx.TaxTypes
                    where t.TaxTypeId == id
                    select t).FirstOrDefault<TaxType>();
        }

        public static Service GetService(int id, AriClinicContext ctx)
        {
            return (from s in ctx.Services
                    where s.ServiceId == id
                    select s).FirstOrDefault<Service>();
        }

        public static Insurance GetInsurance(int id, AriClinicContext ctx)
        {
            return (from i in ctx.Insurances
                    where i.InsuranceId == id
                    select i).FirstOrDefault<Insurance>();
        }

        public static String GetInsuranceData(Patient patient, AriClinicContext ctx)
        {
            string insuranceData = "";
            int policyInForceId = 0;
            // policy in force
            Policy policy = CntAriCli.GetPolicyInForce(patient, DateTime.Now, ctx);
            if (policy == null)
                insuranceData = "[*]";
            else
            {
                insuranceData = string.Format("[ IG:{0} PN:{1} ]", policy.Insurance.Name, policy.PolicyNumber);
                policyInForceId = policy.PolicyId;
            }
            // policies but in force
            foreach (Policy plcy in CntAriCli.GetPolicies(patient, ctx))
            {
                if (plcy != null && (plcy.PolicyId != policyInForceId))
                {
                    insuranceData = string.Format("{0} / IG:{1} PN:{2} /", 
                                        insuranceData, plcy.Insurance.Name, plcy.PolicyNumber);
                }
            }
            return insuranceData;
        }

        public static InsuranceService GetInsuranceService(int id, AriClinicContext ctx)
        {
            return (from inser in ctx.InsuranceServices
                    where inser.InsuranceServiceId == id
                    select inser).FirstOrDefault<InsuranceService>();
        }

        public static InsuranceService GetInsuranceService(int id, Insurance insurance, AriClinicContext ctx)
        {
            return (from i in ctx.InsuranceServices
                    where i.InsuranceServiceId == id &&
                          i.Insurance.InsuranceId == insurance.InsuranceId
                    select i).FirstOrDefault<InsuranceService>();
        }

        public static IList<Patient> GetPatients(AriClinicContext ctx)
        {
            return (from p in ctx.Patients
                    orderby p.FullName
                    select p).ToList<Patient>();
        }

        public static IList<Patient> GetPatients(Insurance insurance, AriClinicContext ctx)
        {
            var rs = from p in ctx.Policies
                     where p.Insurance.InsuranceId == insurance.InsuranceId
                     select p;
            IList<Patient> lp = new List<Patient>();
            foreach (Policy p in rs)
            {
                Patient pat = (from pt in ctx.Patients
                               where pt.Customer.PersonId == p.Customer.PersonId
                               select pt).FirstOrDefault<Patient>();
                if (pat != null) lp.Add(pat);
            }
            return lp;
        }
            
            

        public static Patient GetPatient(int id, AriClinicContext ctx)
        {
            return (from p in ctx.Patients
                    where p.PersonId == id
                    select p).FirstOrDefault<Patient>();
        }
        public static Patient GetPatientByOftId(int oftId, AriClinicContext ctx)
        {
            return (from p in ctx.Patients
                    where p.OftId == oftId
                    select p).FirstOrDefault<Patient>();
        }
        public static int CalulatedAge(DateTime BornDate)
        {
            int age = 0;
            if (String.Format("{0:dd/MM/yy}", BornDate) != "01/01/01")
            {
                // Calculate age from born date
                age = DateTime.Now.Year - BornDate.Year;
                // Substract a year if date is before birthday
                if (DateTime.Now.Month < BornDate.Month ||
                    (DateTime.Now.Month == BornDate.Month && DateTime.Now.Day < BornDate.Day))
                    age--;
            }
            return age;
        }

        public static Policy GetPolicy(int id, AriClinicContext ctx)
        {
            return (from p in ctx.Policies
                    where p.PolicyId == id
                    select p).FirstOrDefault<Policy>();
        }

        public static Policy GetPolicyInForce(Patient patient, DateTime dt, AriClinicContext ctx)
        {
            Policy policy = null;
            policy = (from p in patient.Customer.Policies
                      where p.BeginDate <= dt && p.EndDate >= dt
                      select p).FirstOrDefault();
            return policy;
        }

        public static IList<Policy> GetPolicies(Patient patient, AriClinicContext ctx)
        {
            return patient.Customer.Policies.ToList<Policy>();
        }

        public static Ticket GetTicket(int id, AriClinicContext ctx)
        {
            return (from t in ctx.Tickets
                    where t.TicketId == id
                    select t).FirstOrDefault<Ticket>();
        }

        public static DateTime? IsDateNull(DateTime? dt)
        {
            if (String.Format("{0:dd/MM/yyyy}", dt) == "01/01/0001")
                return null;
            else
                return dt;
        }

        public static bool OaDateNull(DateTime? dt)
        {
            bool res = true;
            if (dt != null)
            {
                if (String.Format("{0:dd/MM/yyyy}", dt) != "01/01/0001") res = false;
            }
            return res;
        }

        public static string DateNullFormat(DateTime dt)
        {
            DateTime? dt2 = IsDateNull(dt);
            if (dt2 == null)
                return "";
            else
                return String.Format("{0:dd/MM/yyyy}", dt2);
        }

        public static IList<Ticket> GetTickets(bool notPaid, AriClinicContext ctx)
        {
            if (notPaid)
            {
                var rs = from t in ctx.Tickets
                         orderby t.TicketDate descending
                         where t.Amount != t.Paid
                         select t;
                return rs.ToList<Ticket>();
            }
            else
            {
                return (from t in ctx.Tickets
                        orderby t.TicketDate descending
                        select t).ToList<Ticket>();
            }
        }

        public static IList<Ticket> GeTickets(bool notPaid, Customer cus, AriClinicContext ctx)
        {
            var rs2 = from t in ctx.Tickets
                      orderby t.TicketDate descending
                      where t.Policy.Customer.PersonId == cus.PersonId &&
                            t.Amount > t.Paid
                      select t;
            return rs2.ToList<Ticket>();
        }

        public static IList<Ticket> GetTickets(DateTime fromDate, DateTime toDate, int insuranceId, string type, AriClinicContext ctx)
        {
            if (insuranceId != 0)
            {
                if (type.Equals("P"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   t.Policy.Insurance.InsuranceId == insuranceId &&
                                   (t.Amount == t.Paid)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("NP"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   t.Policy.Insurance.InsuranceId == insuranceId &&
                                   (t.Amount != t.Paid)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("C"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   t.Policy.Insurance.InsuranceId == insuranceId &&
                                   (t.Checked == true)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("SC"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   t.Policy.Insurance.InsuranceId == insuranceId &&
                                   (t.Checked == false)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else
                {
                    return new List<Ticket>();
                }
            }
            else
            {
                if (type == "P")
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   (t.Amount == t.Paid)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("NP"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   (t.Amount != t.Paid)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("C"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   (t.Checked == true)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else if (type.Equals("SC"))
                {
                    var rs = from t in ctx.Tickets
                             orderby t.TicketDate descending
                             where t.TicketDate >= fromDate &&
                                   t.TicketDate <= toDate &&
                                   (t.Checked == false)
                             select t;
                    return rs.ToList<Ticket>();
                }
                else
                {
                    return new List<Ticket>();
                }
            }
        }

        public static User GetUser(int id, AriClinicContext ctx)
        {
            return (from u in ctx.Users
                    where u.UserId == id
                    select u).FirstOrDefault<User>();
        }

        public static Invoice GetInvoice(int invoiceId, AriClinicContext ctx)
        {
            return (from inv in ctx.Invoices
                    where inv.InvoiceId == invoiceId
                    select inv).FirstOrDefault<Invoice>();
        }

        public static ProfessionalInvoice GetProfessionalInvoice(int invoiceId, AriClinicContext ctx)
        {
            return (from inv in ctx.ProfessionalInvoices
                    where inv.InvoiceId == invoiceId
                    select inv).FirstOrDefault<ProfessionalInvoice>();
        }

        public static InvoiceLine GetInvoiceLine(int invoiceLineId, AriClinicContext ctx)
        {
            return (from il in ctx.InvoiceLines
                    where il.InvoiceLineId == invoiceLineId
                    select il).FirstOrDefault<InvoiceLine>();
        }

        public static ProfessionalInvoiceLine GetProfessionalInvoiceLine(int invoiceLineId, AriClinicContext ctx)
        {
            return (from il in ctx.ProfessionalInvoiceLines
                    where il.InvoiceLineId == invoiceLineId
                    select il).FirstOrDefault<ProfessionalInvoiceLine>();
        }

        public static IList<Ticket> GetTicketsNotInvoiced(AriClinicContext ctx)
        {
            var rs = from t in ctx.Tickets
                     where t.InvoiceLines.Count == 0
                     select t;
            return rs.ToList<Ticket>();
        }

        public static IList<Ticket> GetTicketsNotInvoiced(Customer cus, AriClinicContext ctx)
        {
            return (from t in ctx.Tickets
                    where t.Policy.Customer.PersonId == cus.PersonId &&
                          t.InvoiceLines.Count == 0
                    select t).ToList<Ticket>();
        }

        public static Customer GetCustomer(int? customerId, AriClinicContext ctx)
        {
            return (from c in ctx.Customers
                    where c.PersonId == customerId
                    select c).FirstOrDefault<Customer>();
        }
        public static Customer GetCustomerByOftId(int oftId, AriClinicContext ctx)
        {
            return (from c in ctx.Customers
                    where c.OftId == oftId
                    select c).FirstOrDefault<Customer>();
        }
        public static IList<Customer> GetCustomers(AriClinicContext ctx)
        {
            return (from c in ctx.Customers
                    orderby c.FullName
                    select c).ToList<Customer>();
        }

        public static void UpdateCustomerRelatedData(Patient pat, AriClinicContext ctx)
        {
            Customer cus = pat.Customer;
            // update comercial name
            cus.ComercialName = pat.FullName;
            cus.FullName = cus.ComercialName;
            // update related address
            // primary address exists
            Address adr = (from a in cus.Addresses
                           where a.Type == "Primary"
                           select a).FirstOrDefault<Address>();
            if (adr == null)
            {
                // we assign the address of patient as customer address 
                Address adrpat = (from a in pat.Addresses
                                  where a.Type == "Primary"
                                  select a).FirstOrDefault<Address>();
                if (adrpat != null)
                {
                    adr = new Address();
                    adr.Street = adrpat.Street;
                    adr.City = adrpat.City;
                    adr.PostCode = adrpat.PostCode;
                    adr.Street2 = adrpat.Street2;
                    adr.Province = adrpat.Province;
                    adr.Type = adrpat.Type;
                    adr.Country = adrpat.Country;
                    adr.Person = cus;
                    cus.Addresses.Add(adr);
                }
            }
        }

        public static Decimal GetInvoiceTotal(Invoice inv)
        {
            Decimal total = 0;
            foreach (InvoiceLine invl in inv.InvoiceLines)
            {
                total += invl.Amount;
            }
            return total;
        }

        public static Decimal GetProfessionalInvoiceTotal(ProfessionalInvoice inv)
        {
            Decimal total = 0;
            foreach (ProfessionalInvoiceLine invl in inv.ProfessionalInvoiceLines)
            {
                total += invl.Amount;
            }
            return total;
        }

        public static int GetNextInvoiceNumber(string serial, int year, AriClinicContext ctx)
        {
            int v = (from inv in ctx.Invoices
                     where inv.Serial == serial &&
                           inv.Year == year
                     select inv.InvoiceNumber).Max();
            return ++v;
        }

        public static int GetNextProfessionalInvoiceNumber(Professional prof, int year, AriClinicContext ctx)
        {
            if (prof.ProfessionalInvoices.Where(x => x.Year == year).Count() > 0)
            {
                int v = (from inv in prof.ProfessionalInvoices
                         where inv.Year == year
                         select inv.InvoiceNumber).Max();

                return ++v;
            }
            else
                return 1;
        }

        public static bool DeleteInvoice(Invoice inv, AriClinicContext ctx)
        {
            // Last invoice number?
            int n = GetNextInvoiceNumber(inv.Serial, inv.Year, ctx) - 1;
            // only the last invoice can be deleted
            if (inv.InvoiceNumber != n)
                return false;

            // erase possible service note relation
            if (inv.ServiceNotes != null && inv.ServiceNotes.Count > 0)
            {
                for (int i = 0; i < inv.ServiceNotes.Count; i++)
                {
                    inv.ServiceNotes.ElementAt(i).Invoice = null;
                }
            }
            else if (inv.AnestheticServiceNotes != null && inv.AnestheticServiceNotes.Count > 0)
            {
                for (int i = 0; i < inv.AnestheticServiceNotes.Count; i++)
                {
                    inv.AnestheticServiceNotes.ElementAt(i).Invoice = null;
                }
            }
            // delete lines
            ctx.Delete(inv.InvoiceLines);

            // delete invoice
            ctx.Delete(inv);

            return true;
        }

        public static bool DeleteProfessionalInvoice(ProfessionalInvoice inv, AriClinicContext ctx)
        {
            // Last invoice number?
            int n = GetNextProfessionalInvoiceNumber(inv.Professional, inv.Year, ctx) - 1;
            // only the last invoice can be deleted
            if (inv.InvoiceNumber != n)
                return false;

            // delete lines
            ctx.Delete(inv.ProfessionalInvoiceLines);

            // delete invoice
            ctx.Delete(inv);

            return true;
        }

        public static bool CorrectInvoiceDate(DateTime date, AriClinicContext ctx)
        {
            var rs = from i in ctx.Invoices
                     where i.InvoiceDate > date
                     select i;
            if (rs.Count() > 0)
                return false;
            else
                return true;
        }

        public static bool CorrectProfessionalInvoiceDate(DateTime date, Professional prof)
        {
            var rs = from i in prof.ProfessionalInvoices
                     where i.InvoiceDate > date
                     select i;
            if (rs.Count() > 0)
                return false;
            else
                return true;
        }

        public static PaymentMethod GetPaymentMethod(int paymentMethodId, AriClinicContext ctx)
        {
            return (from pm in ctx.PaymentMethods
                    where pm.PaymentMethodId == paymentMethodId
                    select pm).FirstOrDefault<PaymentMethod>();
        }

        public static GeneralPayment GetGeneralPayment(int id, AriClinicContext ctx)
        {
            return (from gp in ctx.GeneralPayments
                    where gp.GeneralPaymentId == id
                    select gp).FirstOrDefault<GeneralPayment>();
        }

        public static Payment GetPayment(int paymentId, AriClinicContext ctx)
        {
            return (from p in ctx.Payments
                    where p.PaymentId == paymentId
                    select p).FirstOrDefault<Payment>();
        }

        public static void UpdateTicketPayments(Ticket tck, AriClinicContext ctx)
        {
            decimal total = 0;
            foreach (Payment pay in tck.Payments)
            {
                total += pay.Amount;
            }
            tck.Paid = total;
            ctx.SaveChanges();
        }

        public static bool PaymentControl(Ticket tck, Payment pay, decimal amount)
        {
            decimal thisAmount = 0;
            if (pay != null)
                thisAmount = pay.Amount;
            if (((tck.Paid - thisAmount) + amount) > tck.Amount)
                return false;
            else
                return true;
        }
        public static IList<GeneralPayment> GetGeneralPayments(AriClinicContext ctx)
        {
            return (from gp in ctx.GeneralPayments
                    select gp).ToList<GeneralPayment>();
        }
        public static IList<GeneralPayment> GetGeneralPayments(Customer cus, AriClinicContext ctx)
        {
            return (from gp in ctx.GeneralPayments
                    select gp).ToList<GeneralPayment>();
        }
        public static IList<Payment> GetPayments(Customer cus, AriClinicContext ctx)
        {
            var rs = from p in ctx.Payments
                     orderby p.PaymentDate descending
                     where p.Ticket.Policy.Customer.PersonId == cus.PersonId
                     select p;
            return rs.ToList<Payment>();
        }

        public static IList<Ticket> GetTickets(DateTime fromDate, DateTime toDate, int insuranceId, AriClinicContext ctx)
        {
            if (insuranceId == 0)
            {
                var rs = from t in ctx.Tickets
                         where t.TicketDate >= fromDate &&
                               t.TicketDate <= toDate
                         select t;
                return rs.ToList<Ticket>();
            }
            else
            {
                var rs = from t in ctx.Tickets
                         where t.TicketDate >= fromDate &&
                               t.TicketDate <= toDate &&
                               t.Policy.Insurance.InsuranceId == insuranceId
                         select t;
                return rs.ToList<Ticket>();
            }
        }

        public static IList<Ticket> GetTickets(DateTime fromDate, DateTime toDate, int insuranceId, AriClinicContext ctx, int noVoucher)
        {
            IList<Ticket> mTickets = GetTickets(fromDate, toDate, insuranceId, ctx);
            if (noVoucher != 0)
            {
                mTickets = (from t in mTickets where t.Checked == false select t).ToList<Ticket>();
            }
            return mTickets;
        }

        public static IList<Payment> GetPayments(DateTime fromDate, DateTime toDate, int clinicId, AriClinicContext ctx)
        {
            if (clinicId == 0)
            {
                var rs = from p in ctx.Payments
                         orderby p.PaymentDate descending
                         where p.PaymentDate >= fromDate &&
                               p.PaymentDate <= toDate
                         select p;
                return rs.ToList<Payment>();
            }
            else
            {
                var rs = from p in ctx.Payments
                         orderby p.PaymentDate descending
                         where p.PaymentDate >= fromDate &&
                               p.PaymentDate <= toDate &&
                               p.Ticket.Clinic.ClinicId == clinicId
                         select p;
                return rs.ToList<Payment>();
            }
        }

        public static TaxWithholdingType GetTaxWithholdingType(int id, AriClinicContext ctx)
        {
            return (from tw in ctx.TaxWithholdingTypes
                    where tw.TaxWithholdingTypeId == id
                    select tw).FirstOrDefault<TaxWithholdingType>();
        }

        public static Professional GetProfessional(int? id, AriClinicContext ctx)
        {
            return (from p in ctx.Professionals
                    where p.PersonId == id
                    select p).FirstOrDefault<Professional>();
        }

        public static Procedure GetProcedure(int id, AriClinicContext ctx)
        {
            return (from p in ctx.Procedures
                    where p.ProcedureId == id
                    select p).FirstOrDefault<Procedure>();
        }

        public static AnestheticServiceNote GetAnestheticServiceNote(int id, AriClinicContext ctx)
        {
            return (from ans in ctx.AnestheticServiceNotes
                    where ans.AnestheticServiceNoteId == id
                    select ans).FirstOrDefault<AnestheticServiceNote>();
        }

        public static Parameter GetParameter(AriClinicContext ctx)
        {
            Parameter par = (from p in ctx.Parameters
                             select p).FirstOrDefault<Parameter>();
            if (par == null)
            {
                par = new Parameter();
                ctx.Add(par);
                ctx.SaveChanges();
            }
            return par;
        }

        public static void CheckAnestheticServiceNoteTickets(AnestheticServiceNote ansn, AriClinicContext ctx, IList<SaveCheck> lschk)
        {
            // Read parameters
            AriCliModel.Parameter parameter = GetParameter(ctx);
            Service painPump = parameter.PainPump;
            bool hRisk = ansn.Chk3;
            //
            AnestheticTicket anstk = null;
            // Do we need check pain pump?
            if (painPump != null && ansn.Chk1)
            {
                // Is there a pain pump assigned?
                var rs = from t in ansn.AnestheticTickets
                         where t.InsuranceService.Service.ServiceId == painPump.ServiceId
                         select t;
                if (rs.Count() == 0)
                {
                    // Does this customer have a primary policy with that service?
                    Policy pol = PrimaryPolicy(ansn.Customer);
                    if (pol == null)
                    {
                        throw new AriCliException(1, "There isn't a primary policy for this customer");
                    }
                    // Does this policy (insurance) includes a pain pump service?
                    InsuranceService ins = PolicyIncludesService(pol, painPump);
                    if (ins == null)
                    {
                        throw new AriCliException(2, "The insurance company have not the pain pump service assigned");
                    }
                    // Everything seems ok, we can add the ticket
                    anstk = new AnestheticTicket()
                    {
                        TicketDate = ansn.ServiceNoteDate,
                        Description = String.Format("{0} ({1})", ansn.Procedures[0].Name, ins.Service.Name),
                        Amount = ins.Price,
                        Policy = pol,
                        InsuranceService = ins,
                        User = ansn.User,
                        Clinic = ansn.Clinic,
                        Professional = ansn.Professional,
                        Surgeon = ansn.Surgeon,
                        Procedure = ansn.Procedures[0],
                        AnestheticServiceNote = ansn
                    };
                    if (ansn.Chk2)
                    {
                        anstk.Checked = true;
                    }
                    else
                    {
                        anstk.Checked = CntAriCli.IsItInChecks(anstk, lschk);
                    }
                    if (hRisk) anstk.Amount = anstk.Amount * 1.5M; // increase 50%
                    ctx.Add(anstk);

                    ctx.SaveChanges();
                }
            }
            // Do we need check procedure - service link?
            if (parameter.UseNomenclator)
            {
                bool multi = false;
                foreach (Procedure p in ansn.Procedures)
                {
                    AddAutomaticTicket(ansn, p, ctx, multi, lschk);
                    multi = true;
                }
            }
        }

        public static Policy PrimaryPolicy(Customer cus)
        {
            return (from p in cus.Policies
                    where p.Type == "Primary"
                    select p).FirstOrDefault<Policy>();
        }

        public static InsuranceService PolicyIncludesService(Policy pol, Service ser)
        {
            return (from i in pol.Insurance.InsuranceServices
                    where i.Service.ServiceId == ser.ServiceId
                    select i).FirstOrDefault<InsuranceService>();
        }

        public static ServiceNote GetServiceNote(int id, AriClinicContext ctx)
        {
            return (from sn in ctx.ServiceNotes
                    where sn.ServiceNoteId == id
                    select sn).FirstOrDefault<ServiceNote>();
        }

        public static void DeleteServiceNote(ServiceNote sn, AriClinicContext ctx)
        {
            // First delete related records.
            foreach (GeneralPayment gp in sn.GeneralPayments)
            {
                GeneralPaymentDelete(gp, ctx);
            }
            ctx.Delete(sn.Tickets);
            ctx.Delete(sn);
            ctx.SaveChanges();
        }

        public static int InvoiceServiceNote(ServiceNote sn, AriClinicContext ctx)
        {
            // it there's an invoice related to this service 
            // we do nothing and return 0
            if (sn.Invoice != null)
                return 0;

            // invoice
            Invoice i = new Invoice();
            Decimal total = 0;
            i.Customer = sn.Customer;
            sn.Invoice = i; // this make the relationship
            i.InvoiceDate = sn.ServiceNoteDate;
            i.Serial = CntAriCli.GetHealthCompany(ctx).InvoiceSerial;
            i.Year = i.InvoiceDate.Year;
            i.InvoiceNumber = CntAriCli.GetNextInvoiceNumber(i.Serial, i.Year, ctx);
            ctx.Add(i);

            // invoice lines
            foreach (Ticket t in sn.Tickets)
            {
                InvoiceLine il = new InvoiceLine();
                il.Invoice = i;
                il.Ticket = t;
                il.Description = t.Description;
                il.Amount = t.Amount;
                il.TaxType = t.InsuranceService.Service.TaxType;
                il.TaxPercentage = il.TaxType.Percentage;
                total += il.Amount;
                ctx.Add(il);
            }
            i.Total = total;

            // save the work and return id
            ctx.SaveChanges();
            return i.InvoiceId;
        }

        public static bool ContainsTicketsInvoiced(ServiceNote sn, AriClinicContext ctx)
        {
            foreach (Ticket t in sn.Tickets)
            {
                if (t.InvoiceLines.Count > 0)
                    return true;
            }
            return false;
        }

        public static void AddAutomaticTicket(AnestheticServiceNote ansn, Procedure proc, AriClinicContext ctx, bool multi, IList<SaveCheck> lschk)
        {
            // Does this customer have a primary policy with that service?
            Policy pol = PrimaryPolicy(ansn.Customer);
            bool hRisk = ansn.Chk3;
            if (pol == null)
            {
                throw new AriCliException(1, "There isn't a primary policy for this customer");
            }
            // Does this policy includes related (from procedure) services
            InsuranceService ins = PolicyIncludesService(pol, proc.Service);
            if (ins == null)
            {
                throw new AriCliException(3, "The insurance company have not the nomenclator service assigned");
            }
            // Everything seems ok, we can add anesthetic ticket
            AnestheticTicket anstk = new AnestheticTicket()
            {
                TicketDate = ansn.ServiceNoteDate,
                Description = String.Format("{0} ({1})", proc.Name, ins.Service.Name),
                Amount = ins.Price,
                Policy = pol,
                InsuranceService = ins,
                User = ansn.User,
                Clinic = ansn.Clinic,
                Professional = ansn.Professional,
                Surgeon = ansn.Surgeon,
                Procedure = proc,
                AnestheticServiceNote = ansn
            };
            if (ansn.Chk2)
            {
                anstk.Checked = true;
            }
            else
            {
                anstk.Checked = CntAriCli.IsItInChecks(anstk, lschk);
            }
            if (multi)
            {
                anstk.Amount = anstk.Amount / 2;
                anstk.Comments = "-50%";
            }
            if (hRisk) anstk.Amount = anstk.Amount * 1.5M; // high risk increase 50%
            ctx.Add(anstk);
            ctx.SaveChanges();
        }

        public static IList<Ticket> GetTicketsByProfessional(DateTime fromDate, DateTime toDate, string ProfessionalId, AriClinicContext ctx)
        {
            int idProf = int.Parse(ProfessionalId);
            return (from t in ctx.Tickets
                    where t.TicketDate >= fromDate && t.TicketDate <= toDate && t.Professional.PersonId == idProf
                    select t).Distinct().ToList<Ticket>();
        }

        public static IList<Ticket> GetTickets(DateTime fromDate, DateTime toDate, AriClinicContext ctx)
        {
            List<Ticket> tickets = (from t in ctx.Tickets
                                    where t.TicketDate >= fromDate && t.TicketDate <= toDate
                                    select t).ToList<Ticket>();

            return tickets;
        }

        public static IList<AnestheticTicket> GetTicketsByCirujano(DateTime fromDate, DateTime toDate, string ProfessionalId, AriClinicContext ctx)
        {
            int idProf = int.Parse(ProfessionalId);
            return (from t in ctx.AnestheticTickets
                    where t.TicketDate >= fromDate && t.TicketDate <= toDate && t.Surgeon.PersonId == idProf
                    select t).Distinct().ToList<AnestheticTicket>();
        }

        public static IList<AnestheticTicket> GetTicketsAnestesicos(DateTime fromDate, DateTime toDate, AriClinicContext ctx)
        {
            List<AnestheticTicket> tickets = (from t in ctx.AnestheticTickets
                                              where t.TicketDate >= fromDate && t.TicketDate <= toDate
                                              select t).ToList<AnestheticTicket>();

            return tickets;
        }

        public static void DeleteAnestheticServiceNote(AnestheticServiceNote ansn, AriClinicContext ctx)
        {
            foreach (AnestheticTicket at in ansn.AnestheticTickets)
                ctx.Delete(at);

            ctx.Delete(ansn);
            ctx.SaveChanges();
        }

        public static IList<Professional> GetProfessionalTickets(DateTime fromDate, DateTime toDate, AriClinicContext ctx)
        {
            List<Professional> professional = (from t in ctx.Tickets
                                               where t.TicketDate >= fromDate && t.TicketDate <= toDate
                                               select t.Professional).Distinct<Professional>().ToList<Professional>();

            return professional;
        }

        public static IList<Professional> GetSurgeonTickets(DateTime fromDate, DateTime toDate, AriClinicContext ctx)
        {
            List<Professional> professional = (from t in ctx.AnestheticTickets
                                               where t.TicketDate >= fromDate && t.TicketDate <= toDate && t.Surgeon != null
                                               select t.Surgeon).Distinct<Professional>().ToList<Professional>();

            return professional;
        }

        public static IList<Professional> GetSurgeonTickets(AriClinicContext ctx)
        {
            List<Professional> professional = (from t in ctx.AnestheticTickets
                                               where t.Surgeon != null
                                               select t.Surgeon).Distinct<Professional>().ToList<Professional>();

            return professional;
        }

        public static IList<Service> GetServices(AriClinicContext ctx)
        {
            List<Service> services = (from s in ctx.Services
                                      select s).ToList<Service>();

            return services;
        }

        public static IList<Invoice> GetInvoices(DateTime fini, DateTime ffin, AriClinicContext ctx)
        {
            return (from inv in ctx.Invoices
                    where inv.InvoiceDate >= fini && inv.InvoiceDate <= ffin
                    orderby inv.InvoiceDate descending
                    select inv).ToList<Invoice>();
        }

        public static IList<Invoice> GetInvoicesByCustomer(DateTime ffin, int idCustomer, AriClinicContext ctx1)
        {
            return (from inv in ctx1.Invoices
                    where inv.InvoiceDate <= ffin && inv.Customer.PersonId == idCustomer
                    orderby inv.InvoiceDate descending
                    select inv).ToList<Invoice>();
        }

        public static IList<Diary> GetDiaries(AriClinicContext ctx)
        {
            return ctx.Diaries.ToList<Diary>();
        }

        public static Diary GetDiary(int id, AriClinicContext ctx)
        {
            return (from a in ctx.Diaries
                    where a.DiaryId == id
                    select a).FirstOrDefault<Diary>();
        }

        public static IList<AppointmentType> GetAppointmentTypes(AriClinicContext ctx)
        {
            return ctx.AppointmentTypes.ToList<AppointmentType>();
        }

        public static AppointmentType GetAppointmentType(int id, AriClinicContext ctx)
        {
            return (from at in ctx.AppointmentTypes
                    where at.AppointmentTypeId == id
                    select at).FirstOrDefault<AppointmentType>();
        }

        public static IList<AppointmentInfo> GetAppointments(AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    orderby a.BeginDateTime descending
                    select a).ToList<AppointmentInfo>();
            //return ctx.AppointmentInfos.ToList<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetPatientAppointments(int patientId, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.Patient.PersonId == patientId
                    orderby a.BeginDateTime descending
                    select a).ToList<AppointmentInfo>();
        }

        public static AppointmentInfo GetAppointment(int id, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.AppointmentId == id
                    select a).FirstOrDefault<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetAppointments(Diary diary, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.Diary.DiaryId == diary.DiaryId
                    select a).ToList<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetAppointments(DateTime start, DateTime end, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.BeginDateTime >= start && a.EndDateTime <= end
                    select a).ToList<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetAppointments(Diary diary, DateTime start, DateTime end, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.Diary.DiaryId == diary.DiaryId &&
                          a.BeginDateTime >= start && a.EndDateTime <= end
                    select a).ToList<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetAppointments(Professional professional, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.Professional.PersonId == professional.PersonId
                    select a).ToList<AppointmentInfo>();
        }

        public static IList<AppointmentInfo> GetAppointments(Professional professional, DateTime start, DateTime end, AriClinicContext ctx)
        {
            return (from a in ctx.AppointmentInfos
                    where a.Professional.PersonId == professional.PersonId &&
                          a.BeginDateTime >= start && a.EndDateTime <= end
                    select a).ToList<AppointmentInfo>();
        }

        public static string GetAppointmentSubject(AppointmentInfo app)
        {
            string profesional = "";
            if (app.Professional != null) profesional = app.Professional.FullName;
            string frn = app.Patient.OftId.ToString();
            if (app.Arrival == null || NullDateTime(app.Arrival))
                return String.Format("{0} ({1} | {2}) [{3}] NH:{4}", 
                    app.Patient.FullName, app.AppointmentType.Name, app.Comments,profesional,frn);
            else
                return String.Format("{0} ({1} | {2}) [{3}] NH:{5} [{4:HH:mm:ss}]",
                    app.Patient.FullName, app.AppointmentType.Name, app.Comments, profesional, app.Arrival,frn);
        }

        public static string GetAppointmentDescription(AppointmentInfo app, AriClinicContext ctx)
        {
            Parameter par = CntAriCli.GetParameter(ctx);
            string description = "";
            if (par.AppointmentExtension)
                description =  String.Format("FRN:{0} - {1}",app.Patient.OftId, CntAriCli.GetInsuranceData(app.Patient, ctx));
            return description;
        }

        public static bool DeleteCustomer(Customer cus, AriClinicContext ctx)
        {
            foreach (Policy item in cus.Policies)
            {
                ctx.Delete(item.Tickets);
            }
            ctx.Delete(cus.Policies);
            ctx.Delete(cus);
            ctx.SaveChanges();
            return true;
        }

        public static bool PayNote(PaymentMethod pm, Decimal amount, DateTime dt, string des, ServiceNote note, Clinic cl, GeneralPayment gp, AriClinicContext ctx)
        {
            Payment p = null; // payment to be created
            Ticket t = null; // related ticket
            //(0) Control if amount > pending in note
            decimal total_paid = 0;
            foreach (Ticket tk in note.Tickets)
                total_paid += tk.Paid;
            if ((note.Total - total_paid) < amount)
                return false; // amount bigger than debt.

            //(1) Look for a ticket (inside note) with the same amount
            t = (from tk in note.Tickets where (tk.Amount - tk.Paid) == amount select tk).FirstOrDefault<Ticket>();
            if (t != null)
            {
                // (1.1) It exists.
                CreatePayment(t, pm, amount, dt, des, note, cl, gp, ctx);
            }
            else
            {
                // (1.2) It doesn't exist
                var rs = from tk in note.Tickets
                         orderby (tk.Amount - tk.Paid)
                         select tk;
                foreach (Ticket tk in rs)
                {
                    if (tk.Amount - tk.Paid >= amount)
                    {
                        CreatePayment(tk, pm, amount, dt, des, note, cl, gp, ctx);
                        break; // out
                    }
                    else
                    {
                        decimal paid = tk.Amount - tk.Paid;
                        amount = amount - paid;
                        CreatePayment(tk, pm, paid, dt, des, note, cl, gp, ctx);
                    }
                }
            }
            ctx.SaveChanges();
            return true;
        }

        public static void CreatePayment(Ticket t, PaymentMethod pm, Decimal amount, DateTime dt, string des, ServiceNote note, Clinic cl, GeneralPayment gp, AriClinicContext ctx)
        {
            Payment p = new Payment();
            p.Amount = amount;
            p.Clinic = cl;
            p.PaymentDate = dt;
            p.PaymentMethod = pm;
            p.GeneralPayment = gp;
            p.Description = des;
            p.Ticket = t;
            t.Paid = t.Paid + amount;
            ctx.Add(p);
        }

        public static List<AnestheticServiceNote> GetAnestheticServiceNotesByPerson(Person p, AriClinicContext ctx)
        {
            Customer cust;
            if (p is Patient)
                cust = (p as Patient).Customer;
            else if (p is Customer)
                cust = (p as Customer);
            else
                cust = new Customer();

            return (from anes in ctx.AnestheticServiceNotes
                    where anes.Customer == cust
                    select anes).ToList<AnestheticServiceNote>();
        }

        public static List<ServiceNote> GetServiceNotesByPerson(Person p, AriClinicContext ctx)
        {
            Customer cust;
            if (p is Patient)
                cust = (p as Patient).Customer;
            else if (p is Customer)
                cust = (p as Customer);
            else
                cust = new Customer();

            return (from anes in ctx.ServiceNotes
                    orderby anes.ServiceNoteDate descending
                    where anes.Customer == cust
                    select anes).ToList<ServiceNote>();
        }
        public static IList<Diagnostic> GetDiagnostics(AriClinicContext ctx)
        {
            return (from d in ctx.Diagnostics
                    orderby d.Name
                    select d).ToList<Diagnostic>();
        }
        public static Diagnostic GetDiagnostic(int id, AriClinicContext ctx)
        {
            return (from d in ctx.Diagnostics
                    where d.DiagnosticId == id
                    select d).FirstOrDefault<Diagnostic>();
        }
        public static IList<DiagnosticAssigned> GetDiagnosticsAssigned(AriClinicContext ctx)
        {
            return (from da in ctx.DiagnosticAssigneds
                    orderby da.DiagnosticDate descending
                    select da).ToList<DiagnosticAssigned>();
        }
        public static IList<DiagnosticAssigned> GetDiagnosticsAssigned(Patient patient, AriClinicContext ctx)
        {
            return (from da in ctx.DiagnosticAssigneds
                    orderby da.DiagnosticDate descending
                    where da.Patient.PersonId == patient.PersonId
                    select da).ToList<DiagnosticAssigned>();
        }
        public static DiagnosticAssigned GetDiagnosticAssigned(int id, AriClinicContext ctx)
        {
            return (from da in ctx.DiagnosticAssigneds
                    where da.DiagnosticAssignedId == id
                    select da).FirstOrDefault<DiagnosticAssigned>();
        }
        public static IList<Drug> GetDrugs(AriClinicContext ctx)
        {
            return (from d in ctx.Drugs
                    orderby d.Name
                    select d).ToList<Drug>();
        }
        public static Drug GetDrug(int id, AriClinicContext ctx)
        {
            return (from d in ctx.Drugs
                    where d.DrugId == id
                    select d).FirstOrDefault<Drug>();
        }
        public static IList<Treatment> GetTreatments(AriClinicContext ctx)
        {
            return (from t in ctx.Treatments
                    orderby t.TreatmentDate descending
                    select t).ToList<Treatment>();
        }
        public static Treatment GetTreatment(int id, AriClinicContext ctx)
        {
            return (from t in ctx.Treatments
                    where t.TreatmentId == id
                    select t).FirstOrDefault<Treatment>();
        }
        public static IList<Examination> GetExaminations(AriClinicContext ctx)
        {
            return (from e in ctx.Examinations
                    orderby e.Name
                    select e).ToList<Examination>();
        }
        public static IList<Examination> GetExaminations(string gt, AriClinicContext ctx)
        {
            return (from e in ctx.Examinations
                    orderby e.Name
                    where e.ExaminationType.Code == gt
                    select e).ToList<Examination>();
        }
        public static Examination GetExamination(int id, AriClinicContext ctx)
        {
            return (from e in ctx.Examinations
                    where e.ExaminationId == id
                    select e).FirstOrDefault<Examination>();
        }
        public static IList<ExaminationAssigned> GetExaminationsAssigned(AriClinicContext ctx)
        {
            return (from ea in ctx.ExaminationAssigneds
                    orderby ea.ExaminationDate descending
                    select ea).ToList<ExaminationAssigned>();
        }
        public static ExaminationAssigned GetExaminationAssigned(int id, AriClinicContext ctx)
        {
            return (from ea in ctx.ExaminationAssigneds
                    where ea.ExaminationAssignedId == id
                    select ea).FirstOrDefault<ExaminationAssigned>();
        }
        public static IList<ExaminationType> GetExaminationTypes(AriClinicContext ctx)
        {
            return (from et in ctx.ExaminationTypes
                    orderby et.Name
                    select et).ToList<ExaminationType>();
        }
        public static ExaminationType GetExaminationType(string code, AriClinicContext ctx)
        {
            return (from et in ctx.ExaminationTypes
                    where et.Code == code
                    select et).FirstOrDefault<ExaminationType>();
        }
        public static WithoutGlassesTest GetWithoutGlassesTest(int id, AriClinicContext ctx)
        {
            return (from wh in ctx.WithoutGlassesTests
                    where wh.Id == id
                    select wh).FirstOrDefault<WithoutGlassesTest>();
        }
        public static GlassesTest GetGlassesTest(int id, AriClinicContext ctx)
        {
            return (from gt in ctx.GlassesTests
                    where gt.Id == id
                    select gt).FirstOrDefault<GlassesTest>();
        }
        public static PrescriptionGlasses GetPrescriptionGlasses(int id, AriClinicContext ctx)
        {
            return (from gt in ctx.PrescriptionGlasses
                    where gt.Id == id
                    select gt).FirstOrDefault<PrescriptionGlasses>();
        }
        public static OpticalObjectiveExamination GetOpticalObjectiveExamination(int id, AriClinicContext ctx)
        {
            return (from gt in ctx.OpticalObjectiveExaminations
                    where gt.Id == id
                    select gt).FirstOrDefault<OpticalObjectiveExamination>();
        }
        public static SubjectiveOpticalExamination GetSubjectiveOpticalExamination(int id, AriClinicContext ctx)
        {
            return (from gt in ctx.SubjectiveOpticalExaminations
                    where gt.Id == id
                    select gt).FirstOrDefault<SubjectiveOpticalExamination>();
        }
        public static Cycloplegia GetCycloplegia(int id, AriClinicContext ctx)
        {
            return (from gt in ctx.Cycloplegias
                    where gt.Id == id
                    select gt).FirstOrDefault<Cycloplegia>();
        }

        public static int InvoiceAnesthesicServiceNote(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            // it there's an invoice related to this service 
            // we do nothing and return 0
            if (asn.Invoice != null)
                return 0;

            // invoice
            Invoice i = new Invoice();
            Decimal total = 0;
            i.Customer = asn.Customer;
            asn.Invoice = i; // this make the relationship
            i.InvoiceDate = asn.ServiceNoteDate;
            i.Serial = CntAriCli.GetHealthCompany(ctx).InvoiceSerial;
            i.Year = i.InvoiceDate.Year;
            i.InvoiceNumber = CntAriCli.GetNextInvoiceNumber(i.Serial, i.Year, ctx);
            ctx.Add(i);

            // invoice lines
            foreach (Ticket t in asn.AnestheticTickets)
            {
                InvoiceLine il = new InvoiceLine();
                il.Invoice = i;
                il.Ticket = t;
                il.Description = t.Description;
                il.Amount = t.Amount;
                il.TaxType = t.InsuranceService.Service.TaxType;
                il.TaxPercentage = il.TaxType.Percentage;
                total += il.Amount;
                ctx.Add(il);
            }
            i.Total = total;

            // save the work and return id
            ctx.SaveChanges();
            return i.InvoiceId;
        }

        public static bool ContainsAnesthesicTicketsInvoiced(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            foreach (Ticket t in asn.AnestheticTickets)
            {
                if (t.InvoiceLines.Count > 0)
                    return true;
            }
            return false;
        }
        public static ContactLensesTest GetContactLensesTest(int id, AriClinicContext ctx)
        {
            return (from cl in ctx.ContactLensesTests
                    where cl.Id == id
                    select cl).FirstOrDefault<ContactLensesTest>();
        }
        public static IList<UnitType> GetUnitTypes(AriClinicContext ctx)
        {
            return (from ut in ctx.UnitTypes
                    select ut).ToList<UnitType>();
        }
        public static UnitType GetUnitType(int id, AriClinicContext ctx)
        {
            return (from ut in ctx.UnitTypes
                    where ut.UnitTypeId == id
                    select ut).FirstOrDefault<UnitType>();
        }

        public static IList<ProfessionalInvoice> GetProfesionalInvoices(DateTime fromDate, DateTime toDate, AriClinicContext ctx)
        {
            List<ProfessionalInvoice> invoice = (from i in ctx.ProfessionalInvoices
                                                 where i.InvoiceDate >= fromDate && i.InvoiceDate <= toDate
                                                 select i).ToList<ProfessionalInvoice>();

            return invoice;
        }

        public static IList<ProfessionalInvoice> GetProfesionalInvoices(DateTime fromDate, DateTime toDate, string idProfessional, AriClinicContext ctx)
        {
            List<ProfessionalInvoice> invoice = (from i in ctx.ProfessionalInvoices
                                                 where i.InvoiceDate >= fromDate && i.InvoiceDate <= toDate && i.Professional.PersonId.ToString() == idProfessional
                                                 select i).ToList<ProfessionalInvoice>();

            return invoice;
        }
        public static IList<LabTest> GetLabTests(AriClinicContext ctx)
        {
            return (from l in ctx.LabTests
                    select l).ToList<LabTest>();
        }
        public static LabTest GetLabTest(int id, AriClinicContext ctx)
        {
            return (from l in ctx.LabTests
                    where l.LabTestId == id
                    select l).FirstOrDefault<LabTest>();
        }
        public static IList<LabTestAssigned> GetLabTestAssigneds(AriClinicContext ctx)
        {
            return (from la in ctx.LabTestAssigneds
                    select la).ToList<LabTestAssigned>();
        }
        public static LabTestAssigned GetLabTestAssigned(int id, AriClinicContext ctx)
        {
            return (from la in ctx.LabTestAssigneds
                    where la.LabTestAssignedId == id
                    select la).FirstOrDefault<LabTestAssigned>();
        }
        public static IList<ProcedureAssigned> GetProcedureAssigneds(AriClinicContext ctx)
        {
            return (from la in ctx.ProcedureAssigneds
                    select la).ToList<ProcedureAssigned>();
        }
        public static ProcedureAssigned GetProcedureAssigned(int id, AriClinicContext ctx)
        {
            return (from la in ctx.ProcedureAssigneds
                    where la.ProcedureAssignedId == id
                    select la).FirstOrDefault<ProcedureAssigned>();
        }
        public static IList<VisitReason> GetVisitReasons(AriClinicContext ctx)
        {
            return (from l in ctx.VisitReasons
                    select l).ToList<VisitReason>();
        }
        public static VisitReason GetVisitReason(int id, AriClinicContext ctx)
        {
            return (from l in ctx.VisitReasons
                    where l.VisitReasonId == id
                    select l).FirstOrDefault<VisitReason>();
        }
        public static IList<BaseVisit> GetVisits(AriClinicContext ctx)
        {
            return (from l in ctx.BaseVisits
                    orderby l.VisitDate descending
                    select l).ToList<BaseVisit>();
        }
        public static BaseVisit GetVisit(int id, AriClinicContext ctx)
        {
            return (from l in ctx.BaseVisits
                    where l.VisitId == id
                    select l).FirstOrDefault<BaseVisit>();
        }
        public static MotAppend GetMotAppend(int id, AriClinicContext ctx)
        {
            return (from m in ctx.MotAppends
                    where m.Id == id
                    select m).FirstOrDefault<MotAppend>();
        }
        public static AntSegment GetAntSegment(int id, AriClinicContext ctx)
        {
            return (from m in ctx.AntSegments
                    where m.Id == id
                    select m).FirstOrDefault<AntSegment>();
        }
        public static Fundus GetFundus(int id, AriClinicContext ctx)
        {
            return (from m in ctx.Fundus
                    where m.Id == id
                    select m).FirstOrDefault<Fundus>();
        }
        public static List<AnestheticTicket> GetAnestheticServiceTicketsBomba(DateTime fDate, DateTime tDate, AriClinicContext ctx1)
        {
            var anesNote = (from a in ctx1.AnestheticServiceNotes
                            where a.ServiceNoteDate >= fDate && a.ServiceNoteDate <= tDate && a.Chk1 == true && a.AnestheticTickets.Count > 0
                            select a).ToList<AnestheticServiceNote>();

            var res = (from a in anesNote
                       select a.AnestheticTickets.First<AnestheticTicket>());

            return res.ToList<AnestheticTicket>();
        }
        public static IList<Source> GetSources(AriClinicContext ctx)
        {
            return ctx.Sources.OrderBy(x => x.Name).ToList<Source>();
        }
        public static Source GetSource(int id, AriClinicContext ctx)
        {
            return (from s in ctx.Sources
                    where s.SourceId == id
                    select s).FirstOrDefault<Source>();
        }
        public static Source GetSourceByOftId(int oftId, AriClinicContext ctx)
        {
            return (from s in ctx.Sources
                    where s.OftId == oftId
                    select s).FirstOrDefault<Source>();
        }
        public static decimal GetServiceNoteAmount(ServiceNote snote)
        {
            decimal a = 0;
            foreach (Ticket t in snote.Tickets)
            {
                a += t.Amount;
            }
            return a;
        }
        public static decimal GetServiceNoteAmountPay(ServiceNote snote)
        {
            decimal a = 0;
            foreach (Ticket t in snote.Tickets)
            {
                foreach (Payment p in t.Payments)
                {
                    a += p.Amount;
                }
            }
            return a;
        }
        public static IList<SaveCheck> SaveChecks(AnestheticServiceNote asn)
        {
            IList<SaveCheck> lsc = new List<SaveCheck>();
            foreach (AnestheticTicket atck in asn.AnestheticTickets)
            {
                if (atck.Checked)
                {
                    SaveCheck  schk = new SaveCheck();
                    schk.ProcedureId = atck.Procedure.ProcedureId;
                    schk.Chk = true;
                    lsc.Add(schk);
                }
            }
            return lsc;
        }
        public static bool IsItInChecks(AnestheticTicket atck, IList<SaveCheck> lsck)
        {
            bool res = false;
            SaveCheck sc = (from sck in lsck
                            where sck.ProcedureId == atck.Procedure.ProcedureId
                            select sck).FirstOrDefault<SaveCheck>();
            if (sc != null) res = true;
            return res;
        }

        public static void CheckPolicy(Patient patient, AriClinicContext ctx)
        {

            // Does this customer have a policiy yet?
            if (patient.Customer.Policies.Count > 0) return;
            
            // He hasn't. Is there only one insurance company in db?.
            if (ctx.Insurances.Count() != 1) return;
            Insurance insurance = ctx.Insurances.First<Insurance>();
            
            // There's only one insurance company and we create a policy related to it.
            Policy policy = new Policy();
            policy.Insurance = insurance;
            policy.Customer = patient.Customer;
            ctx.Add(policy);
        }

        public static PreviousMedicalRecord GetPreviousMedicalRecord(int patientId, AriClinicContext ctx)
        {
            PreviousMedicalRecord pmr = null;
            return pmr;
        }

        public static int NextFrn(AriClinicContext ctx)
        {
            int nxtfrn = 0;
            int i = (from p in ctx.Patients
                     select p.OftId).Max();
            nxtfrn = ++i;
            return nxtfrn;
        }

        public static string GetInsuranceInformation(Patient patient, AriClinicContext ctx)
        {
            string res = "";
            Policy pol = GetPolicyInForce(patient, DateTime.Now, ctx);
            if (pol == null)
            {
                // there's not policy in force
                pol = (from p in patient.Customer.Policies
                       orderby p.EndDate descending
                       select p).FirstOrDefault<Policy>();
            }
            if (pol != null)
            {
                res = String.Format("{0} [{1}] {2:dd/MM/yyyy} - {3:dd/MM/yyyy}", pol.Insurance.Name, pol.PolicyNumber, pol.BeginDate, pol.EndDate);
            }
            return res;
        }
        #region Auxiliary functions
        #endregion

    }
}