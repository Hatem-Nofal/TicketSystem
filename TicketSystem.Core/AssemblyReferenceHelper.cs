using System.Reflection;
using System.Reflection.Metadata;

namespace TicketSystem.Domain
{
    public static class AssemblyReferenceHelper
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

    }
}
