using System;
using System.Collections.Generic;
using System.Linq;

// Define a bank
public class Bank
{
    public string Symbol { get; set; }
    public string Name { get; set; }
}

// Define a customer
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}


namespace expression_members
{
    class Program
    {
        static void Main(string[] args)
        {
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

            /*
                Given the same customer set, display how many millionaires per bank.
            */

            var groupedByBank = customers
                .Where(x => x.Balance >= 1_000_000d)
                .GroupBy(x => x.Bank)
                .Select(x => new { Bank = x.Key, Millionaires = from customer in x select customer.Name });


            foreach (var item in groupedByBank)
            {
                Console.WriteLine($"{item.Bank}: {string.Join(" and ", item.Millionaires)}");
            }

            //WF: Joe Landy and Les Paul
            //BOA: Peg Vale
            //FTB: Sarah Ng
            //CITI: Tina Fey

            Console.WriteLine();

            // Create some banks and store in a List
            List<Bank> banks = new List<Bank>() {
                new Bank(){ Name="First Tennessee", Symbol="FTB"},
                new Bank(){ Name="Wells Fargo", Symbol="WF"},
                new Bank(){ Name="Bank of America", Symbol="BOA"},
                new Bank(){ Name="Citibank", Symbol="CITI"},
            };

            List<Customer> millionaireReport = (from x in customers
                                                join y in banks on x.Bank equals y.Symbol
                                                where x.Balance >= 1_000_000d
                                                select new Customer { Name = x.Name, Bank = y.Name }).ToList();

            foreach (var customer in millionaireReport)
            {
                Console.WriteLine($"{customer.Name} at {customer.Bank}");
            }

            // Joe Landy at Wells Fargo
            // Peg Vale at Bank of America
            // Les Paul at Wells Fargo
            // Sarah Ng at First Tennessee
            // Tina Fey at Citibank

        }
    }
}