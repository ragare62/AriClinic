using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RidocciModel
{
    public static class CntRidoModel
    {
        public static Aseguradora GetAseguradora(int id, RdcModel ctx)
        {
            return (from a in ctx.Aseguradoras
                    where a.Id_aseguradora == id
                    select a).FirstOrDefault<Aseguradora>();
        }
        public static Acto_medico GetActo_Medico(int id, RdcModel ctx)
        {
            return (from am in ctx.Acto_medicos
                    where am.Id_acto_medico == id
                    select am).FirstOrDefault<Acto_medico>();
        }
    }
}
