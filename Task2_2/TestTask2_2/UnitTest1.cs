using NUnit.Framework;
using Observers;
using Subscribers;
using System.Diagnostics;

namespace TestTask2_2
{
    public class Tests
    {

        [Test]
        public void TestCountDownWithTwoSubscribers()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber(Timer);
            var secondSubscriber = new Subscriber2(Timer);
            Timer.Timer(1000, "1 seconds left");
            stopWatch.Stop();
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds > 2);
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds < 2.5);
        }

        [Test]
        public void TestCountDown()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var Timer = new CountDown();
            var firstSubscriber = new Subscriber(Timer);
            Timer.Timer(1000, "1 seconds left");
            stopWatch.Stop();
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds > 1);
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds < 1.5);
        }
    }
}