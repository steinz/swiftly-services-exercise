using NUnit.Framework;
using swiftly_services_exercise;
using System;

namespace test
{
    public class RawSampleProductFormatTest
    {
        [Test]
        public void TestBoundaries()
        {
            RawSampleProductFormat raw = new RawSampleProductFormat(
                "555555550aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab111111110222222220333333330444444440555555550666666660NNNNNNNNNYaaaaaaaaa");

            // TODO: Test against SampleProductFormat instead of ProductRecord class/interface
            // so that we can check intermediate values like ForX.
            Assert.That(raw.ProductId, Is.EqualTo("55555555"));
            Assert.That(raw.ProductDescription, Is.EqualTo(new String('a', 59)));
            Assert.That(raw.RegularSingularPrice, Is.EqualTo("11111111"));
            Assert.That(raw.PromotionalSingularPrice, Is.EqualTo("22222222"));
            Assert.That(raw.RegularSplitPrice, Is.EqualTo("33333333"));
            Assert.That(raw.PromotionalSplitPrice, Is.EqualTo("44444444"));
            Assert.That(raw.RegularForX, Is.EqualTo("55555555"));
            Assert.That(raw.PromotionalForX, Is.EqualTo("66666666"));
            Assert.That(raw.Flags, Is.EqualTo("NNNNNNNNN"));
            Assert.That(raw.ProductSize, Is.EqualTo("aaaaaaaaa"));
        }
    }
}