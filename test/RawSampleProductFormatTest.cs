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
                "55555555 aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa 11111111 22222222 33333333 44444444 55555555 66666666 NNNNNNNNN aaaaaaaaa");

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