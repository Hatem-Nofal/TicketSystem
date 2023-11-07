using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.Presentation
{
   public static class AssemblyReferenceHelper
    {
        public  static Assembly GetAssembly()
        {
           return Assembly.GetExecutingAssembly();
        }
    }
}
