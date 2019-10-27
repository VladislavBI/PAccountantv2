namespace PAccountant2.BLL.Interfaces.Specifications
{
    public class NotSpecification<T> : ISpecification<T> where T : class
    {
        public ISpecification<T> Spec { get; set; }

        public NotSpecification(ISpecification<T> spec)
        {
            Spec = spec;
        }

        public bool IsSatisfied(T item)
            => !Spec.IsSatisfied(item);
    }
}
