using System.Collections.Generic;
using System.Linq;

namespace swiftly_services_exercise
{
    // TODO: Internal
    public class ProductRecord : IProductRecord
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

        // TODO: This probably belongs in a ProductRecordFormatter class.
        override public string ToString() {
            IEnumerable<object> fields = new List<object>{
                ProductID,
                ProductDescription,
                RegularCalculatorPrice,
                RegularDisplayPrice,
                PromotionalCalculatorPrice,
                PromotionalDisplayPrice,
                TaxRate,
                Measure,
                ProductSize};
            var joined = string.Join(", ", fields.Select(x => x.ToString()));
            return $"ProductRecord({joined})";
        }

        // TODO: HashCode, Equals
    }
}
