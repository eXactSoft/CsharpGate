using System;

namespace EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            /* An event named ThresholdReached that is associated with an EventHandler delegate.
             * The method assigned to the EventHandler delegate is called in the OnThresholdReached 
             * method.
             * Also a custom event data class named ThresholdReachedEventArgs that derives from 
             * the EventArgs class. An instance of the event data class is passed to the event 
             * handler for the ThresholdReached event.
             */

            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += c_ThresholdReached;

            c.Name = "CounterOne";

            Console.WriteLine("press 'a' key to increase total");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one");
                c.Add(1);
            }
        }

        // The listener to the event ThresholdReached
        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            //Display the custom properties of ThresholdReachedEventArgs object
            Console.WriteLine("The threshold of {0} was reached at {1}.", e.Threshold, e.TimeReached);
            //You can specify the type of the sender
            Console.WriteLine($"Event raised from type class: {sender.GetType()}");
            //You can specify the name of the sender object
            Console.WriteLine($"Event raised from Counter object named : {((Counter)sender).Name}");
            Environment.Exit(0);
        }

        /* For non genric EventHandler
        static void c_ThresholdReached(object sender, EventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.",
                                ((ThresholdReachedEventArgs)e).Threshold, ((ThresholdReachedEventArgs)e).TimeReached);
            Environment.Exit(0);
        }
        */
    }

    class Counter
    {
        private int threshold;
        private int total;

        public string Name { get; set; }

        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        //Raise the event
        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            //The non-generic version will be 
            //EventHandler handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        //Declare an event of the type EventHandler delegate (Which is a built-in .Net framework)
        //& its the type of event argument is EventArgs
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }

    /* custom event data class, create a class that derives from the EventArgs class 
     * and provide the properties to store the necessary data. The name of your custom event 
     * data class should end with EventArgs.
     */ 
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
/*
 * .NET provides two delegate types to make it easier to define events: EventHandler 
 * and the generic EventHandler<TEventArgs>. Both are delegates that use the standard event 
 * handler pattern. 
 * The generic version enables you to specify the type of event argument you want to use.
 * 
 * The event model in the .NET Framework is based on having an event delegate that connects an 
 * event with its handler. To raise an event, two elements are needed:
 * A delegate that identifies the method that provides the response to the event.
 * Optionally, a class that holds the event data, if the event provides data.
 * The delegate is a type that defines a signature, that is, the return value type and 
 *   parameter list types for a method. You can use the delegate type to declare a variable 
 *   that can refer to any method with the same signature as the delegate.
 *   
 * The standard signature of an event handler delegate defines a method that does not return 
 *   a value. This method's first parameter is of type Object and refers to the instance that 
 *   raises the event. Its second parameter is derived from type EventArgs and holds the event 
 *   data. If the event does not generate event data, the second parameter is simply the value 
 *   of the EventArgs.Empty field. Otherwise, the second parameter is a type derived from EventArgs 
 *   and supplies any fields or properties needed to hold the event data.
 *   
 * The EventHandler delegate is a predefined delegate that specifically represents an event 
 *   handler method for an event that does not generate data. If your event does generate data, 
 *   you must use the generic EventHandler<TEventArgs> delegate class.
 *   
 * The EventHandler<TEventArgs> delegate is a predefined delegate that represents an event 
 *   handler method for an event that generates data. The advantage of using EventHandler<TEventArgs> 
 *   is that you do not need to code your own custom delegate if your event generates event data. 
 *   You simply provide the type of the event data object as the generic parameter.
 * 
 * To associate the event with the method that will handle the event, add an instance of the 
 *   delegate to the event. The event handler is called whenever the event occurs, unless you 
 *   remove the delegate.
 * 
 * EventArgs Class: Represents the base class for classes that contain event data, and provides 
 * a value to use for events that do not include event data.
 * 
 * EventArgs class serves as the base class for all classes that represent event data. 
 * For example, the System.AssemblyLoadEventArgs class derives from EventArgs and is used to 
 * hold the data for assembly load events. To create a custom event data class, 
 * create a class that derives from the EventArgs class and provide the properties to store 
 * the necessary data. The name of your custom event data class should end with EventArgs.
 * 
 * Note that if you have an event that doesn’t need event argument data, you can still use 
 * the EventHandler delegate type. You can simply pass EventArgs.Empty as the argument value.
 * 
 */
