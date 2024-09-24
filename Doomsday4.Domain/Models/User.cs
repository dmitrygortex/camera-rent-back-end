﻿using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

public class User : Entity<Guid>
{
    private User()
    {
    }

    public User(string phoneNumber, string password, string email, string lastName, string firstName, UserRole userRole)
    {
        Id = Guid.NewGuid();
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        LastName = lastName;
        FirstName = firstName;
        UserRole = userRole;
    }

    public string PhoneNumber { get; private set;}
    public string Password { get; private set;}
    public string Email { get; private set;}
    public string LastName { get; private set;}
    public string FirstName { get; private set;}
    // public List<Order> Orders { get; private set;} = new List<Order>();
    public UserRole UserRole { get; private set;}
}