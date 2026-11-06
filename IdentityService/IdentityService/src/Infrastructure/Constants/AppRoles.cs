using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constants
{
    internal class AppRoles
    {
        public const string Basic = "Basic";
        public const string Admin = nameof(Admin);

        //helper to give us a list


        public static readonly IReadOnlyList<string> DefaultRoles =
  [
      Basic,
        Admin
  ];


    }
}
