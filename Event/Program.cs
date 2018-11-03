using System;
using System.Timers;

namespace Event
{
 
    class Program
    {
        static int counter = 0;
        static string displayString = "This string will appear one letter at a time. ";

        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            /* When the Timer object is started using its Start() method, a stream of events is 
             * raised, spaced out in time according to the specified time period.
             * Main() method is the publisher that has tha Timer object event to notify the
             * subscriber method
             * The Timer object possesses an event called Elapsed, and the event handler required 
             * by this event must match the return type and parameters of the System.Timers.
             * ElapsedEventHandler delegate type, which is one of the standard delegates defined in 
             * the .NET Framework. This delegate specifies the following return type and parameters:
                    void <MethodName>(object source, ElapsedEventArgs e);
             * 
             * 
             */
            //to hook this handler up to the event—to subscribe to it. To do this, you use 
            //the += operator to add a handler to the event in the form of a new delegate 
            //instance initialized with your event handler method.
            //adds a handler to the list that will be called when the Elapsed event is raised. 
            //You can add as many handlers as you like to this list as long as they all meet 
            //the criteria required.Each handler is called in turn when the event is raised.
            Timer myTimer = new Timer(100);

            myTimer.Elapsed += new ElapsedEventHandler(WriteChar);
             /* instead you can one of the following 3 equivelant ways  as follows:
            //1- The method name directly:
            myTimer.Elapsed += WriteChar;

            //2- Anonymous method:
            myTimer.Elapsed += delegate (object source, ElapsedEventArgs e)
            {
                Console.Write(displayString[counter++ % displayString.Length]);
            };
            
            //3- Anonymous method with lambda expression
            myTimer.Elapsed += (object source, ElapsedEventArgs e) => 
                               { Console.Write(displayString[counter++ % displayString.Length]); };
            */

            //Start the timer running:
            myTimer.Start();

            //The System.Threading.Thread.Sleep(300) statement is included to give the 
            //timer the opportunity to start sending messages to the console application.
            System.Threading.Thread.Sleep(300);

            //You don’t want the application terminating before you have handled any events, 
            //so you put the Main() method on hold.The simplest way to do this is to request 
            //user input, as this command won’t finish processing until the user has pressed 
            //a key:
            Console.ReadKey();

            Console.WriteLine("_2-------------------------------------------------------------");
            /* Example of using event, Number class is the subscriber to the event beforeDisplayEvent
             * that fires (or notifies or raises) by DisplayHelper class (the publisher).
             * Number class provided a handler function which is going to be called when 
             * a publisher raises an event.
             */
            //create an instance of Number class and call Display methods.
            Number myNumber = new Number(100000);
            myNumber.DisplayMoney();
            myNumber.DisplayNumber();

 

        }

        // Subscriber to the Built-in Elapsed event of the class Timer (The publisher)
        //This method uses the two static fields of Program, counter and displayString, 
        //to display a single character.Every time the method is called, a different character 
        //is displayed.
        static void WriteChar(object source, ElapsedEventArgs e)
        {
            Console.Write(displayString[counter++ % displayString.Length]);
            //counter++ % displayString.Length  gives the current index of the letter to be displayed
        }
    }

    /* The following DisplayHelper class that displays integers in different formats like number, 
     * money, decimal, temperature and hexadecimal. It includes a beforeDisplayEvent to notify 
     * the subscriber of the BeforeDisplay event before it going to Display the number.
     * 
     * DisplayHelper is a publisher class that publishes the beforeDisplay event. Notice that in 
     * each Display method, it first checks to see if beforeDisplayEvent is not null and then it 
     * calls beforeDisplayEvent(). beforeDisplayEvent is an object of type BeforDisplay delegate, 
     * so it would be null if no class is subscribed to the event and that is why 
     * it is necessary to check for null before calling a delegate.
     * 
     * DisplayHelper declares the BeforeDisplay delegate that accepts a string argument. So now, 
     * you can pass a string when you raise an event from DisplayNumber or any other Display method.
     * WriteChar()
     */
    public class DisplayHelper
    {
        // Define a delegate.
        public delegate void BeforeDisplay(string message);

        // Declare event of the type BeforeDisplay delegate
        public event BeforeDisplay beforeDisplayEvent;


        public void DisplayNumber(int num)
        {
            // Call delegate method before going to display
            if (beforeDisplayEvent != null)
                beforeDisplayEvent.Invoke("DisplayNumber");
            // The delegate can also be invoked using the Invoke() method, 
            // e.g., beforeDisplayEvent.Invoke().

            Console.WriteLine("Number: {0,-12:N0}", num);
        }

        public void DisplayDecimal(int dec)
        {
            if (beforeDisplayEvent != null)
                beforeDisplayEvent("DisplayDecimal");

            Console.WriteLine("Decimal: {0:G}", dec);
        }

        public void DisplayMoney(int money)
        {
            if (beforeDisplayEvent != null)
                beforeDisplayEvent("DisplayMoney");

            Console.WriteLine("Money: {0:C}", money);
        }

        public void DisplayTemperature(int num)
        {
            if (beforeDisplayEvent != null)
                beforeDisplayEvent("DisplayTemerature");

            Console.WriteLine("Temperature: {0,4:N1} F", num);
        }

        public void DisplayHexadecimal(int dec)
        {
            if (beforeDisplayEvent != null)
                beforeDisplayEvent("DisplayHexadecimal");

            Console.WriteLine("Hexadecimal: {0:X}", dec);
        }
    }

    /* A subscriber to beforeDisplayEvent and provided a handler function, which is going to 
     * be called when a publisher raises an event.
     * the Number class creates an instance of DisplayHelper and subscribes to 
     * the beforeDisplayEvent with the "+=" operator and gives the name of the function which 
     * will handle the event (it will be get called when publish fires an event). 
     * DisplayHelper_beforeDisplayEvent is the event handler that has the same signature as 
     * the BeforeDisplay delegate in the DisplayHelper class.
     * 
     * The subscriber class should have an event handler that has a string parameter.
     * The Number class has a DisplayHelper_beforeDisplayEvent function with string parameter.
     * 
     */
    class Number
    {
        private DisplayHelper _DisplayHelper;

        public Number(int val)
        {
            _value = val;

            _DisplayHelper = new DisplayHelper();
            //subscribe to beforeDisplayEvent event
            _DisplayHelper.beforeDisplayEvent += DisplayHelper_beforeDisplayEvent;
        }
        //beforeDisplayevent handler
        void DisplayHelper_beforeDisplayEvent(string message)
        {
            Console.WriteLine("BeforeDisplayEvent fires from {0}", message);
        }

        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void DisplayMoney()
        {
            _DisplayHelper.DisplayMoney(_value);
        }

        public void DisplayNumber()
        {
            _DisplayHelper.DisplayNumber(_value);
        }

    }
        
}
/*
 * In general terms, an event is something special that is going to happen. For example, 
 * Microsoft launches events for developers, to make them aware about the features of new 
 * or existing products. Microsoft notifies the developers about the event by email or other 
 * advertisement options. So in this case, Microsoft is a publisher who launches (raises) an 
 * event and notifies the developers about it and developers are the subscribers of the event 
 * and attend (handle) the event.
 * Events in C# follow a similar concept. An event has a publisher, subscriber, notification 
 * and a handler. Generally, UI controls use events extensively. For example, the button 
 * control in a Windows form has multiple events such as click, mouseover, etc. A custom 
 * class can also have an event to notify other subscriber classes about something that has 
 * happened or is going to happen. Let's see how you can define an event and notify other 
 * classes that have event handlers.
 * 
 * An event is nothing but an encapsulated delegate.
 * To define an event, use the event keyword before declaring a variable of delegate type.
 * Thus, a delegate becomes an event using the event keyword.
 * 
 * All the subscribers must provided a handler function, which is going to be called when 
 * a publisher raises an event.
 * 
 * Events can also pass data as an argument to their subscribed handler. An event passes 
 * arguments to the handler as per the delegate signature.
 * 
 * Points to Remember :
 *  Use event keyword with delegate type to declare an event.
 *  Check event is null or not before raising an event.
 *  Subscribe to events using "+=" operator. Unsubscribe it using "-=" operator.
 *  Function that handles the event is called event handler. Event handler must have same 
 *    signature as declared by event delegate.
 *  Events can have arguments which will be passed to handler function.
 *  Events can also be declared static, virtual, sealed and abstract.
 *  An Interface can include event as a member.
 *  Events will not be raised if there is no subscriber
 *  Event handlers are invoked synchronously if there are multiple subscribers
 *  The .NET framework uses an EventHandler delegate and an EventArgs base class.
 * 
 * Many handlers can be subscribed to a single event, all of which are called when the event 
 * is raised. This can include event handlers that are part of the class of the object that 
 * raises the event, but event handlers are just as likely to be found in other classes.
 * Event handlers themselves are simply methods. The only restriction on an event handler 
 * method is that it must match the return type and parameters required by the event. 
 * This restriction is part of the definition of an event and is specified by a delegate.
 * 
 * When the event is raised, the subscriber is notified.
 * 
 * Events aren't delegate instances.
 * The easiest way to understand events is to think of them a bit like properties. 
 * While properties look like they're fields, they're definitely not - and you can write 
 * properties which don't use fields at all. Similarly, while events look like delegate 
 * instances in terms of the way you express the add and remove operations, they're not.
 * 
 * Events themselves can be declared in two ways. The first is with explicit add and remove 
 * methods ("longhand"), declared in a very similar way to properties, but with the event keyword. 
 * Here's an example of an event for the System.EventHandler delegate type. Note how it 
 * doesn't actually do anything with the delegate instances which are passed to the add 
 * and remove methods - it just prints out which operation has been called. 
 * Note that the remove operation is called even though we've told it to remove null.
        class Test
        {
            public event EventHandler MyEvent
            {
                add
                {
                    Console.WriteLine ("add operation");
                }
        
                remove
                {
                    Console.WriteLine ("remove operation");
                }
            }       
    
            static void Main()
            {
                Test t = new Test();
        
                t.MyEvent += new EventHandler (t.DoNothing);
                t.MyEvent -= null;
            }
    
            void DoNothing (object sender, EventArgs e)
            {
            }
        }
 * 
 * C# provides a simple way of declaring both a delegate variable and an event at the same time.
 * This is called a field-like event, and is declared very simply - 
 * it's the same as the "longhand" event declaration, but without the "body" part:
        public event EventHandler MyEvent;
 * This creates a delegate variable and an event, both with the same type. 
 * The access to the event is determined by the event declaration (so the example above creates 
 * a public event, for instance) but the delegate variable is always private. 
 * The implicit body of the event is the obvious one to add/remove delegate instances to 
 * the delegate variable, but the changes are made within a lock. For C# 1.1, 
 * the event is equivalent to:
 * private EventHandler _myEvent;
        public event EventHandler MyEvent
        {
            add
            {
                lock (this)
                {
                    _myEvent += value;
                }
            }
            remove
            {
                lock (this)
                {
                    _myEvent -= value;
                }
            }        
        }
 * 
 * Now we know what they are, what's the point of having both delegates and events? The answer 
 * is encapsulation. Suppose events didn't exist as a concept in C#/.NET. How would another 
 * class subscribe to an event? Three options:
 * 1)-A public delegate variable
 * 2)-A delegate variable backed by a property
 * 3)-A delegate variable with AddXXXHandler and RemoveXXXHandler methods
 * 
 * Option 1 : is clearly horrible, for all the normal reasons we abhor public variables. 
 * Option 2 is slightly better, but allows subscribers to effectively override each other - 
 *      it would be all too easy to write someInstance.MyEvent = eventHandler; which would 
 *      replace any existing event handlers rather than adding a new one. In addition, 
 *      you still need to write the properties.
 * Option 3 is basically what events give you, but with a guaranteed convention (generated by 
 *      the compiler and backed by extra flags in the IL) and a "free" implementation 
 *      if you're happy with the semantics that field-like events give you. Subscribing to 
 *      and unsubscribing from events is encapsulated without allowing arbitrary access to 
 *      the list of event handlers, and languages can make things simpler by providing syntax 
 *      for both declaration and subscription.
 * 
 * Delegates are the basis for events, which are effectively conventions for adding and 
 * removing handler code to be invoked at appropriate times.
 * 
 * Events have the following properties:
 * The publisher determines when an event is raised; the subscribers determine what action 
 *   is taken in response to the event.
 * An event can have multiple subscribers. A subscriber can handle multiple events from multiple
 *   publishers.
 * Events that have no subscribers are never raised.
 * Events are typically used to signal user actions such as button clicks or menu selections in 
 *   graphical user interfaces.
 * When an event has multiple subscribers, the event handlers are invoked synchronously when an 
 *   event is raised. To invoke events asynchronously, see Calling Synchronous Methods Asynchronously.
 * In the .NET Framework class library, events are based on the EventHandler delegate and the 
 *   EventArgs base class.
 * 
 * It is possible to provide a return type for an event, but this can lead to problems because 
 * a given event can result in several event handlers being called. If all of these handlers 
 * return a value, then it can be unclear which value was actually returned. 
 * The system deals with this by allowing you access to only the last value returned by an 
 * event handler.
 * That will be the value returned by the last event handler to subscribe to an event. 
 * Although this functionality might be of use in some situations, it is recommended that 
 * you use void type event handlers, and avoid out type parameters 
 * (which would lead to the same ambiguity regarding the source of the value returned 
 * by the parameter).
 * 
 */
