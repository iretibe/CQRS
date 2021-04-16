namespace CQRS.Domain.Common
{
    /*An abstract class is a special type of class that cannot be instantiated.
    An abstract class is designed to be inherited by subclasses that either implement or override its methods.
    In other words, abstract classes are either partially implemented or not implemented at all.*/
    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }
}
