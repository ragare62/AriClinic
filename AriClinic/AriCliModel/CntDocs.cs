using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// My imports
using System.Web.UI;
using System.IO;

namespace AriCliModel
{
    public static class CntDocs
    {
        public static string DocsRoot(Page page)
        {
            return String.Format("{0}\\{1}", page.MapPath("/"), "docs");
        }
        public static bool DocsExists(Page page)
        {
            if (Directory.Exists(DocsRoot(page)))
                return true;
            else
                return false;
        }
        public static void CreateDocs(Page page)
        {
            Directory.CreateDirectory(DocsRoot(page));
        }
        public static bool PatientFolderExists(Patient patient, Page page)
        {
            string patDirPath = String.Format("{0}\\{1}", DocsRoot(page), patient.FullName);
            if (Directory.Exists(patDirPath))
                return true;
            else
                return false;
        }
        public static void CreatePatientFolder(Patient patient, Page page)
        {
            string patDirPath = String.Format("{0}\\{1}", DocsRoot(page), patient.FullName);
            Directory.CreateDirectory(patDirPath);
        }
    }
}
