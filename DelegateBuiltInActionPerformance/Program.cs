using System;
using System.Diagnostics;

namespace DelegateBuiltInActionPerformance
{
    /*
     * This program is to test how much slower are delegate method calls 
     * than direct method calls? To test this, we use the Action type with a single parameter.
     * This program introduces the TestMethod method, which contains some dummy code for testing.
     * First:
     * In the first loop, TestMethod (which uses no Action) is called directly 100 million times.
     * Second:
     * In the second loop, an Action instance that points to TestMethod is invoked the same number of times.
     */
    class Program
    {
        const int _max = 100000000;
        static void Main(string[] args)
        {
            //Action Delegate declaration and initialized with named method TestMethod
            Action<int> action = new Action<int>(TestMethod);

            var s1 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                // Direct call.
                TestMethod(5);
            }
            s1.Stop();
            var s2 = Stopwatch.StartNew();
            for (int i = 0; i < _max; i++)
            {
                // Delegate call.
                action.Invoke(5);
                //You can also use the following to call the delegate
                //action(5);
            }
            s2.Stop();
            //The result of direct method call
            Console.WriteLine("The direct method call time : " + ((double)(s1.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
            //The result of delegate call
            Console.WriteLine("The Action Delegate call time : "+((double)(s2.Elapsed.TotalMilliseconds * 1000 * 1000) /
                _max).ToString("0.00 ns"));
        }

        //TestMethod() method with the same signature of Action delegate
        static void TestMethod(int param)
        {
            // Dummy.
            if (param == -1)
            {
                throw new Exception();
            }
        }
    }
}
