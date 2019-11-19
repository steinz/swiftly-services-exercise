namespace swiftly_services_exercise
{
    // Parses the sample format described in the spec at
    // https://github.com/Swiftly-Systems/code-exercise-services/blob/master/ProductInformationIntegrationSpec.md
    public class SampleFormatParser : IProductRecordParser
    {
        // TODO: Replace magic numbers with statics.

        // TODO: Consider representing currency with other types.
        decimal ParseCurrency(string s) {
            return decimal.Parse(s) / 100m;
        }

        string FormatCurrencyForDisplay(decimal x) {
            // TODO: Consider culture specific formatting.
            // TODO: Use decimal.ToString("C"); in a real implementation.
            var rounded = decimal.Round(x, 2, System.MidpointRounding.ToZero);
            var fixedWidth = rounded.ToString("N2");
            return $"${fixedWidth}";
        }

        decimal CalculatorPrice(string singularPrice, string splitPrice, string forX) {
            decimal singular = ParseCurrency(singularPrice);
            decimal calculator;
            if (singular != 0) {
                calculator = singular;
            } else {
                decimal split = ParseCurrency(splitPrice);
                int amount = int.Parse(forX);
                calculator = split == 0 ? 0 : split / amount;
            }
            return decimal.Round(calculator, 4, System.MidpointRounding.ToZero);
        }

        bool CheckFlag(string flags, int i) {
            // TODO: Check i is in range.
            // TODO: Assert 'N' if not 'Y'
            int j = i - 1;
            char c = flags[j];
            return c == 'Y';
        }

        public IProductRecord Parse(string s) {
            RawSampleProductFormat raw = new RawSampleProductFormat(s);
            return Parse(raw);
        }

        IProductRecord Parse(RawSampleProductFormat raw) {
            var result = new ProductRecord();

            result.ProductID = int.Parse(raw.ProductId);
            result.ProductDescription = raw.ProductDescription.Trim();
            
            result.RegularCalculatorPrice = CalculatorPrice(raw.RegularSingularPrice,
                raw.RegularSplitPrice, raw.RegularForX);
            result.RegularDisplayPrice = FormatCurrencyForDisplay(result.RegularCalculatorPrice);

            result.PromotionalCalculatorPrice = CalculatorPrice(raw.PromotionalSingularPrice,
                raw.PromotionalSplitPrice, raw.PromotionalForX);
            result.PromotionalDisplayPrice = result.PromotionalCalculatorPrice == 0 ?
                "N/A" :  FormatCurrencyForDisplay(result.PromotionalCalculatorPrice);

            result.TaxRate = CheckFlag(raw.Flags, 5) ? 7.775m : 0;
            result.Measure = CheckFlag(raw.Flags, 3) ? UnitOfMeasure.Pound : UnitOfMeasure.Each;
            result.ProductSize = raw.ProductSize.Trim();

            return result;
        }
    }
}
