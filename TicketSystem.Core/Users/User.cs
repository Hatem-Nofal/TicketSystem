using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Primitives;
using TicketSystem.Domain.Primitives.ValueObjects;
using TicketSystem.Domain.Users.Events;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Users;
public sealed class User  : AggregateRoot<UserId>
{
    

    private User() : base(null)
    {

    }
    private User(UserId id) : base(id)
    {

    }

    public string UserName { get; private set; }
    public IdentityUsersId IdentityUsersId { get; private set; }
    public string PhotoURL { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }

    public static User Create(string userName, IdentityUsersId identityUsersId, string photoURL, Email email, Phone phone)
    {
        var user = new User(UserId.CreateUnique());
        user.UserName = userName;
        user.IdentityUsersId = identityUsersId;
        user.PhotoURL = photoURL;
        user.Email = email;
        user.Phone = phone;
        user.Raise(new UserCreatedDomainEvent(Guid.NewGuid(), user!.Id ));
        return user;

    }
}
