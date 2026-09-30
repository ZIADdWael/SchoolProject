using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Role = root+"/"+version+"/";

        public static class StudentRouting
        {
            public const string prefix = Role + "Student/";
            public const string List=prefix + "List";
            public const string GetById=prefix + "{id}";
            public const string Create = prefix + "create";
            public const string Edit = prefix + "Edit";
            public const string Delete = prefix + "{id}";
            public const string Paginated = prefix + "Paginated";

        }
        public static class DepartmentRouting
        {
            public const string prefix = Role + "Department/";
            public const string List=prefix + "List";
            public const string GetById=prefix + "Id";
            public const string Create = prefix + "create";
            public const string Edit = prefix + "Edit";
            public const string Delete = prefix + "{id}";
            public const string Paginated = prefix + "Paginated";

        }
    }
}
