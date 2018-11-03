using System;
using System.Collections.Generic;
using System.Linq;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("_1-------------------------------------------------------------");
            //Object of StringDataStore can be used like an array to:
            //1)-add or retrive string data using int indexer.
            //2)-retrive index data using string indexer.
            StringDataStore strStore = new StringDataStore();

            strStore[0] = "One";
            strStore[1] = "Two";
            strStore[2] = "Three";
            strStore[3] = "Four";

            //Using int indexer
            Console.WriteLine("Return the name of index=0 by int indexer: "+strStore[0]);
            Console.WriteLine("Return the name of index=1 by int indexer: " + strStore[1]);

            //Using string indexer
            Console.WriteLine("Return the index of name=Three by string indexer: " + strStore["Three"]);
            Console.WriteLine("Return the index of name=FOUR by string indexer: " + strStore["FOUR"]);

            Console.WriteLine("_2-------------------------------------------------------------");
            //Using indexer with linq expression
            Customer cust1 = new Customer("Mohamed");
            cust1.AddOrder(10);
            cust1.AddOrder(20);
            cust1.AddOrder(30);

            //Return all the orders of a specific customer using indexer
            foreach (Order o in cust1["Mohamed"])
                Console.WriteLine($"The customer {o.CustomerName}, has the following orders: { o.OrderID }");

            //Return the customer name for a specific order using indexer
            foreach (Order o in cust1.Orders)
                Console.WriteLine($"for order number {o.OrderID}, The customer name is: { cust1[o.OrderID] }");

            Console.WriteLine("_3-------------------------------------------------------------");
            //Indexers with Multiple Parameters
            //Set or retrieve player name accoding to its board position using:
            //1)-multiple parameter indexer.
            //2)-string indexer.
            
            Board board = new Board();

            board["A", 4] = new Player("White King");
            board["H", 4] = new Player("Black King");

            Console.WriteLine("A4 = {0}", board["A", 4]);
            Console.WriteLine("H4 = {0}", board["H4"]);
            // A4 = White King
            // H4 = Black King
        }
    }

    //-------------How to use indexer in the custom class.
    class StringDataStore
    {
        private string[] strArr = new string[100]; // internal data storage

        public string this[int index]
        {
            get
            {
                if (index < 0 && index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 100 objects");

                return strArr[index];
            }

            set
            {
                if (index < 0 && index >= strArr.Length)
                    throw new IndexOutOfRangeException("Cannot store more than 100 objects");

                strArr[index] = value;
            }
        }

        //string typpe indexer
        public int this[string name]
        {
            get
            {
                for (int i=0; i< strArr.Length; i++)
                {
                    if(strArr[i].ToLower() == name.ToLower())
                        return i;
                }
                return -1;//If the name is not exist in strArr
            }
        }
    }

    //----------------------------------------------------------------------------------------
    public abstract class Animal
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Animal() => name = "The animal with no name";
        public Animal(string newName) => name = newName;
        public void Feed() => Console.WriteLine($"{name} has been fed.");
    }
    //-----------------Using Linq Expression with indexers--------------------------------------------
    public class Order
    {
        public int OrderID {get; set;}
        public string CustomerName { get; set; }
        public Order(int orderID, string customerName)
        {
            OrderID = orderID;
            CustomerName = customerName;
        }
    }
    public class Customer
    {
        public string CustomerName { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();

        public Customer(string customerName)
        {
            CustomerName = customerName;
        }

        public void AddOrder(int orderID)
        {
            Order order = new Order(orderID, CustomerName);
            Orders.Add(order);
        }

        //Pass the OrderId as a parameter in the indexer to retrieve the particular customer name.
        public string this[int orderID]
        {
            get
            {
                return (from o in Orders
                        where o.OrderID == orderID
                        select o.CustomerName).First();
            }
        }

        //Pass the CustomerName to retrive all the orders by that customer using indexer
        public IEnumerable<Order> this[string customerName]
        {
            get
            {
                return (from o in Orders
                        where o.CustomerName.ToLower() == customerName.ToLower()
                        select o);
            }
        }
    }

    //---------Indexers with Multiple Parameters----------------------------------------
    class Player
    {
        string name;

        public Player(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return (name);
        }
    }

    class Board
    {
        Player[,] board = new Player[8, 8];

        int RowToIndex(string row)
        {
            string temp = row.ToUpper();
            return ((int)temp[0] - (int)'A');
        }

        int PositionToColumn(string pos)
        {
            return (pos[1] - '0' - 1);
        }

        //multiple parameters indexer
        public Player this[string row, int column]
        {
            get
            {
                return (board[RowToIndex(row), column - 1]);
            }
            set
            {
                board[RowToIndex(row), column - 1] = value;
            }
        }

        //string indexer
        public Player this[string position]
        {
            get
            {
                return (board[RowToIndex(position),
                PositionToColumn(position)]);
            }
            set
            {
                board[RowToIndex(position),
                PositionToColumn(position)] = value;
            }
        }
    }


}
/*
 * An Indexer is a special type of property that allows a class or structure to be accessed 
 * the same way as array for its internal collection. It is same as property except that it 
 * defined with this keyword with square bracket and paramters.
 * 
 * Vsual studio provides shortcut way to insert a code snippet for an indexer so that you 
 * don't have to write entire syntax manually. To insert a snippet for an indexer in Visual 
 * Studio, write idexer and press tab or do right click (or Ctrl + K,S) -> select "Insert 
 * Snippet.." -> select "Visual C#.." -> select "indexer".
 * 
 * Indexers can have any valid access modifiers (public, protected internal, protected, 
 * internal, private or private protected). They may be sealed, virtual, or abstract. 
 * As with properties, you can specify different access modifiers for the get and set 
 * accessors in an indexer. You may also specify read-only indexers 
 * (by omitting the set accessor), or write-only indexers (by omitting the get accessor).
 * 
 * You can apply almost everything you learn from working with properties to indexers. 
 * The only exception to that rule is auto implemented properties. The compiler cannot 
 * always generate the correct storage for an indexer.
 * 
 * The presence of arguments to reference an item in a set of items distinguishes indexers 
 * from properties. You may define multiple indexers on a type, as long as the argument lists 
 * for each indexer is unique. Let's explore different scenarios where you might use one 
 * or more indexers in a class definition.
 * 
 * You should create indexers anytime you have a property-like element in your class where 
 * that property represents not a single value, but rather a collection of values where each 
 * individual item is identified by a set of arguments. Those arguments can uniquely identify 
 * which item in the collection should be referenced. Indexers extend the concept of 
 * properties, where a member is treated like a data item from outside the class, but like 
 * a method on the side. Indexers allow arguments to find a single item in a property that 
 * represents a set of items.
 * 
 * Points to Remember :
 *  An indexer is same as property except that it defined with this keyword with square 
 *    bracket that takes paramter.
 *  Indexer can be override by having different types of parameters.
 *  Ref and out parameter with the indexer is not supported.
 *  Indexer can be included as an interface member.
 *  Use code snippet to insert indexer syntax automatically in the visual studio.
 * 
 */
