namespace Mty.Application.Parents.Queries.GetByEmail;

public sealed record ParentResponse (Guid id, string name,  string Email, int PhoneNumber);
