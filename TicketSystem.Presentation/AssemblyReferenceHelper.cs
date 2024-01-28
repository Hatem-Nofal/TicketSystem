using System.Reflection;

namespace TicketSystem.Presentation
{
    public static class AssemblyReferenceHelper
    {
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }
    }
}
