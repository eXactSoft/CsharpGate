using System;

namespace Interface
{
    //Definition of an interface
    interface ILog
    {
        void Log(string msgToLog);
    }

    //ConsoleLog1 implement ILog interface
    class ConsoleLog1 : ILog
    {
        public void Log(string msgToPrint)
        {
            Console.WriteLine(msgToPrint);
        }
    }

    //ConsoleLog2 implement ILog interface
    class ConsoleLog2 : ILog
    {
        public void Log(string msgToPrint)
        {
            Console.WriteLine($"Hello {msgToPrint}");
        }
    }

    //ConsoleLog3 implement ILog interface Explicitly
    class ConsoleLog3 : ILog
    {
        void ILog.Log(string msgToPrint)
        {
            Console.WriteLine($"Explicitly Hello {msgToPrint}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {   //Declare an object of type ILog
            ILog log;

            //Initialize the log object to an object of type ConsoleLog1.
            log = new ConsoleLog1();
            log.Log("World!!");

            //Initialize the log object to an object of type ConsoleLog2.
            log = new ConsoleLog2();
            log.Log("World!!");

            //Initialize the log object to an object of type ConsoleLog3.
            log = new ConsoleLog3();
            log.Log("World!!");
        }
    }
}
/*
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/interface
 * An interface in C# contains only the declaration of the methods, properties, events
 * ,& indexers but not the implementation. It is left to the class that implements the interface 
 * by providing implementation for all the members of the interface. Interface makes 
 * it easy to maintain a program.
 * 
 * An interface contains definitions for a group of related functionalities that a class or a struct can implement.
 * An interface contains only the signatures of methods, properties, events or indexers.
 * An interface can inherit from one or more base interfaces.
 * When a base type list contains a base class and interfaces, the base class must come first in the list.
 * An interface can't be instantiated directly. Its members are implemented by any class or struct that implements the interface.
 * A class or struct can implement multiple interfaces. A class can inherit a base class and also implement one or more interfaces.
 * An interface can be implement implicitly or explicitly.
 * An interface cannot include private members. All the members are public by default.
 * 
 * When a class or struct implements an interface, the class or struct must provide an 
 * implementation for all of the members that the interface defines. The interface itself 
 * provides no functionality that a class or struct can inherit in the way that it can 
 * inherit base class functionality. However, if a base class implements an interface, 
 * any class that's derived from the base class inherits that implementation.
 * 
 * https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/explicit-interface-implementation
 * Explicit implementation is useful when class is implementing multiple interface thereby it 
 * is more readable and eliminates the confusion. It is also useful if interfaces have same 
 * method name coincidently.
 * 
 * An interface is a collection of public instance (that is, nonstatic) methods and 
 * properties that are grouped together to encapsulate specific functionality.
 * 
 * Interfaces cannot exist on their own. You can’t “instantiate an interface” as you can 
 * a class. In addition, interfaces cannot contain any code that implements its members; 
 * it just defines the members.
 * The implementation must come from classes that implement the interface.
 * 
 * interface names are normally prefixed with a capital I.
 * 
 * A class can support multiple interfaces, and multiple classes can support the same interface.
 * 
 * Once an interface is published—that is, it has been made available to other developers or 
 * end users—it is good practice not to change it. One way of thinking about this is to 
 * imagine the interface as a contract between class creators and class consumers. 
 * You are effectively saying, “Every class that supports interface X will support these 
 * methods and properties.” If the interface changes later, perhaps due to an upgrade of the 
 * underlying code, this could cause consumers of that interface to run it incorrectly, 
 * or even fail. Instead, you should create a new interface that extends the old one, perhaps 
 * including a version number, such as X2. This has become the standard way of doing things, 
 * and you are likely to come across numbered interfaces frequently.
 * 
 * One interface of particular interest is IDisposable. An object that supports the IDisposable
 * interface must implement the Dispose() method—that is, it must provide code for this method.
 * This method can be called when an object is no longer needed (just before it goes out of scope, 
 * for example) and should be used to free up any critical resources that might otherwise linger 
 * until the destructor method is called on garbage collection. This gives you more control 
 * over the resources used by your objects.
 * The using keyword enables you to initialize an object that uses critical resources in a 
 * code block, where Dispose() is automatically called at the end of the code block.
 * 
 * Interfaces, described earlier in this chapter, can also inherit from other interfaces. 
 * Unlike classes, interfaces can inherit from multiple base interfaces (in the same way that 
 * classes can support multiple interfaces).
 * 
 * Interface Polymorphism:
 * Although you can’t instantiate interfaces in the same way as objects, you can have a variable 
 * of an interface type. You can then use the variable to access methods and properties exposed 
 * by this interface on objects that support it.
 * For example, suppose that instead of an Animal base class being used to supply the EatFood()
 * method, you place this EatFood() method on an interface called IConsume. The Cow and Chicken
 * classes could both support this interface, the only difference being that they are forced to 
 * provide an implementation for EatFood() because interfaces contain no implementation. You 
 * can then access this method using code such as the following:
 *      Cow myCow = new Cow();
 *      Chicken myChicken = new Chicken();
 *      IConsume consumeInterface;
 *      consumeInterface = myCow;
 *      consumeInterface.EatFood();
 *      consumeInterface = myChicken;
 *      consumeInterface.EatFood();
 * This provides a simple way for multiple objects to be called in the same manner, 
 * and it doesn’t rely on a common base class. For example, this interface could be 
 * implemented by a class called VenusFlyTrap that derives from Vegetable instead of Animal:
 *      VenusFlyTrap myVenusFlyTrap = new VenusFlyTrap();
 *      IConsume consumeInterface;
 *      consumeInterface = myVenusFlyTrap;
 *      consumeInterface.EatFood();
 * In the preceding code snippets, calling consumeInterface.EatFood() results in the EatFood()
 * method of the Cow, Chicken, or VenusFlyTrap class being called, depending on which instance has
 * been assigned to the interface type variable.
 * Note here that derived classes inherit the interfaces supported by their base classes. 
 * Remember that classes with a base class in common do not necessarily
 * have interfaces in common, and vice versa.
 * 
 * As with classes, interfaces are defined as internal by default. To make an interface publicly 
 * accessible, you must use the public keyword:
        public interface IMyInterface
        {
        // Interface members.
        }
 * The keywords abstract and sealed are not allowed because neither modifier makes sense in the
 * context of interfaces (they contain no implementation, so they can’t be instantiated directly, 
 * and they must be inheritable to be useful).
 * Interface inheritance is also specified in a similar way to class inheritance. 
 * The main difference here is that multiple base interfaces can be used, as shown here:
        public interface IMyInterface : IMyBaseInterface, IMyBaseInterface2
        {
        // Interface members.
        }
 * Interfaces are not classes, and thus do not inherit from System.Object. However, the members of 
 * System.Object are available via an interface type variable, purely for convenience. In addition, as
 * already discussed, it is impossible to instantiate an interface in the same way as a class. 
 * 
 * Interface members are defined like class members except for a few important differences:
 *      ➤➤ No access modifiers (public, private, protected, or internal) are allowed—all 
 *          interface members are implicitly public.
 *      ➤➤ Interface members can’t contain code bodies.
 *      ➤➤ Interfaces can’t define field members.
 *      ➤➤ Interface members can’t be defined using the keywords static, virtual, abstract, 
 *          or sealed.
 *      ➤➤ Type definition members are forbidden.
 *
 * You can, however, define members using the new keyword if you want to hide members 
 * inherited from base interfaces:
        interface IMyBaseInterface
        {
            void DoSomething();
        }
        interface IMyDerivedInterface : IMyBaseInterface
        {
            new void DoSomething();
        }
 * This works exactly the same way as hiding inherited class members.
 * 
 * Properties defined in interfaces define either or both of the access blocks—get and 
 * set—which are permitted for the property, as shown here:
        interface IMyInterface
        {
            int MyInt { get; set; }
        }
 * Interfaces do not specify how the property data should be stored. Interfaces cannot specify
 * fields, for example, that might be used to store property data. 
 * 
 * Interfaces, like classes, can be defined as members of classes 
 * (but not as members of other interfaces because interfaces cannot contain type definitions).
 * 
 * A class that implements an interface must contain implementations for all members of that 
 * interface, which must match the signatures specified (including matching the specified 
 * get and set blocks), and must be public.
 * 
 */
