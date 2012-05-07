using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliModel
{
    public static partial class CntAriCli
    {
        public static decimal GetUnpaid(ServiceNote sn, AriClinicContext ctx)
        {
            decimal amount = sn.Tickets.Sum(t => t.Amount);
            decimal paid = sn.Tickets.Sum(t => t.Paid);
            return (amount - paid);
        }
        public static GeneralPayment GeneralPaymentNew(Clinic clinic, ServiceNote sn, decimal amount, PaymentMethod payMethod, DateTime payDate, string description, AriClinicContext ctx)
        {
            var rs = from t in sn.Tickets
                     where t.Amount > t.Paid
                     select t;
            GeneralPayment gp = new GeneralPayment();
            gp.ServiceNote = sn;
            gp.PaymentDate = payDate;
            gp.Description = description;
            gp.PaymentMethod = payMethod;
            gp.Amount = amount;
            gp.Clinic = clinic;
            ctx.Add(gp);
            foreach (Ticket t in rs.OrderByDescending(tk => tk.Amount - tk.Paid))
            {
                Payment pay = new Payment();
                pay.PaymentMethod = payMethod;
                pay.PaymentDate = payDate;
                pay.Ticket = t;
                pay.GeneralPayment = gp;
                pay.Clinic = clinic;
                decimal dif = t.Amount - t.Paid;
                if (dif <= amount)
                {
                    pay.Amount = dif;
                    amount = amount - dif;
                    t.Paid = t.Paid + dif;
                }
                else
                {
                    pay.Amount = amount;
                    t.Paid = t.Paid + amount;
                    amount = 0;
                }
                ctx.Add(pay);
                if (amount == 0) break;
            }
            ctx.SaveChanges();
            return gp;
        }
        public static void GeneralPaymentDelete(GeneralPayment gp, AriClinicContext ctx)
        {
            foreach (Payment p in gp.Payments)
            {
                PaymentDelete(p, ctx);
            }
            ctx.Delete(gp);
            ctx.SaveChanges();
        }
        public static void PaymentDelete(Payment pay, AriClinicContext ctx)
        {
            // minus paid in ticket
            if (pay.Ticket != null)
            {
                pay.Ticket.Paid = pay.Ticket.Paid - pay.Amount;
            }
            ctx.Delete(pay);
            ctx.SaveChanges();
        }
    }
}
