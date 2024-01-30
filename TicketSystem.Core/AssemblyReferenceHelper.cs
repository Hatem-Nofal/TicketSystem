using System.Reflection;

namespace TicketSystem.Domain
{
    public static class AssemblyReferenceHelper
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();

        }
    }
}
