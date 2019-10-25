

namespace swiftly_services_exercise
{
    public enum UnitOfMeasure { Each, Pound }

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

        public static ProductRecord FromString(string s) {
            ProductRecord result = new ProductRecord();

            result.ProductID = int.Parse(s.Substring(0, 8));
            result.ProductDescription = s.Substring(10, 58).Trim();
            
            decimal regularSingularPrice = decimal.Parse(s.Substring(70, 8));
            if (regularSingularPrice == 0) {
                decimal regularSplitPrice = decimal.Parse(s.Substring(88, 8));
                int regularForX = int.Parse(s.Substring(106, 8));
                result.RegularCalculatorPrice = regularSplitPrice / regularForX;
            } else {
                result.RegularCalculatorPrice = regularSingularPrice;
            }
            // TODO: Round result.RegularCalculatorPrice to 4 decimal places
            result.RegularCalculatorPrice = decimal.Round(result.RegularCalculatorPrice, 4,
                System.MidpointRounding.ToZero);
            // TODO: Add $ and commas here
            result.RegularDisplayPrice = decimal.Round(result.RegularCalculatorPrice, 2,
                System.MidpointRounding.ToZero).ToString();

            // TODO
            //result.PromotionalDisplayPrice = 
            //result.PromotionalCalculatorPrice = 

            //result.TaxRate = 
            //result.Measure = 
            //result.ProduceSize = 

            return result;
        }
    }
}
