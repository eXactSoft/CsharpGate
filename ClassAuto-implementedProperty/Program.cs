using System;

namespace ClassAutoImplementedProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass cls = new TestClass();

            //Set the property without logic
            cls.MyProperty = 100;
            //Get the property without logic
            Console.WriteLine("Get the Property without logic: {0}", cls.MyProperty);


            //Set the property with logic (<100)
            cls.MyPropertyWithLogic = 100;
            //Get the property with logic
            Console.WriteLine("Get the Property with logic for <100: {0}", cls.MyPropertyWithLogic);
            //Set the property with logic (>100)
            cls.MyPropertyWithLogic = 300;
            //Get the property with logic
            Console.WriteLine("Get the Property with logic for >100: {0}", cls.MyPropertyWithLogic);

            //Set the auto implemented property
            cls.AutoImplementedProperty = 100;
            //Get the auto implemented property
            Console.WriteLine("Get the Auto Implemented Property (must be without logic): {0}", cls.AutoImplementedProperty);
        }
    }

    public class TestClass
    {
        private int _myPropertyVar;

        /*Property encapsulates a private field. It provides getters (get{}) to 
         * retrieve the value of the underlying field and setters (set{}) to set 
         * the value of the underlying field.
         */ 
        public int MyProperty
        {
            get { return _myPropertyVar; }
            set { _myPropertyVar = value; }
        }

        //Property that apply some addition logic in get and set
        public int MyPropertyWithLogic
        {
            get
            {
                return _myPropertyVar / 2;
            }

            set
            {
                if (value > 100)
                    _myPropertyVar = 500;
                else
                    _myPropertyVar = value; ;
            }
        }

        //Auto Implemented Property, provided that
        //no additional logic is required in the property accessors
        public int AutoImplementedProperty { get; set; }
    }
}
/*Auto-implemented Property:
 * From C# 3.0 onwards, property declaration has been made easy if you don't want 
 * to apply some logic in get or set.
 * Notice in the auto-implemented property there is no private backing field. 
 * The backing field will be created automatically by the compiler. You can work with 
 * an automated property as you would with a normal property of the class. 
 * Automated-implemented property is just for easy declaration of the property 
 * when no additional logic is required in the property accessors.
 */ 
