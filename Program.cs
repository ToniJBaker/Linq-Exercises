using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
        
        // find words in the collection that start with the letter "L"   
        List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};
        IEnumerable<string> LFruits = from fruit in fruits
            where fruit.StartsWith("L")
            select fruit;

            foreach(string L in LFruits){
            // Console.WriteLine(L);
        }
        
            
        
        // Which of the following numbers are multiples of 4 or 6
        List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);
        foreach(int singleNumber in fourSixMultiples){
            // Console.WriteLine(singleNumber);
        }

        
        // Order these student names alphabetically, in descending order (Z to A)
        List<string> names = new List<string>()
        {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
        };
        List<string> descend = names.OrderByDescending(n => n).ToList();
        foreach(string eachName in descend){
            // Console.WriteLine(eachName);
        };
        
        
        
        // Build a collection of these numbers sorted in ascending order
        List<int> originalNumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        List<int> ascendingNumbers = originalNumbers.OrderBy(n => n).ToList();
        foreach(int N in ascendingNumbers){
            // Console.WriteLine(N);    
        };


        // Output how many numbers are in this list
        List<int> numbersThirdExample = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        }; 
        Console.WriteLine(numbersThirdExample.Count);


        // How much money have we made?
        List<double> purchases = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };
        
        
        double sum = 0;
        sum = purchases.Sum();
        Console.WriteLine(sum);

        //or

        
        // double sum = 0;
        // foreach(double finalNumber in purchases){
        //     sum += finalNumber;
        //     Console.WriteLine(sum);
        // }

       
       
        // What is our most expensive product?
        List<double> prices = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };
        Console.WriteLine(prices.Max(z => z));
        Console.WriteLine(prices.Min(z=>z));
        
        
        
        //Partitioning Operations
        /*
            Store each number in the following List until a perfect square
            is detected.

            Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

            Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
        */
        List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };
        IEnumerable<int> notSquared = 
            wheresSquaredo.TakeWhile(n => Math.Sqrt(n) % 1 !=0).ToList();
        foreach(int n in notSquared)
        {
            Console.WriteLine();
        };
        
        
               
       // Create some banks and store in a List
        List<Bank> banks = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };
       
        //  Create some customers  and store in a list
        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };
        // Build a collection of customers who are millionaires
        
                
        
                //Method Syntax
        List<Customer> millionaires = customers.Where(customer => customer.Balance > 999999).ToList();
        
        foreach(Customer singleMillionaire in millionaires){
            Console.WriteLine(singleMillionaire.Name);
        }
        //Given the same customer set, display how many millionaires per bank.
                //Method Syntax
        List<GroupedMillionaires> groupedByBank = customers.Where(c=> c.Balance > 999999).GroupBy(
            p => p.Bank, //Group Banks
            p => p.Name, //by millionaires
            (bank, millionaires)=> new GroupedMillionaires() 
            {
                Bank = bank,
                Millionaires = millionaires.ToList().Count
            }
        ).ToList();
        foreach(GroupedMillionaires item in groupedByBank)
        {
            Console.WriteLine($"{item.Bank}: {string.Join("and", item.Millionaires)}");
        }

                //Query Syntax (same as above)
        // var millionaires =
        // from customer in customers
        // where customer.Balance >=1000000 //filters out the millionaires
        // group customer by customer.Bank into customerBank //customerBank is an IGrouping
        // select new {name=customerBank.Key, count = customerBank.Count()};
        
        // foreach(var bank in millionaires)
        // {
        //     Console.WriteLine($"{bank.name}: {bank.count}");
        // }

        
        
        
        /*
    TASK:
    As in the previous exercise, you're going to output the millionaires,
    but you will also display the full name of the bank. You also need
    to sort the millionaires' names, ascending by their LAST name.

    Example output:
        Tina Fey at Citibank
        Joe Landy at Wells Fargo
        Sarah Ng at First Tennessee
        Les Paul at Wells Fargo
        Peg Vale at Bank of America
*/        
                //Query Syntax
        List<ReportItem> bankMillionaires = 
            (from customer in customers
            where customer.Balance >= 1000000
            orderby customer.Name.Split(" ")[1] //order ascending by last name [1]-refers to the last name
            join singleBank in banks on customer.Bank equals singleBank.Symbol //joins the two lists
            select new ReportItem(){CustomerName = customer.Name, BankName = singleBank.Name}).ToList();
        
        foreach(ReportItem b in bankMillionaires)
        {
            Console.WriteLine($"{b.CustomerName} at {b.BankName}");
        };

        }
    }
    
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class GroupedMillionaires
    {
        public int Millionaires {get; set;}
        public string Bank {get; set;}
    }
    public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}
public class ReportItem
{
    public string CustomerName { get; set; }
    public string BankName { get; set; }
}

}
