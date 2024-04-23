using Domain.Enums;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities;

public sealed class Student: BaseEntity
{
    internal Student(
        Guid id, 
        string firstName,
        string lastName,
        Parent parent,
        Level?  level
        ): base(id)
        
    {
       
        FirstName = firstName;
        LastName = lastName;
        Level = level;
        ParentId =parent.Id;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Level? Level { get; private set; }


    // Navigation properties.
    public Guid ParentId { get; private set; }

    

}
