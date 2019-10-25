using NUnit.Framework;
using swiftly_services_exercise;

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
            ProductRecord product = ProductRecord.FromString("80000001 Kimchi-flavored white rice                                  00000567 00000000 00000000 00000000 00000000 00000000 NNNNNNNNN      18oz");
            ProductRecord expect = new ProductRecord();
            expect.ProductID = 80000001;

            Assert.Pass();
        }
    }
}