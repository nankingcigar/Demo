using System;
using Xunit;

namespace Nankingcigar.Demo.Test
{
    public class DateTimeTest
    {
        [Fact]
        public void TestMethod1()
        {
            DateTime time1970 = new DateTime(1970,1,1);
            long a = DateTime.Now.ToUniversalTime().Ticks - time1970.ToUniversalTime().Ticks;
            Console.WriteLine(a);
            DateTime time = time1970.ToUniversalTime().AddTicks(1000);
            Console.WriteLine(time);
        }
    }
}
