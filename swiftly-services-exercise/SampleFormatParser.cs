namespace swiftly_services_exercise
{
    // TODO: Parser interface

    // Parses the sample format described in the spec at
    // https://github.com/Swiftly-Systems/code-exercise-services/blob/master/ProductInformationIntegrationSpec.md
    public class SampleFormatParser
    {
        // TODO: Replace magic numbers with statics.

        /// The string currently being parsed.
        private string m_s;

        // TODO: Consider other currency types.
        decimal ParseCurrency(int i, int l) {
            return decimal.Parse(m_s.Substring(i, l)) / 100m;
        }

        string FormatCurrencyForDisplay(decimal x) {
            // TODO: Consider culture specific formatting.
            // TODO: Commas
            // TODO: Use decimal.ToString("C"); in a real implementation.
            var rounded = decimal.Round(x, 2, System.MidpointRounding.ToZero);
            var fixedWidth = rounded.ToString("N2");
            return $"${fixedWidth}";
        }

        decimal CalculatorPrice(int singularPriceIndex, int splitPriceIndex, int forXIndex) {
            decimal singularPrice = ParseCurrency(singularPriceIndex, 8);
            decimal calculatorPrice;
            if (singularPrice != 0) {
                calculatorPrice = singularPrice;
            } else {
                decimal splitPrice = ParseCurrency(splitPriceIndex, 8);
                int forX = int.Parse(m_s.Substring(forXIndex, 8));
                calculatorPrice = splitPrice == 0 ? 0 : splitPrice / forX;
            }
            return decimal.Round(calculatorPrice, 4, System.MidpointRounding.ToZero);
        }

        bool CheckFlag(int i) {
            // TODO: Check i is in range.
            // TODO: Assert 'N' if not 'Y'
            int j = 123 + i - 1;
            char c = m_s[j];
            return c == 'Y';
        }

        public ProductRecord Parse(string s) {
            m_s = s;

            var result = new ProductRecord();

            result.ProductID = int.Parse(s.Substring(0, 8));
            result.ProductDescription = s.Substring(9, 59).Trim();
            
            // TODO: 106 off by one?
            result.RegularCalculatorPrice = CalculatorPrice(69, 87, 105);
            result.RegularDisplayPrice = FormatCurrencyForDisplay(result.RegularCalculatorPrice);

            result.PromotionalCalculatorPrice = CalculatorPrice(78, 96, 114);
            result.PromotionalDisplayPrice = result.PromotionalCalculatorPrice == 0 ?
                "N/A" :  FormatCurrencyForDisplay(result.PromotionalCalculatorPrice);

            result.TaxRate = CheckFlag(5) ? 7.775m : 0;
            result.Measure = CheckFlag(3) ? UnitOfMeasure.Pound : UnitOfMeasure.Each;
            result.ProductSize = s.Substring(133, 9).Trim();

            m_s = null;
            return result;
        }
    }
}
