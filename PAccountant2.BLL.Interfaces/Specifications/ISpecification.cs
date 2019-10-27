namespace PAccountant2.BLL.Interfaces.Specifications
{
    public interface ISpecification<in T> where T : class
    {
        bool IsSatisfied(T item);
    }
}
