using System.Reflection;

namespace TicketSystem.Identity.Constants;

public static class Permissions
{



    public static class CommentPermissions
    {
        public const string View_Comment = "Permissions.Comment.View";
        public const string Create_Comment = "Permissions.Comment.Create";
        public const string Edit_Comment = "Permissions.Comment.Edit";
        public const string Delete_Comment = "Permissions.Comment.Delete";
    }
    public static class TicketPermissions
    {
        public const string View_Ticket = "Permissions.Ticket.View";
        public const string Create_Ticket = "Permissions.Ticket.Create";
        public const string Edit_Ticket = "Permissions.Ticket.Edit";
        public const string Delete_Ticket = "Permissions.Ticket.Delete";
    }

    public static List<string> GeneratePermissionsForModule(Type type)
    {
        List<string> constants = new List<string>();

        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

        foreach (var field in fields)
        {
            if (field.IsLiteral && !field.IsInitOnly)
            {
                constants.Add(field.GetValue(null).ToString());
            }
        }

        // Check for nested types
        Type[] nestedTypes = type.GetNestedTypes(BindingFlags.Public);
        foreach (var nestedType in nestedTypes)
        {
            constants.AddRange(GeneratePermissionsForModule(nestedType));
        }
        return constants;
    }
}
