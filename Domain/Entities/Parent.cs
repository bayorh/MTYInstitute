using Domain.Enums;
using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities;

public sealed class Parent : AggregrateRoot
{
    private static readonly List<Student> _student = new(); //field

    
    private Parent(Guid id,string name, string address, string email, int phoneNumber, Tittle? tittle):base(id)
    {
        Name = name;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
        Tittle = tittle;
    }
    public string  Name { get; private set; }
    public string  Address { get; private set; }
    public string  Email { get; private  set; }
    public int PhoneNumber { get; private set; }
    public Tittle? Tittle { get; private set; }
    public IReadOnlyCollection<Student> students => _student; // property.

   

    public static Result<Parent>  Create(Guid id, string name, string address, string email, int phoneNumber, Tittle? tittle)
    {
        var parentToCreate = 
            new Parent(
            id, name,address, email, phoneNumber, tittle);
       return parentToCreate;
    }
        
    public  Result<bool> AddStudentToParent(Parent parent,Student student)
    {
        if (student == null)
            return Result.Failure<bool>(DomainErrors.Parent.StudentObjectNull);

        var studentToAdd = new Student(
            student.Id, student.FirstName,
            student.LastName,
            parent,
            student.Level);
        _student.Add(studentToAdd);
        return true;
    }
}


