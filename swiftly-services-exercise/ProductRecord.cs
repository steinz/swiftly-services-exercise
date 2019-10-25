

namespace swiftly_services_exercise
{
    // TODO: Internal
    public class ProductRecord
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }

        public string RegularDisplayPrice { get; set; }
        public decimal RegularCalculatorPrice { get; set; }
        public string PromotionalDisplayPrice { get; set; }
        public decimal PromotionalCalculatorPrice { get; set; }
        public decimal TaxRate { get; set; }

        public UnitOfMeasure Measure { get; set; }
        public string ProductSize { get; set; }
    }
}
