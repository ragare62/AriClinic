using AriCliModel;
using System;
using System.Reflection;
using System.Linq;

namespace AriCliControl
{
    public static partial class CntAriClinic
    {
        private static string Connection;
        public static void SetConnection(string connection)
        {
            Connection = connection;
        }
        public static AriClinicContext OpenContext()
        {
            if (Connection != "")
                return new AriClinicContext(Connection);
            else
                return new AriClinicContext(); 
        }
        public static void CloseContext(AriClinicContext ctx)
        {
            ctx.Dispose();
        }
        public static void CloneFromTo(object o_from, object o_to)
        {
            Type t_from = o_from.GetType();
            PropertyInfo[] pi = t_from.GetProperties();
            foreach (PropertyInfo p in pi)
            {
                // search for the propery with the same name
                // in o_control object.
                var rs = from pc in o_to.GetType().GetProperties()
                         where pc.Name == p.Name
                         select pc;
                PropertyInfo p2 = rs.FirstOrDefault<PropertyInfo>();
                if (p2 != null)
                {
                    p2.SetValue(o_to, p.GetValue(o_from,null), null);
                }
            }

        }
    }
}
