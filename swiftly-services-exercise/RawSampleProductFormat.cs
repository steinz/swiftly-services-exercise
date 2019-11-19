namespace swiftly_services_exercise {
    public class RawSampleProductFormat {

        private string Str;

        public string ProductId { get { return Str.Substring(0, 8); } }
        public string ProductDescription { get { return Str.Substring(9, 59); } }
        public string RegularSingularPrice	{ get { return Str.Substring(69, 8); }  }
        public string PromotionalSingularPrice	{ get { return Str.Substring(78, 8); } }
        public string RegularSplitPrice {get { return Str.Substring(87, 8); } }
        public string PromotionalSplitPrice { get { return Str.Substring(96, 8); } }
        public string RegularForX { get { return Str.Substring(105, 8); } }
        public string PromotionalForX { get { return Str.Substring(114, 8); } }
        public string Flags { get { return Str.Substring(123, 9); } }
        public string ProductSize {get { return Str.Substring(133, 9); } }

        public RawSampleProductFormat(string s) {
            this.Str = s;
        }
    }
}
