using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLibrary.Constants.Authentication
{   
    //Is what you want to do or what you are permitted to do e.g CRUD
    public static class AppAction
    {   
        //Permission for users 
        public const string Create = nameof(Create);
        public const string Read = nameof(Read);
        public const string Update = nameof(Update);
        public const string Delete = nameof(Delete);
        
    }
}
