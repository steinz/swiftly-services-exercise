using NUnit.Framework;
using swiftly_services_exercise;
using System;

namespace test
{
    public class Tests
    {
        private const decimal TaxRate = 7.775m;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SampleFormatParser parser = new SampleFormatParser();
            IProductRecord product = parser.Parse(
                "80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz");
            
            Assert.That(product.ProductID, Is.EqualTo(80000001));
            Assert.That(product.ProductDescription, Is.EqualTo("Kimchi-flavored white rice"));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(5.67m));
            // TODO: Revisit output formatting
            Assert.That(product.RegularDisplayPrice, Is.EqualTo("$5.67"));
            Assert.That(product.PromotionalCalculatorPrice, Is.EqualTo(0m));
            Assert.That(product.PromotionalDisplayPrice, Is.EqualTo("N/A"));
            
            Assert.That(product.TaxRate, Is.EqualTo(0m));
            Assert.That(product.Measure, Is.EqualTo(UnitOfMeasure.Each));

            Assert.That(product.ProductSize, Is.EqualTo("18oz"));
        }

        [Test]
        public void Test2()
        {
            SampleFormatParser parser = new SampleFormatParser();
            IProductRecord product = parser.Parse(
                "14963801 Generic Soda 12-pack                                        00000000 00000549 00001300 00000000 00000002 00000000 NNNNYNNNN   12x12oz");

            Assert.That(product.ProductID, Is.EqualTo(14963801));
            Assert.That(product.ProductDescription, Is.EqualTo("Generic Soda 12-pack"));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(6.50m));
            // TODO: Revisit output formatting
            Assert.That(product.RegularDisplayPrice, Is.EqualTo("$6.50"));
            Assert.That(product.PromotionalCalculatorPrice, Is.EqualTo(5.49m));
            Assert.That(product.PromotionalDisplayPrice, Is.EqualTo("$5.49"));

            Assert.That(product.TaxRate, Is.EqualTo(TaxRate));
            Assert.That(product.Measure, Is.EqualTo(UnitOfMeasure.Each));

            Assert.That(product.ProductSize, Is.EqualTo("12x12oz"));
        }

        [Test]
        public void Test3()
        {
            SampleFormatParser parser = new SampleFormatParser();
            IProductRecord product = parser.Parse(
                "40123401 Marlboro Cigarettes                                         00001000 00000549 00000000 00000000 00000000 00000000 YNNNNNNNN          ");

            Assert.That(product.ProductID, Is.EqualTo(40123401));
            Assert.That(product.ProductDescription, Is.EqualTo("Marlboro Cigarettes"));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(10.00m));
            // TODO: Revisit output formatting
            Assert.That(product.RegularDisplayPrice, Is.EqualTo("$10.00"));
            Assert.That(product.PromotionalCalculatorPrice, Is.EqualTo(5.49m));
            Assert.That(product.PromotionalDisplayPrice, Is.EqualTo("$5.49"));

            Assert.That(product.TaxRate, Is.EqualTo(0.0m));
            Assert.That(product.Measure, Is.EqualTo(UnitOfMeasure.Each));

            Assert.That(product.ProductSize, Is.EqualTo(""));
        }

        [Test]
        public void Test4()
        {
            SampleFormatParser parser = new SampleFormatParser();
            IProductRecord product = parser.Parse(
                "50133333 Fuji Apples (Organic)                                       00000349 00000000 00000000 00000000 00000000 00000000 NNYNNNNNN        lb");

            Assert.That(product.ProductID, Is.EqualTo(50133333));
            Assert.That(product.ProductDescription, Is.EqualTo("Fuji Apples (Organic)"));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(3.49m));
            // TODO: Revisit output formatting
            Assert.That(product.RegularDisplayPrice, Is.EqualTo("$3.49"));
            Assert.That(product.PromotionalCalculatorPrice, Is.EqualTo(0.0m));
            Assert.That(product.PromotionalDisplayPrice, Is.EqualTo("N/A"));

            Assert.That(product.TaxRate, Is.EqualTo(0.0m));
            Assert.That(product.Measure, Is.EqualTo(UnitOfMeasure.Pound));

            Assert.That(product.ProductSize, Is.EqualTo("lb"));
        }


        [Test]
        public void TestParsingBoundaries_SinglePrice()
        {
            SampleFormatParser parser = new SampleFormatParser();
            IProductRecord product = parser.Parse(
                "555555556aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab555555556444444446000000006000000006000000006000000006NNNNNNNNNYaaaaaaaaa");

            // TODO: Test against SampleProductFormat instead of ProductRecord class/interface
            // so that we can check intermediate values like ForX.
            Assert.That(product.ProductID, Is.EqualTo(55555555));
            Assert.That(product.ProductDescription, Is.EqualTo(new String('a', 59)));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(555555.55m));
            Assert.That(product.PromotionalCalculatorPrice, Is.EqualTo(444444.44m));
            // TODO: Flags
            Assert.That(product.ProductSize, Is.EqualTo(new String('a', 9)));
        }
    }
}