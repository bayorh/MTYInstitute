using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Errors;

public static class DomainErrors
{
    public static class Parent
    {
        public static readonly Error StudentObjectNull = new Error("Parent.Student null Object ",
                "Student Object cannot be null");

        public static readonly Error EmailAlreadyExist = new Error("Email Already Exist",
            "Parent with {request.email}  already exist");
    }
}
