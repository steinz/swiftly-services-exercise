using NUnit.Framework;
using swiftly_services_exercise;
using System;

namespace test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            SampleFormatParser parser = new SampleFormatParser();
            ProductRecord product = parser.Parse(
                "80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz");
            
            Assert.That(product.ProductID, Is.EqualTo(80000001));
            Assert.That(product.ProductDescription, Is.EqualTo("Kimchi-flavored white rice"));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(5.67m));
            // TODO: Revisit output formatting
            Assert.That(product.RegularDisplayPrice, Is.EqualTo("5.67"));
            
            // TODO
            //Assert.That(product.ProductSize, Is.EqualTo("18oz"));
        }

        [Test]
        public void TestParsingBoundaries_SinglePrice()
        {
            SampleFormatParser parser = new SampleFormatParser();
            ProductRecord product = parser.Parse(
                "555555556aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab555555556444444446000000006000000006000000006000000006NNNNNNNNNYaaaaaaaaa");

            // TODO: Test against SampleProductFormat instead of ProductRecord class/interface
            Assert.That(product.ProductID, Is.EqualTo(55555555));
            Assert.That(product.ProductDescription, Is.EqualTo(new String('a', 59)));
            Assert.That(product.RegularCalculatorPrice, Is.EqualTo(555555.55m));
            // TODO: Other fields
        }
    }
}