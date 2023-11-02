using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Classes
{
    internal static class Verification
    {
       
        public static bool StrCN(string Str) => Str.Any(char.IsDigit);
        
        public static bool StrIsNull(string Str)=>Str.Equals("");
        


    }
}
