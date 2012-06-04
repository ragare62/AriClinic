using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliModel
{
    public static partial class CntAriCli
    {
        public static void CreateAssociateTickets(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            // Does this customer have a primary policy with that service?
            Policy pol = PrimaryPolicy(asn.Customer);
            if (pol == null)
            {
                throw new AriCliException(1, "There isn't a primary policy for this customer");
            }
            // Delete all tickets
            ctx.Delete(asn.AnestheticTickets);
            foreach (Procedure proc in asn.Procedures)
            {
                // Does this policy includes related (from procedure) services
                InsuranceService ins = PolicyIncludesService(pol, proc.Service);
                if (ins == null)
                {
                    throw new AriCliException(3, "The insurance company have not the nomenclator service assigned");
                }
                // Everything seems ok, we can add anesthetic ticket
                AnestheticTicket atck = new AnestheticTicket()
                {
                    TicketDate = asn.ServiceNoteDate,
                    Description = String.Format("{0} ({1})", proc.Name, ins.Service.Name),
                    Amount = ins.Price,
                    Policy = pol,
                    InsuranceService = ins,
                    User = asn.User,
                    Clinic = asn.Clinic,
                    Professional = asn.Professional,
                    Surgeon = asn.Surgeon,
                    Procedure = proc,
                    AnestheticServiceNote = asn
                };
                ctx.Add(atck);
                ctx.SaveChanges();
            }

        }
        public static void ApplyMultiTicket(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            bool first = true;
            if (asn.AnestheticTickets.Count > 1)
            {
                foreach (AnestheticTicket atck in asn.AnestheticTickets.OrderByDescending(x => x.Amount))
                {
                    if (!first)
                    {
                        atck.Amount = atck.Amount / 2;
                        atck.Comments = "-50%";
                        ctx.SaveChanges();
                    }
                    first = false;
                }
            }
        }
        public static void ApplyPCA(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            // Read parameters
            AriCliModel.Parameter parameter = GetParameter(ctx);
            Service painPump = parameter.PainPump;
            // Do we need check pain pump?
            if (painPump != null && asn.Chk1)
            {
                // Is there a pain pump assigned?
                var rs = from t in asn.AnestheticTickets
                         where t.InsuranceService.Service.ServiceId == painPump.ServiceId
                         select t;
                if (rs.Count() == 0)
                {
                    // Does this customer have a primary policy with that service?
                    Policy pol = PrimaryPolicy(asn.Customer);
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
                    // More expensive procedure
                    AnestheticTicket aatck = asn.AnestheticTickets.OrderByDescending(x => x.Amount).FirstOrDefault<AnestheticTicket>();
                    if (aatck != null)
                    {
                        Procedure proc = aatck.Procedure;
                        // Everything seems ok, we can add the ticket
                        AnestheticTicket atck = new AnestheticTicket()
                        {
                            TicketDate = asn.ServiceNoteDate,
                            Description = String.Format("{0} ({1})", proc.Name, ins.Service.Name),
                            Amount = ins.Price,
                            Policy = pol,
                            InsuranceService = ins,
                            User = asn.User,
                            Clinic = asn.Clinic,
                            Professional = asn.Professional,
                            Surgeon = asn.Surgeon,
                            Procedure = proc,
                            AnestheticServiceNote = asn
                        };
                        ctx.Add(atck);
                        ctx.SaveChanges();
                    }
                }
            }
        }
        public static void ApplyRisk(AnestheticServiceNote asn, AriClinicContext ctx)
        {
            if (asn.Chk3)
            {
                foreach (AnestheticTicket atck in asn.AnestheticTickets)
                {
                    atck.Amount = atck.Amount * 1.5M;
                }
                ctx.SaveChanges();
            }
        }
        public static void CheckTickets(AnestheticServiceNote asn, bool[] lschk,  AriClinicContext ctx)
        {
            int i = 0;
            int lenght = lschk.Count();
            foreach (AnestheticTicket actk in asn.AnestheticTickets)
            {
                if (asn.Chk2)
                {
                    actk.Checked = true;
                }
                else
                {
                    if (i < lenght) actk.Checked = lschk[i];
                }
                i++;
            }
            ctx.SaveChanges();
        }
        public static bool[] SaveTckChecks(AnestheticServiceNote asn)
        {
            bool[] ls = new bool[asn.AnestheticTickets.Count];
            int i = 0;
            foreach (AnestheticTicket atck in asn.AnestheticTickets)
            {
                ls[i++] = atck.Checked;
            }
            return ls;
        }
        public static bool UpdateRelatedTckV2(AnestheticServiceNote asn, bool[] lschk, AriClinicContext ctx)
        {
            bool res = true;
            try
            {
                CreateAssociateTickets(asn, ctx);
                ApplyMultiTicket(asn, ctx);
                ApplyPCA(asn, ctx);
                ApplyRisk(asn, ctx);
                CheckTickets(asn, lschk, ctx);
            }
            catch (AriCliException ex)
            {
                res = false;
            }
            return res;
        }
    }
}
