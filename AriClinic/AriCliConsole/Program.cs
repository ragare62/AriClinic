using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AriCliModel;
using Telerik.OpenAccess;

namespace AriCliConsole
{
    class Program
    {
        static AriClinicContext ctx;
        static void Main(string[] args)
        {
            ctx = new AriClinicContext("AriClinicContext");

            Console.WriteLine("-- Begin program --");
            FixAnestheticNotes(ctx);

            Console.WriteLine("-- End program. Press <ENTER> to exit --");
            Console.ReadLine();
        }

        private static void CreateThings()
        {
            // Create a user
            using (AriClinicContext ctx = new AriClinicContext("AriClinicContext"))
            {
                Console.WriteLine("Deleting all records....");
                ctx.Delete(ctx.Logs);
                ctx.Delete(ctx.Users);
                ctx.Delete(ctx.UserGroups);
                ctx.Delete(ctx.HealthcareCompanies);
                ctx.SaveChanges();

                Console.WriteLine("Creating default group..");
                UserGroup ug = new UserGroup();
                ug.Name = "Reservado";
                ctx.Add(ug);

                Console.WriteLine("Creating administrator user..");
                User user = new User();
                user.Name = "Superuser";
                user.Login = "admin";
                user.UserGroup = ug;
                user = CntAriCli.EncryptPassword(user, "admin");
                ctx.Add(user);

                HealthcareCompany hc = new HealthcareCompany();
                hc.Name = "Ariadna Salud S.L.";
                ctx.Add(hc);

                Clinic clinic = new Clinic()
                {
                     Name = "Clinica 1"
                };
                ctx.Add(clinic);


                // parameters
                Console.WriteLine("Creating parameters...");
                AriCliModel.Parameter parameter = new Parameter() 
                {
                    PainPump = null,
                    UseNomenclator = false
                };
                ctx.Add(parameter);

                // processes
                Console.WriteLine("Creating process...");
                Process process = new Process()
                {
                    Name = "Administración",
                    Code = "admin",
                };
                Process admin = process;
                ctx.Add(admin);
                process = new Process()
                {
                    Name = "Procesos",
                    Code = "process",
                    ParentProcess = admin
                };
                ctx.Add(process);
                process = new Process()
                {
                    Name = "Permisos",
                    Code = "permision",
                    ParentProcess = admin
                };
                ctx.Add(process);
                
                // permissions
                Console.WriteLine("Creating permissions...");
                Permission permission = new Permission()
                {
                      Process = admin,
                      UserGroup = ug,
                      View=true,
                      Create=true,
                      Modify=true,
                      Execute=true,
                };
                ctx.Add(permission);
                permission = new Permission()
                {
                    Process = process, // must be permission process
                    UserGroup = ug,
                    View = true,
                    Create = true,
                    Modify = true,
                    Execute = true,
                };
                ctx.Add(permission);
                // import data

                ctx.SaveChanges();
                Console.WriteLine("All jobs done");
            }
        }

        private static void CreateServicesToTest()
        {
            using (AriClinicContext ctx = new AriClinicContext("AriClinicContext"))
            {
                for (int i = 0; i < 10000; i++)
                {
                    Service ser = new Service();
                    ser.Name = String.Format("Servicio {0}", i);
                    int i2 = i % 2;
                    switch (i2)
                    {
                        case 0:
                            ser.TaxType = CntAriCli.GetTaxType(3, ctx);
                            break;
                        case 1:
                            ser.TaxType = CntAriCli.GetTaxType(4, ctx);
                            break;
                    }
                    int i3 = i % 3;
                    switch (i3)
                    {
                        case 0:
                            ser.ServiceCategory = CntAriCli.GetServiceCategory(1, ctx);
                            break;
                        case 1:
                            ser.ServiceCategory = CntAriCli.GetServiceCategory(2, ctx);
                            break;
                    }
                    ctx.Add(ser);
                    ctx.SaveChanges();
                    Console.WriteLine("Creando registro {0}", i);
                }
            }
        }

        private static void SetPermissions(int user_group_id, int process_id)
        {
            Permission p = (from proc in ctx.Permissions
                         where proc.UserGroup.UserGroupId == user_group_id && proc.Process.ProcessId == process_id
                         select proc).FirstOrDefault<Permission>();

            p.Create = true;
            p.Execute = true;
            p.Modify = true;
            p.View = true;

            ctx.SaveChanges();
        }

        private static void FixAnestheticNotes(AriClinicContext ctx)
        {
            foreach (AnestheticServiceNote asn in ctx.AnestheticServiceNotes)
            {
                CntAriCli.CheckAnestheticServiceNoteTickets(asn, ctx);
            }
        }
    }
}
