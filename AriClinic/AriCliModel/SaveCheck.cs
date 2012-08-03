using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliModel
{
    public class SaveCheck
    {
        private int procedureId;

        public int ProcedureId
        {
            get { return procedureId; }
            set { procedureId = value; }
        }
        private bool chk;

        public bool Chk
        {
            get { return chk; }
            set { chk = value; }
        }
    }
}
