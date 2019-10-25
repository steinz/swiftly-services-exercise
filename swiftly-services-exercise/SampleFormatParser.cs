namespace swiftly_services_exercise
{
    public class SampleFormatParser
    {
        public ProductRecord Parse(string s) {
            ProductRecord result = new ProductRecord();

            result.ProductID = int.Parse(s.Substring(0, 8));
            result.ProductDescription = s.Substring(9, 59).Trim();
            
            // TODO: ParseCurrency helper
            decimal regularSingularPrice = decimal.Parse(s.Substring(69, 8)) / 100m;
            if (regularSingularPrice == 0) {
                decimal regularSplitPrice = decimal.Parse(s.Substring(87, 8)) / 100m;
                int regularForX = int.Parse(s.Substring(106, 8));
                result.RegularCalculatorPrice = regularSplitPrice / regularForX;
            } else {
                result.RegularCalculatorPrice = regularSingularPrice;
            }
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