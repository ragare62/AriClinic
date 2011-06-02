using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AriCliModel
{
    public class PermissionView
    {
        private int permissionId;

        public int PermissionId
        {
            get { return permissionId; }
            set { permissionId = value; }
        }
        private int processId;

        public int ProcessId
        {
            get { return processId; }
            set { processId = value; }
        }
        private int parentProcessId;

        public int ParentProcessId
        {
            get { return parentProcessId; }
            set { parentProcessId = value; }
        }
        private bool view;

        public bool View
        {
            get { return view; }
            set { view = value; }
        }
        private bool create;

        public bool Create
        {
            get { return create; }
            set { create = value; }
        }
        private bool modify;

        public bool Modify
        {
            get { return modify; }
            set { modify = value; }
        }
        private bool execute;

        public bool Execute
        {
            get { return execute; }
            set { execute = value; }
        }
        private int userGroupId;

        public int UserGroupId
        {
            get { return userGroupId; }
            set { userGroupId = value; }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
