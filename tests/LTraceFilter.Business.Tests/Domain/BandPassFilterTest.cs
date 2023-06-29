using Accord.Audio;
using NUnit.Framework;
using Accord.Audio.Generators;
using LTraceFilter.Business.Domain.Factory;
using Accord.Audio.Filters;

namespace LTraceFilter.Business.Tests
{
    [TestFixture]
    [Category("UnitTest")]
    public class BandPassFilterTest
    {
        [Test]
        public void ShouldFilterHarmonicsOutsideOfPassBand()
        {
            int sampleRate = 10000;
            int totalOfSamples = 1000;

            double highCutoffFrequency = 200;
            double lowCutoffFrequency = 1000;

            double harmonicOneFrequency = 100;
            double harmonicTwoFrequency = 600;
            double harmonicThreeFrequency = 4000;

            Signal harmonicOne = new SineGenerator(harmonicOneFrequency, 100, sampleRate).Generate(totalOfSamples);
            Signal harmonicTwo = new SineGenerator(harmonicTwoFrequency, 100, sampleRate).Generate(totalOfSamples);
            Signal harmonicThree = new SineGenerator(harmonicThreeFrequency, 100, sampleRate).Generate(totalOfSamples);

            var filterFactory = new FilterFactory();
            var bandPassFilter = filterFactory.CreateBandPassFilter(lowCutoffFrequency, highCutoffFrequency, sampleRate);

            var filteredOne = bandPassFilter.Apply(harmonicOne.ToFloat());
            var filteredTwo = bandPassFilter.Apply(harmonicTwo.ToFloat());
            var filteredThree = bandPassFilter.Apply(harmonicThree.ToFloat());

            var highestValueOffilteredOne = filteredOne.Max();
            var highestValueOffilteredTwo = filteredTwo.Max();
            var highestValueOffilteredThree = filteredThree.Max();

            Assert.Greater(highestValueOffilteredTwo, highestValueOffilteredOne);
            Assert.Greater(highestValueOffilteredTwo, highestValueOffilteredThree);
        }
    }
}