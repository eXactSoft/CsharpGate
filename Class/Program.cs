using System;

namespace Class
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Using Polymorphism
            BaseClass BC = new BaseClass();
            BaseClass CC = new ChildClass();

            Console.WriteLine($"BC Type is: {BC.GetType()}");
            Console.WriteLine($"CC Type is: {CC.GetType()}");

            Console.WriteLine("_2-------------------------------------------------------------");
            //Passing a readonly field in the constructor
            BaseClass BC1 = new BaseClass("Ahmed");
            Console.WriteLine(BC1.ReadOnly);

            Console.WriteLine("_3-------------------------------------------------------------");
            // Calls the base class method as CC is of type BaseClass
            //Although the base implementation is hidden, you still have access to it through 
            //the base class.
            CC.HidingBaseMethod();//CC ChildClass of type BaseClass

            //See how derived class hide base class method
            ChildClass CC1 = new ChildClass();
            CC1.HidingBaseMethod();//CC1 ChildClass of type ChildClass

            Console.WriteLine("_4-------------------------------------------------------------");
            // Override the BaseClass method
            CC.OverridedMethod();

            CC1.OverridedMethod();

            Console.WriteLine("_5-------------------------------------------------------------");
            //have access to the hidden or ovrriden base class member from the derived class.
            //This will work with the followings:
            CC1.UsingBaseMethodHide();
            CC1.UsingBaseMethodOverride();
            CC.UsingBaseMethodOverride();
            //This will work with the following:
            //As the CC is ChildClass of type BaseClass so in this case it will calls the base
            //class version not the derived class version of UsingBaseMethodHide() method
            CC.UsingBaseMethodHide();

            Console.WriteLine("_6-------------------------------------------------------------");
            //Using this keyword to pass a reference to the current object instance to a method.
            //Your object is calling a function and wants to pass itself into it.
            BC.ThisSameOjectMethod(new BaseClass("Rose"));

            Console.WriteLine("_6-------------------------------------------------------------");
            //this keyword could be used to qualify member variables type, 
            //that you are referring to a member rather than a local variable.
            //the using of this keyword here is optional just a programming style
            Console.WriteLine(BC.ThisMemberProperty);

            Console.WriteLine("_7-------------------------------------------------------------");
            //Using this keyword to distinguish member variables from similar name local variables.
            BC.ThisLocalVariableMethod(10, 20);
            Console.WriteLine($"First Property is: {BC.First}, Second Property is: {BC.Second}");

            Console.WriteLine("_8-------------------------------------------------------------");
            //To instantiate MyNestedClass from outside MyClass, you must qualify the name, as shown here:
            MyClass.MyNestedClass myObj = new MyClass.MyNestedClass();
            Console.WriteLine(myObj.NestedClassField);

            Console.WriteLine("_9-------------------------------------------------------------");
            //Implement interface Implicitly & explicitly
            MyBaseImplementClass myClassBase = new MyBaseImplementClass();
            IMyInterface myIBase = new MyBaseImplementClass();
            MyDerivedImplementClass myClassDerived = new MyDerivedImplementClass();
            IMyInterface myIDerived = new MyDerivedImplementClass();

            //The method DoSomething() can only be accessed through the interface instance, 
            //as it is explicitly implemented
            //myClassBase.DoSomething(); //Fault
            //myClassDerived.DoSomething();//Fault

            //Only DoSomethingElse() method is accessible directly through the object instance,
            //as it is explicitly implemented, DoSomething() method could not directly accessible.
            myClassBase.DoSomethingElse();
            myClassDerived.DoSomethingElse();

            //DoSomething() & DoSomethingElse() methods are accessible directly through the interface instance,
            //as they are implicitly implemented
            myIBase.DoSomething();
            myIBase.DoSomethingElse();
            myIDerived.DoSomething();//interface implemented explicitly by base  
                                     //as no implementation on the derived class
            myIDerived.DoSomethingElse();

            Console.WriteLine("_10-------------------------------------------------------------");
            //Using object initializers to initialize members in a declarative manner without explicitly 
            //invoking a constructor for that member.
            BaseClass bc2 = new BaseClass { PropA = 70, PropB = 90 };
            Console.WriteLine(bc2.PropA);
            Console.WriteLine(bc2.PropB);

            Console.WriteLine("_11-------------------------------------------------------------");
            //Calling the static constructor of a class to initialize its static properties. 
            Console.WriteLine($"Static X={StaticConstractorClass.X}, Static Y={StaticConstractorClass.Y}");

            Console.WriteLine("_12-------------------------------------------------------------");
            //Calling a Derived Class Method from a Base Class with 2 ways with the same result
            DClass dvObj1 = new DClass();
            BClass dvObj2 = new DClass();

            dvObj1.CallMethod();
            dvObj2.CallMethod();//Same result as dvObj1
        }
    }


    //----------------Base Class Definition---------------------------------------------------
    public class BaseClass
    {
        private readonly string readOnlyField;

        private int someData;

        private int first, second;

        public int First => first;
        public int Second => second;

        public byte PropA { get; set; }
        public byte PropB { get; set; }

        //BaseClass default constructor
        public BaseClass()
        {
            someData = 100;
        }
        public BaseClass(string str)
        {
            readOnlyField = str;
        }
        public string ReadOnly
        {
            get { return readOnlyField; }
        }

        public void HidingBaseMethod()
        {
            Console.WriteLine("Base Class Method");
        }

        public virtual void OverridedMethod() => Console.WriteLine("Base imp");

        public void UsingBaseMethodHide() => Console.WriteLine("Base Hide imp");

        public virtual void UsingBaseMethodOverride() => Console.WriteLine("Base Override imp");

        //Using this keyword to have an object passes itself as a parameter 
        //to one of that object methods
        public void ThisSameOjectMethod(BaseClass bC)
        {
            Console.WriteLine($"Using this keyword: {bC.ReadOnly}");
        }

        //Using this keyword to qualify member variables type
        //the using of this keyword here is optional just a programming style
        public int ThisMemberProperty { get { return this.someData; } }
        //Equivelant to
        //public int SomeData => this.someData;
        //So you could use the following without this keyword
        //public int SomeData { get { return someData; } }

        //Using this keyword to distinguish member variables from similar name local variables
        public void ThisLocalVariableMethod(int first, int second)
        {

            this.first = first * 2;
            this.second = second * 2;
        }
    }

    //----------------Child Class Definition---------------------------------------------------
    public class ChildClass : BaseClass
    {
        //Default constructor
        public ChildClass() {  }

        /* Hiding base class method: This generates a warning that you are hiding a base class
         * member. That warning gives you the chance to correct it if you have accidentally 
         * hidden a member that you want to use.
         *   public void HidingBaseMethod()
         * If you really do want to hide the member, you can use the new keyword to explicitly 
         * indicate that this is what you want to do:
         */
        new public void HidingBaseMethod()
        {
            Console.WriteLine("Hiding Base Class Method");
        }

        // The overriding method replaces the implementation in the base class
        public override void OverridedMethod() => Console.WriteLine("Derived imp");

        new public void UsingBaseMethodHide()
        {
            base.UsingBaseMethodHide();
            Console.WriteLine("Derived Hide imp");
        }
        public override void UsingBaseMethodOverride()
        {
            base.UsingBaseMethodOverride();
            Console.WriteLine("Derived Override imp");
        }

    }

    //----------------------------Nested Type classes Definitions---------------------------------------
    public class MyClass
    {
        public class MyNestedClass
        {
            //The initialization feature for auto-property a similar way as fields are declared
            public int NestedClassField { get; } = 300;
        }
    }

    //-------------------------Interface and implicit or explicit implementation---------------
    public interface IMyInterface
    {
        void DoSomething();
        void DoSomethingElse();
    }
    public class MyBaseImplementClass : IMyInterface
    {
        void IMyInterface.DoSomething() { Console.WriteLine("interface implemented explicitly by base"); }
        public virtual void DoSomethingElse() { Console.WriteLine("interface implemented implicitly by base"); }
    }
    public class MyDerivedImplementClass : MyBaseImplementClass
    {
        public override void DoSomethingElse() { Console.WriteLine("interface implemented implicitly & overriden by derived"); }
    }

    //--------------------------------------------------------------------------------------
    public class StaticConstractorClass
    {
        public static int X { get; set; }
        public static int Y { get; set; }

        /*
        Constructors can be declared static to initialize static members only of the class.
        The static constructor is automatically called once when we access a static member 
        of the class.
        The static constructor will get called once when we try to access 
        StaticConstractorClass.X or StaticConstractorClass.Y.
        */
        static StaticConstractorClass()
        {
            X = 10;
            Y = 20;
        }
    }

    //------------------Seems to be a base class calling for a derived class method------------------
    class BClass
    {
        public virtual void PrintString()
        {
            Console.Write("Base Call");
        }
        public void CallMethod()
        {
            PrintString();
            //same as  this.PrintString();
        }
    }

    class DClass : BClass
    {
        public override void PrintString()
        {
            Console.WriteLine("Derived Call");
        }
    }

}
/*
 * A class is like a blueprint of specific object.
 * 
 * in object oriented programming, a class defines certain properties, fields, events, 
 * method etc. A class defines the kinds of data and the functionality their objects will have.
 * 
 * A class enables you to create your own custom types by grouping together variables of other 
 * types, methods and events.
 * 
 * The phrases instance of a class and object mean the same thing here; but class and object 
 * mean fundamentally different things.
 * 
 * The various pieces of data contained in an object together make up the state of that object.
 * 
 * Access modifiers are applied on the declaration of the class, method, properties, fields and 
 * other members. They define the accessibility of the class and its members. Public, private, 
 * protected and internal are access modifiers in C#. 
 * 
 * Field is a class level variable that can holds a value. Generally field members should have 
 * a private access modifier and used with a property.
 * 
 * A class can have parameterized or parameter less constructors. The constructor will be called 
 * when you create an instance of a class.
 * 
 * All class definitions contain at least one constructor. These constructors can include a 
 * default constructor, which is a parameter-less method with the same name as the class itself. 
 * A class definition might also include several constructor methods with parameters, 
 * known as nondefault constructors.
 * 
 * In C#, constructors are called using the new keyword. For example, you could instantiate a
 * CupOfCoffee object using its default constructor in the following way:
 *      CupOfCoffee myCup = new CupOfCoffee();
 * Objects can also be instantiated using nondefault constructors. For example, 
 * the CupOfCoffee class might have a nondefault constructor that uses a parameter to set 
 * the bean type at instantiation:
 *      CupOfCoffee myCup = new CupOfCoffee("Blue Mountain");
 * 
 * Constructors, like fields, properties, and methods, can be public or private. Code 
 * external to a class can’t instantiate an object using a private constructor; it must use 
 * a public constructor. In this way, you can, for example, force users of your classes to 
 * use a nondefault constructor (by making the default constructor private).
 * 
 * Destructors are used by the .NET Framework to clean up after objects. In general, you 
 * don’t have to provide code for a destructor method; instead, the default operation does 
 * the work for you.
 * However, you can provide specific instructions if anything important needs to be done 
 * before the object instance is deleted.
 * You don't have a control of the time that destructor c/o. Only when the .NET runtime 
 * performs its garbage collection clean-up is the instance completely destroyed.
 * 
 * Static members are shared between instances of a class, so they can be thought of 
 * as global for objects of a given class. Static properties and fields enable you to access 
 * data that is independent of any object instances, and static methods enable you to execute 
 * commands related to the class type but not specific to object instances. When using static 
 * members, in fact, you don’t even need to instantiate an object.
 * For example, the Console.WriteLine() and Convert.ToString() methods you have been using
 * are static. At no point do you need to instantiate the Console or Convert classes
 * You might use a static property to keep track of how many instances of a class have been 
 * created.
 * 
 * You can use a static constructor to perform initialization tasks of this type. A class 
 * can have a single static constructor, which must have no access modifiers and cannot have 
 * any parameters. A static constructor can never be called directly; instead, it is executed 
 * when one of the following occurs:
 *      ➤➤ An instance of the class containing the static constructor is created.
 *      ➤➤ A static member of the class containing the static constructor is accessed.
 * In both cases, the static constructor is called first, before the class is instantiated 
 * or static members accessed. No matter how many instances of a class are created, its 
 * static constructor will be called only once. To differentiate between static constructors 
 * and the constructors described earlier in this chapter, all nonstatic constructors are 
 * also known as instance constructors. 
 * 
 * Property encapsulates a private field. It provides getters (get{}) to retrieve the value of the 
 * underlying field and setters (set{}) to set the value of the underlying field.
 * You can also apply some addition logic in get and set.
 * 
 * Both fields and properties are typed, so you can store information in them as string values, 
 * as int values, and so on. However, properties differ from fields in that they don’t provide 
 * direct access to data. 
 * 
 * In general, it is better to provide properties rather than fields for state access because you 
 * have more control over various behaviors. This choice doesn’t affect code that uses object instances 
 * because the syntax for using properties and fields is the same.
 * 
 * One common practice is to make fields private and provide
 * access to them via public properties. This means that code within the class has direct 
 * access to data stored in the field while the public property shields external users from 
 * this data and prevents them from placing invalid content there. Public members are said to 
 * be exposed by the class.
 * 
 * Method is the term used to refer to functions exposed by objects.
 * 
 * Namespace is a container for a set of related classes and namespaces. Namespace is also used to give 
 * unique names to classes within the namespace name. Namespace and classes are represented using a dot (.).
 * 
 * Often, you will want to use classes that contain only static members and cannot be used to 
 * instantiate objects (such as Console). A shorthand way to do this, rather than make the 
 * constructors of the class private, is to use a static class. A static class can contain 
 * only static members and can’t have instance constructors, since by implication it can 
 * never be instantiated. Static classes can, however, have a static constructor,
 * 
 * Any class may inherit from another, which means that it will have all the members of the 
 * class from which it inherits. In OOP terminology, the class being inherited from (derived 
 * from) is the parent class (also known as the base class).
 * Classes in C# can derive only from a single base class directly, although of course that 
 * base class can have a base class of its own, and so on.
 * Inheritance enables you to extend or create more specific classes from a single, more 
 * generic base class.
 * 
 * Private members of the base class are not accessible from a derived class, but public
 * members are. However, public members are accessible to both the derived class and 
 * external code.
 * 
 * protected, in which only derived classes have access to a member. 
 * As far as external code is aware, this is identical to a private member—it
 * doesn’t have access in either case.
 * 
 * Members of a base class can be virtual, which means that the member can be overridden by
 * the class that inherits it. Therefore, the derived class can provide an alternative 
 * implementation for the member. This alternative implementation doesn’t delete the original 
 * code, which is still accessible from within the class, but it does shield it from external 
 * code. If no alternative is supplied, then any external code that uses the member through 
 * the derived class automatically uses the base class implementation of the member.
 * 
 * Virtual members cannot be private because that would cause a paradox—
 * it is impossible to say that a member can be overridden by a derived class at the
 * same time you say that it is inaccessible from the derived class.
 * 
 * Base classes may also be defined as abstract classes. An abstract class can’t be instantiated 
 * directly; to use it you need to inherit from it. Abstract classes can have abstract members, 
 * which have no implementation in the base class, so an implementation must be supplied in 
 * the derived class.
 * 
 * abstract base classes can provide implementation of members, which is very common. 
 * The fact that you can’t instantiate an abstract class doesn’t mean you can’t encapsulate 
 * functionality in it.
 * 
 * A class may be sealed. A sealed class cannot be used as a base class, so no derived classes 
 * are possible.
 * 
 * Interfaces, described earlier in this chapter, can also inherit from other interfaces. 
 * Unlike classes, interfaces can inherit from multiple base interfaces (in the same way that 
 * classes can support multiple interfaces).
 * 
 * C# provides a common base class for all objects called object (which is an alias for the 
 * System.Object class in the .NET Framework).
 * 
 * Polymorphism: One consequence of inheritance is that classes deriving from a base class 
 * have an overlap in the methods and properties that they expose. Because of this, it is 
 * often possible to treat objects instantiated from classes with a base type in common using 
 * identical syntax. For example, if a base class called Animal has a method called EatFood(), 
 * then the syntax for calling this method from the derived classes Cow and Chicken will be similar:
 *      Cow myCow = new Cow();
 *      Chicken myChicken = new Chicken();
 *      myCow.EatFood();
 *      myChicken.EatFood();
 * 
 * Polymorphism takes this a step further. You can assign a variable that is of a derived 
 * type to a variable of one of the base types, as shown here:
 *      Animal myAnimal = myCow;
 * No casting is required for this. You can then call methods of the base class through this 
 * variable:   myAnimal.EatFood();
 * This results in the implementation of EatFood() in the derived class being called. 
 * Note that you can’t call methods defined on the derived class in the same way. 
 * The following code won’t work: myAnimal.Moo();
 * However, you can cast a base type variable into a derived class variable and call the 
 * method of the derived class that way:
 *      Cow myNewCow = (Cow)myAnimal;
 *      myNewCow.Moo();
 * This casting causes an exception to be raised if the type of the original variable was 
 * anything other than Cow or a class derived from Cow.
 * 
 * Polymorphism is an extremely useful technique for performing tasks with a minimum of code 
 * on different objects descending from a single class. It isn’t just classes sharing the 
 * same parent class that can make use of polymorphism. It is also possible to treat, say, 
 * a child and a grandchild class in the same way, as long as there is a common class in 
 * their inheritance hierarchy.
 * As a further note here, remember that in C# all classes derive from the base class object 
 * at the root of their inheritance hierarchies. It is therefore possible to treat all objects 
 * as instances of the class object. This is how WriteLine() can process an almost infinite 
 * number of parameter combinations when building strings. 
 * Every parameter after the first is treated as an object instance, allowing output from any 
 * object to be written to the screen. To do this, the method ToString() (a member of object) 
 * is called. You can override this method to provide an implementation suitable for your 
 * class, or simply use the default, which returns the class name (qualified according to any
 * namespaces it is in).
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
 * Interfaces are a collection of public properties and methods that can be implemented
 * on a class. An instance-typed variable can be assigned a value of any object whose 
 * class definition implements that interface. 
 * Only the interfacedefined members are then available through the variable.
 * 
 * Child classes can override members that are defined as virtual in a parent class. 
 * All classes have an inheritance chain that ends in System.Object, which has the 
 * alias object in C#.
 * 
 * All objects instantiated from a derived class can be treated as if they were
 * instances of a parent class.
 * 
 * Relationships between Objects:
 *  ➤➤ Containment—One class contains another. This is similar to inheritance but allows 
 *  the containing class to control access to members of the contained class and even perform
 *  additional processing before using members of a contained class.
 *  ➤➤ Collections—One class acts as a container for multiple instances of another class. 
 *  This is  *  similar to having arrays of objects, but collections have additional functionality, 
 *  including indexing, sorting, resizing, and more.
 * 
 * Containment is simple to achieve by using a member field to hold an object instance.
 * This member field might be public, in which case users of the container object have access 
 * to its exposed methods and properties, much like with inheritance. However, you won’t have 
 * access to the internals of the class via the derived class, as you would with inheritance.
 * Alternatively, you can make the contained member object a private member. If you do this, 
 * then none of its members will be accessible directly by users, even if they are public. 
 * Instead, you can provide access to these members using members of the containing class. 
 * This means that you have complete control over which members of the contained class to 
 * expose, if any, and you can perform additional processing in the containing class members 
 * before accessing the contained class members.
 * 
 * A collection is basically an array with bells and whistles. Collections are implemented 
 * as classes in much the same way as other objects. They are often named in the plural form 
 * of the objects they store—for example, a class called Animals might contain a collection 
 * of Animal objects.
 * The main difference from arrays is that collections usually implement additional functionality, 
 * such as Add() and Remove() methods to add and remove items to and from the collection.
 * There is also usually an Item property that returns an object based on its index.
 * 
 * Events: Objects can raise (and consume) events as part of their processing. 
 * Events are important occurrences that you can act on in other parts of code, similar to 
 * (but more powerful than) exceptions.
 * You need to add an event handler to your code, which is a special kind of function that is 
 * called when the event occurs. You also need to configure this handler to listen for the event 
 * you are interested in.
 * 
 * One key difference between value types and reference types is that value types always contain a
 * value, whereas reference types can be null, reflecting the fact that they contain no value. It is, however,
 * possible to create a value type that behaves like a reference type in this respect (that is, it can
 * be null) by using nullable types. These are described in Chapter 12 when you look at the advanced
 * technique of generic types (which include nullable types).
 * The only simple types that are reference types are string and object, although arrays are implicitly
 * reference types as well. Every class you create will be a reference type, which is why this is
 * stressed her.
 * 
 * Static members are available only through the class definition directly, and are not associated with 
 * an instance.
 * 
 * By default, classes are declared as internal, meaning that only code in the current project will have 
 * access to them.
 * Alternatively, you can specify that the class is public and should also be accessible to 
 * code in other projects.
 * 
 * The compiler does not allow a derived class to be more accessible than its base class. 
 * This means that an internal class can inherit from a public base, but a public class can’t 
 * inherit from an internal base. This code is legal:
        public class MyBase
        {
            // Class members.
        }
        internal class MyClass : MyBase
        {
            // Class members.
        }

        The following code won’t compile:
        internal class MyBase
        {
            // Class members.
        }
        public class MyClass : MyBase
        {
            // Class members.
        }
 * 
 * All interface members must be implemented in any class that supports the interface, 
 * although you can provide an “empty” implementation (with no functional code) if you don’t 
 * want to do anything with a given interface member, and you can implement interface members 
 * as abstract in abstract classes.
 * 
 * Access Modifiers for Class Definitions:
 *      MODIFIER                    DESCRIPTION
 *      none or internal            Class is accessible only from within the current project.
 *      
 *      public                      Class is accessible from anywhere.
 *      
 *      abstract or                 Class is accessible only from within the current project, 
 *      internal abstract           and cannot be instantiated, only derived from.
 *      
 *      public abstract             Class is accessible from anywhere, and cannot be 
 *                                  instantiated, only derived from.
 *                                  
 *      sealed or                   Class is accessible only from within the current project,
 *      internal sealed             and cannot be derived from, only instantiated.
 *      
 *      public sealed               Class is accessible from anywhere, and cannot be derived 
 *                                  from, only instantiated.
 * 
 * GetType() is helpful when you are using polymorphism because it enables you to perform different
 * operations with objects depending on their type, rather than the same operation for all objects, 
 * as is often the case. For example, if you have a function that accepts an object type parameter 
 * (meaning you can pass it just about anything), you might perform additional tasks if certain 
 * objects are encountered. Using a combination of GetType() and typeof 
 * (a C# operator that converts a class name into a System.Type object), you can perform 
 * comparisons such as the following:
        if (myObj.GetType() == typeof(MyComplexClass))
        {
            // myObj is an instance of the class MyComplexClass.
        }
 * The System.Type object returned is capable of a lot more than that, but only this is covered here.
 * It can also be very useful to override the ToString() method, particularly in situations where
 * the contents of an object can be easily represented with a single human-readable string. 
 * 
 * You can also use a private default constructor, commonly utilized for classes that contain only 
 * static members. Setting the constructor to private means that instances of this class cannot be 
 * created using this constructor (it is non-creatable—again):
        class MyClass
        {
            private MyClass()
            {
                // Constructor code.
            }
        }
 * 
 * You can add nondefault constructors to your class, simply by providing parameters:
        class MyClass
        {
            public MyClass()
            {
                // Default constructor code.
            }
            public MyClass(int myInt)
            {
                // Nondefault constructor code (uses myInt).
            }
        }
 * 
 * The destructor used in .NET (and supplied by the System.Object class) is called Finalize(),
 * but this isn’t the name you use to declare a destructor. Instead of overriding Finalize(), 
 * you use the following:
        class MyClass
        {
            ~MyClass()
            {
                // Destructor body.
            }
        }
 * Thus, the destructor of a class is declared by the class name (just as the constructor is),
 * with the tilde (~) prefix. The code in the destructor is executed when garbage collection 
 * occurs, enabling you to free resources. After the destructor is called, implicit calls to 
 * the destructors of base classes also occur, including a call to Finalize() in the System.
 * Object root class. This technique enables the .NET Framework to ensure that this occurs 
 * because overriding Finalize() would mean that base class calls would need to be explicitly 
 * performed, which is potentially dangerous.
 * 
 * For a derived class to be instantiated, its base class must be instantiated. For this base 
 * class to be instantiated, its own base class must be instantiated, and so on all the way 
 * back to System.Object (the root of all classes). As a result, whatever constructor you use 
 * to instantiate a class, System.Object.Object() is always called first.
 * 
 * Regardless of which constructor you use in a derived class (the default constructor or 
 * a nondefault constructor), unless you specify otherwise, the default constructor for 
 * the base class is used.
 * 
 * If you have the following:
        public class MyBaseClass
        {
            public MyBaseClass()
            {
            }
            public MyBaseClass(int i)
            {
            }
        }
        public class MyDerivedClass : MyBaseClass
        {
            public MyDerivedClass()
            {
            }
            public MyDerivedClass(int i)
            {
            }
            public MyDerivedClass(int i, int j)
            {
            }
        }
 * If you instantiate MyDerivedClass as follows:
 *      MyDerivedClass myObj = new MyDerivedClass(4, 8); 
 * The sequence of constructors is as follows:
 *      ➤➤ The System.Object.Object() constructor will execute.
 *      ➤➤ The MyBaseClass.MyBaseClass() constructor will execute.
 *      ➤➤ The MyDerivedClass.MyDerivedClass(int i, int j) constructor will execute.
 * But what if you want to have the following sequence:
 *      ➤➤ The System.Object.Object() constructor will execute.
 *      ➤➤ The MyBaseClass.MyBaseClass(int i) constructor will execute.
 *      ➤➤ The MyDerivedClass.MyDerivedClass(int i, int j) constructor will execute.
 * C# allows you to specify this kind of behavior if you want.
 * To do this, you can use a constructor initializer, which consists of code placed after 
 * a colon in the method definition. For example, you could specify the base class 
 * constructor to use in the definition of the constructor in your derived class, as follows:
        public class MyDerivedClass : MyBaseClass
        {
            ...
            public MyDerivedClass(int i, int j) : base(i)
            {
            }
        }
 * The base keyword directs the .NET instantiation process to use the base class constructor, 
 * which has the specified parameters.
 * You can also use this keyword to specify literal values for base class constructors, 
 * perhaps using the default constructor of MyDerivedClass to call a nondefault constructor 
 * of MyBaseClass:
        public class MyDerivedClass : MyBaseClass
        {
            public MyDerivedClass() : base(5)
            {
            }
            ...
        }
 * This gives you the following sequence:
 *      ➤➤ The System.Object.Object() constructor will execute.
 *      ➤➤ The MyBaseClass.MyBaseClass(int i) constructor will execute.
 *      ➤➤ The MyDerivedClass.MyDerivedClass() constructor will execute.
 * 
 * this keyword instructs the .NET instantiation process to use a nondefault constructor on 
 * the current class before the specified constructor is called:
        public class MyDerivedClass : MyBaseClass
        {
            public MyDerivedClass() : this(5, 6)
            {
            }
            ...
            public MyDerivedClass(int i, int j) : base(i)
            {
            }
        }
 * Here, using the MyDerivedClass.MyDerivedClass() constructor gives you the following sequence:
 *      ➤➤ The System.Object.Object() constructor will execute.
 *      ➤➤ The MyBaseClass.MyBaseClass(int i) constructor will execute.
 *      ➤➤ The MyDerivedClass.MyDerivedClass(int i, int j) constructor will execute.
 *      ➤➤ The MyDerivedClass.MyDerivedClass() constructor will execute.
 * The only limitation here is that you can specify only a single constructor using a constructor initializer.
 * However this isn’t much of a limitation, because you can still construct sophisticated execution sequences.
 * 
 * NOTE If you don’t specify a constructor initializer for a constructor, the compiler
 * adds one for you: base(). This results in the default behavior described
 * earlier in this section.
 * 
 * Be careful not to accidentally create a circular reference when defining constructors. 
 * For example, consider this code:
        public class MyBaseClass
        {
            public MyBaseClass() : this(5)
            {
            }
            public MyBaseClass(int i) : this()
            {
            }
        }
 * Using either one of these constructors requires the other to execute first, which in 
 * turn requires the other to execute first, and so on. This code will compile, but if you 
 * try to instantiate MyBaseClass you will receive a SystemOverflowException.
 * 
 * that if a class definition doesn’t include a constructor, 
 * then the compiler adds a default constructor when you compile your code.
 * 
 * Class library projects compile into .dll assemblies, and you can access their contents by adding
 * references to them from other projects (which might be part of the same solution, 
 * but don’t have to be).
 * Select Project ➪ Add Reference…, or select the same option after right-clicking References 
 * in the Solution Explorer window.
 * 
 * NOTE When an application uses classes defined in an external library, you can call that 
 * application a client application of the library. Code that uses a class that you define 
 * is often similarly referred to as client code.
 * 
 * The similarities bet abstract classes and interfaces: Both abstract classes and interfaces 
 * can contain members that can be inherited by a derived class. Neither interfaces nor 
 * abstract classes can be directly instantiated, but it is possible to declare variables of 
 * these types. If you do, you can use polymorphism to assign objects that inherit from these 
 * types to variables of these types. In both cases, you can then use the members of these 
 * types through these variables, although you don’t have direct access to the other members 
 * of the derived object.
 * 
 * the differences bet abstract classes and interfaces: Derived classes can only inherit from 
 * a single base class, which means that only a single abstract class can be inherited directly 
 * Conversely, classes can use as many interfaces as they want, but this doesn’t make a massive 
 * difference—similar results can be achieved either way. It’s just that the interface way of 
 * doing things is slightly different.
 * Abstract classes can possess both abstract members and non-abstract members
 * Interface members, conversely, must be implemented on the class that uses the interface—they 
 * do not possess code bodies. 
 * Moreover, interface members are by definition public (because they are intended for external use), 
 * but members of abstract classes can also be private (as long as they aren’t abstract), 
 * protected, internal, or protected internal (where protected internal members are accessible 
 * only from code within the application or from a derived class). 
 * In addition, interfaces can’t contain fields, constructors, destructors, static members, 
 * or constants.
 * 
 * NOTE Abstract classes are intended for use as the base class for families of objects that 
 * share certain central characteristics, such as a common purpose and structure. 
 * Interfaces are intended for use by classes that might differ on a far more fundamental 
 * level but can still do some of the same things.
 * 
 * account. You can create a simple copy of an object where each member is copied to the new 
 * object by using the method MemberwiseClone(), inherited from System.Object. 
 * This is a protected method, but it would be easy to define a public method on an object 
 * that called this method. This copying method is known as a shallow copy, in that it 
 * doesn’t take reference type members into account. This means that reference members in 
 * the new object refer to the same objects as equivalent members in the source object, 
 * which isn’t ideal in many cases.
 * If you want to create new instances of the members in question by copying the values 
 * across (rather than the references), you need to perform a deep copy.
 * There is an interface you can implement that enables you to deep copy in a standard way:
 * ICloneable. If you use this interface, then you must implement the single method it 
 * contains, Clone(). This method returns a value of type System.Object.
 * 
 * You can use the public and internal keywords to define class and interface accessibility, 
 * and classes can be defined as abstract or sealed to control inheritance.
 * 
 * Constructors of base classes are executed before those of derived classes, and you can 
 * control the execution sequence within a class with the this and base constructor 
 * initializer keywords.
 * 
 * Public fields in the .NET Framework are named using PascalCasing, rather than camelCasing,
 * There is no recommendation for private fields, which are usually named using camelCasing.
 * 
 * Fields can also use the keyword readonly, meaning the field can be assigned a value only 
 * during constructor execution or by initial assignment
 * The readonly keyword is different from the const keyword. A const field can only be 
 * initialized at the declaration of the field. A readonly field can be initialized either 
 * at the declaration or in a constructor. Therefore, readonly fields can have different values 
 * depending on the constructor used.
 * You can use the keyword const to create a constant value. const members are static by 
 * definition, so you don’t need to use the static modifier (in fact, it is an error to do so).
 * 
 * Remember that if you use the static keyword, then this method is accessible only through the 
 * class, not the object instance. 
 * 
 * You can also use the following keywords with method definitions:
 *      ➤➤ virtual—The method can be overridden.
 *      ➤➤ abstract—The method must be overridden in non-abstract derived classes 
 *          (only permitted in abstract classes).
 *      ➤➤ override—The method overrides a base class method 
 *          (it must be used if a method is being overridden).
 *      ➤➤ extern—The method definition is found elsewhere.
 *      
 * property can be use the keyword value to refer to the value received from
        the user of the property:
        // Field used by property.
        private int myInt;
        // Property.
        public int MyIntProp
        {
            get { return myInt; }
            set { myInt = value; }
        }     
 * 
 * To provide a default value in case the integer allows null, this expression-bodied member 
 * function pattern works well:
        private int? myInt;
        public int? MyIntProp
        {
            get { return myInt; }
            set { myInt = value ?? 0; }
        }
 * 
 * Properties can use the virtual, override, and abstract keywords just like methods, 
 * something that isn’t possible with fields.
 * 
 * With an automatic property, you declare a property with a simplified syntax and the C# compiler 
 * fills in the blanks for you. Specifically, the compiler declares a private field that is used 
 * for storage, and uses that field in the get and set blocks of your property—without you having 
 * to worry about the details.
 * Use the following code structure to define an automatic property:
        public int MyIntProp { get; set; }
 * 
 * When you use an automatic property, you only have access to its data through the property, not
 * through its underlying private field. This is because you can’t access the private field without
 * knowing its name, which is defined during compilation.
 * 
 * You can create an automatically implemented property template by using the prop code snippet within 
 * Visual Studio. Type in “prop” then press the TAB key twice and the following, 
 * public int MyProperty {get; set;} is created for you.
 * 
 * It is important to know about the getter-only auto-properties. They are created by using the 
 * following syntax, notice that a setter is no longer required:
 *      public int MyIntProp { get; }
 * The initialization feature for auto-properties is implemented by the following which is 
 * similar to the way fields are declared:
 *      public int MyIntProp { get; } = 9;
 * 
 * Polymorphism is not working with hiding base class methods,
 * but it is working with overrride methods.
 * 
 * Whether you override or hide a member, you still have access to the base class member from 
 * the derived class. There are many situations in which this can be useful, such as the following:
 *  ➤➤ When you want to hide an inherited public member from users of a derived class but 
 *       still want access to its functionality from within the class
 *  ➤➤ When you want to add to the implementation of an inherited virtual member rather than
 *      simply replace it with a new overridden implementation To achieve this, you use the base keyword
 * 
 * As base works using object instances, it is an error to use it from within a static member.
 * 
 * this keyword can be used from within class members, and, like base, this refers to an 
 * object instance, although it is the current object instance (which means you can’t use 
 * this keyword in static members because static members are not part of an object instance).
 * 
 * The most useful function of the this keyword is the capability to pass a reference to the 
 * current object instance to a method, as shown in this example:
        public void doSomething()
        {
            MyTargetClass myObj = new MyTargetClass();
            myObj.DoSomethingWith(this);
        }
 * Here, the MyTargetClass instance that is instantiated (myObj) has a method called
 * DoSomethingWith(), which takes a single parameter of a type compatible with the class 
 * containing the preceding method. This parameter type might be of this class type, a 
 * class type from which this class derives, an interface implemented by the class, 
 * or (of course) System.Object.
 * 
 * Another common use of the this keyword is to use it to qualify member variable type, for example:
        public class MyClass
        {
            private int someData;
            public int SomeData => this.someData;
        }
 * Many developers like this syntax, which can be used with any member type, as it is 
 * clear at a glance that you are referring to a member variable rather than a local variable.
 * 
 * The this keyword refers to the current instance of the class. It can be used to access 
 * members from within constructors, instance methods, and instance accessors.
 * 
 * Static constructors and member methods do not have a this pointer because they are not 
 * instantiated.
 * 
 * When you are writing code in method or property of a class, using "this" will allow you 
 * to make use of the intellisense.
 * 
 * Static Member variable: a variable declared in the class definition with static keyword.
 * In sme context it is called: Class variable.
 * It can be said it is the variable at class level.
 * A static variable lasts as long as the class. There is one copy of it for the entire class.
        public MyClass
        {
            static int a; // static member variable
        }
 * 
 * Instance Member variable: a variable declared in a class definition without static keyword. 
 * It can be said it is the variable at object level.
 * An instance variable lasts as long as the instance of the class. There will be one copy of 
 * it per instance.
        public class MyClass {
        public int PropVar{get; set} 
        private int fieldVar;
        }
        // here PropVar & fieldVar are instance member variables.
 * 
 * Local variable: a variable declared inside a Method or at its parameters.
 * It can be said that it is the variable at Method level.
 * A local variable lasts until the method returns.
        public class MyClass {
            static void Method(int i) // i is a local variable
            {
                string name; //name is local variable
            }
        }
 * 
 * There are two kinds of member variable: instance and static.
 * 
 * A member variable is a member of a type and belongs to that type's state. 
 * A local variable is not a member of a type and represents local storage rather 
 * than the state of an instance of a given type, Example:
         class Foo
         {
            // This is a member variable - a new instance
            // of this variable will be created for each 
            // new instance of Foo.  The lifespan of this
            // variable is equal to the lifespan of "this"
            // instance of Foo.
            private int bar;

            public void Metthod()
            {
                // This is a local variable. Its lifespan
                // is determined by lexical scope.
                Foo foo;
            }
         }
 * 
 * Member variable lifespan is inside the class only.
 * Member variable is considered as Global Variable.
 * Member variable can be accessed by any method inside the same class.
 * 
 * The local variables have precedence over Member variables. (this keyword is very useful here)
        public class Demo
        {
            int age; //Default to 0
            string name; //Default to ""

            public Demo(int age, string name)
            {
                age = age;
                name = name; 
            }
        }
        static void Main(string[] args)
        {
            Demo dm = new Demo();
            dm.Demo(10, "Yahia");
            Conole.WriteLine(dm.age); ==> 0 not 10
            Conole.WriteLine(dm.age); ==> "" not "Yahia"
        }
 * 
 * There are several usages of this keyword in C#:
 *      To qualify members hidden by similar name
 *      To have an object pass itself as a parameter to other methods
 *      To have an object return itself from a method
 *      To declare indexers
 *      To declare extension methods
 *      To pass parameters between constructors
 *      To internally reassign value type (struct) value.
 *      To invoke an extension method on the current instance
 *      To cast itself to another type
 *      To chain constructors defined in the same class
 * 
 * A class that implements an interface must contain implementations for all members of that 
 * interface, which must match the signatures specified (including matching the specified 
 * get and set blocks), and must be public.
 * 
 * It is possible to implement interface members using the keyword virtual or abstract, 
 * but not static or const. 
 * 
 * Interface members can be implemented on base classes.
 * 
 * Inheriting from a base class that implements a given interface means that the interface 
 * is implicitly supported by the derived class.
 * 
 * Clearly, it is useful to define implementations in base classes as virtual so that 
 * derived classes can replace the implementation, rather than hide it.
 * 
 * If you were to hide a base class member using the new keyword, rather than override it in 
 * this way, the method IMyInterface.DoSomething() would always refer to the base class 
 * version even if the derived class were being accessed via the interface.
 * 
 * Interface members can be implemented explicitly by a class, so the member can only be accessed 
 * through the interface, not the class. ==> void IMyInterface.DoSomething() {}
 * 
 * Interface members can be implemented implicitly, so the member can be accessed either way,
 * through the interface, or the class. ==> public void DoSomething() {}
 * 
 * Use object initializers to initialize members in a declarative manner without explicitly 
 * invoking a constructor for that member.
 * The compiler processes object initializers by first accessing the default instance 
 * constructor and then processing the member initializations. 
 * Therefore, if the default constructor is declared as private in the class, 
 * object initializers that require public access will fail.
         StudentName student2 = new StudentName
         {
            FirstName = "Craig",
            LastName = "Playstead",
         };
 * 
 * You must use an object initializer if you're defining an anonymous type.
         var queryHighScores =
                from student in students
                where student.ExamScores[0] > 95
                select new { student.FirstName, student.LastName };
 * 
 * Collection initializer is a series of comma-separated object initializers.
 * To initialize a collection of StudentName types by using a collection initializer. 
        List<StudentName> students = new List<StudentName>()
        {
            new StudentName {FirstName="Craig", LastName="Playstead", ID=116},
            new StudentName {FirstName="Shu", LastName="Ito", ID=112},
            new StudentName {FirstName="Gretchen", LastName="Rivas", ID=113},
            new StudentName {FirstName="Rajesh", LastName="Rotti", ID=114}
        };
 * 
 * Partial class definitions. Put simply, you use partial class definitions to split the 
 * definition of a class across multiple files.
 * You just use the partial keyword with the class in each file that contains part of the 
 * definition, as follows:
 *      public partial class MyClass { ...}
 * If you use partial class definitions, the partial keyword must appear in this position 
 * in every file containing part of the definition.
 * 
 * Partial methods are defined in one partial class definition without a method body, and 
 * implemented in another partial class definition. In both places, the partial keyword is used:
        public partial class MyClass
        {
            partial void MyPartialMethod();
        }
        public partial class MyClass
        {
            partial void MyPartialMethod()
            {
            // Method implementation
            }
        }
 * 
 * Partial Class Requirements:
 *  All the partial class definitions must be in the same assembly and namespace.
 *  All the parts must have the same accessibility like public or private, etc.
 *  If any part is declared abstract, sealed or base type then the whole class is declared of the same type.
 *  Different parts can have different base types and so the final class will inherit all the base types.
 *  The Partial modifier can only appear immediately before the keywords class, struct, or interface.
 *  Nested partial types are allowed.
 * 
 * Advantages of Partial Class:
 *  Multiple developers can work simultaneously with a single class in separate files.
 *  When working with automatically generated source, code can be added to the class without 
 *  having to recreate the source file. 
 *  For example, Visual Studio separates HTML code for the UI and server side code into 
 *  two separate files: .aspx and .cs files. 
 * 
 * A partial class or struct may contain partial methods. A partial method must be declared 
 * in one of the partial classes. A partial method may or may not have an implementation. 
 * If the partial method doesn't have an implementation in any part then the compiler will 
 * not generate that method in the final class.
 * 
 * Requirements for Partial Method:
 *  The partial method declaration must began with the partial modifier.
 *  The partial method can have a ref but not an out parameter.
 *  Partial methods are implicitly private methods.
 *  Partial methods can be static methods.
 *  Partial methods can be generic.
 * 
 * Use the partial keyword to split interface, class, method or structure into multiple .cs files.
 * The partial method must be declared before implementation.
 * All the partial class, method , interface or structs must have the same access modifiers.
 * 
 * If you instantiate a derived class object that is of derived class type as:
 *      DerivedClass DV = new DerivedClass();
 * then all methods defined in the base class can be called in addition to the methods defined in the
 * derived class only can also be called.
 * 
 * If you instantiate a derived class object that is of base class type as:
 *      BaseClass DV = new DerivedClass();
 * then all methods defined in the base class can be called, but the methods defined in the
 * derived class only cannot be called.
 * 
 * If you instantiate a derived class object that is of interface type as:
 *      MyInterface DV = new DerivedClass();
 * then all methods defined in the interface can be called 
 * (even if these methods implemented by the DerivedClass explicitly) 
 * but the methods defined in the derived class only cannot be called.
 * 
 * If you instantiate a derived class object that is of derived class type but this 
 * derived class implement an interface type as:
 *      DerivedClass DV = new DerivedClass();
 * then all methods defined in the interface can be called, except the interface members that
 * implemented explicitly by a the DerivedClass eg ( void IMyInterface.DoSomething() {-----} )
 * also the methods defined in the derived class can be called. 
 * 
 * 
 * 
 * 
 * 
 */
