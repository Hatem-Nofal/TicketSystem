using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.Domain.Common.Models;
using TicketSystem.Domain.Common.Models.ValueObjects;
using TicketSystem.Domain.Tickets.ValueObjects;
using TicketSystem.Domain.Users.Events;
using TicketSystem.Domain.Users.ValueObjects;

namespace TicketSystem.Domain.Users;
public sealed class User  : AggregateRoot<UserId>
{
    //private User(UserId id,string userName, Guid identityUsersId, string photoURL, Email email, Phone phone):base(id)
    //{
    //    UserName = userName;
    //    IdentityUsersId = identityUsersId;
    //    PhotoURL = photoURL;
    //    Email = email;
    //    Phone = phone;
    //}

    private User() : base(null)
    {

    }
    private User(UserId id) : base(id)
    {

    }

    public string UserName { get; private set; }
    public Guid IdentityUsersId { get; private set; }
    public string PhotoURL { get; private set; }
    public Email Email { get; private set; }
    public Phone Phone { get; private set; }

    public static User Create(string userName, Guid identityUsersId, string photoURL, Email email, Phone phone)
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
