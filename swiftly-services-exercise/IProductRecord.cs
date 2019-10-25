namespace swiftly_services_exercise {
    public enum UnitOfMeasure { Each, Pound }
    public interface IProductRecord
    {
        public int ProductID { get; }
        public string ProductDescription { get; }

        public string RegularDisplayPrice { get; }
        public decimal RegularCalculatorPrice { get; }
        public string PromotionalDisplayPrice { get; }
        public decimal PromotionalCalculatorPrice { get; }
        public decimal TaxRate { get; }

        public UnitOfMeasure Measure { get; }
        public string ProductSize { get; }
    }
}
