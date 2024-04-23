namespace Domain.Primitives
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        protected BaseEntity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private init; }

        public static bool operator ==(BaseEntity? first, BaseEntity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }
        public static bool operator !=(BaseEntity? first, BaseEntity? second)
        {
            return !(first == second);
        }
        // from IEquatable
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != typeof(BaseEntity)) return false;
            if (obj is not BaseEntity entity) return false;
            return entity.Id == Id;
        }

        public bool Equals(BaseEntity? other)
        {
            if (other == null) return false;
            if (other.GetType() != typeof(BaseEntity)) return false;
            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();

        }
    }
}
