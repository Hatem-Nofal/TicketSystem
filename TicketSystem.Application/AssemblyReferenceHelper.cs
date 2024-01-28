using System.Reflection;

namespace TicketSystem.Application
{
    public static class AssemblyReferenceHelper
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();

        }
    }
}
