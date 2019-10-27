namespace PAccountant2.BLL.Interfaces.Specifications
{
    public class AndSpecification<T> : ISpecification<T> where T : class
    {
        public ISpecification<T> Left { get; set; }

        public ISpecification<T> Right { get; set; }

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            Left = left;
            Right = right;
        }

        public bool IsSatisfied(T item)
            => Left.IsSatisfied(item) && Right.IsSatisfied(item);
    }
}
