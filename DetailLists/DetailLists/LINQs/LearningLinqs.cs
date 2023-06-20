namespace DetailLists.LINQs
{
    internal static class LearningLinqs
    {
        public static void SelectItem(List<string> names)
        {
            // linqs Query syntax
            var queryResults =
             from n in names
             where n.StartsWith("S")
             select n;

            // linqs method syntax
            var queryMehodResults = names.Where(item => item.StartsWith("O"));
            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }
        }
        public static void SelectItemUsingLinqMethodSyntex(List<string> names)
        {
            var queryResults = names.Where(item => item.StartsWith("O"));

            foreach (var item in queryResults)
            {
                Console.WriteLine(item);
            }
        }
        public static void OrderingQueryResult(List<string> names)
        {
            Console.WriteLine("Names beginning with S:");
            var Names = names.OrderBy(x => x).Where(x => x.StartsWith("S"));  // Linq Method Syntax;
            foreach (var name in Names)
                Console.WriteLine(name);

            //Decending Order by the last alphabet of the world
            Console.WriteLine("Names beginning with S In Decending Order :");
            var result = names.OrderByDescending(x => x.Substring(x.Count() - 1)).Where(x => x.StartsWith("S"));
            foreach (var name in result)
                Console.WriteLine(name);
        }
        public static void QueringCustomer(List<Customer> customers)
        {
            // Decending Order by the last alphabet of the world
            var CustomerList = customers.OrderByDescending(x => x.Country.Substring(x.Country.Count() - 1)).Where(x => x.Region == "Asia").Select(x => new { x.Country, x.City, x.Sales });
            foreach (var customer in CustomerList)
                Console.WriteLine(customer);
        }
        public static void LinqsProjection(List<Customer> customers)
        {
            // Projection is the technical term for creating a new data type from other data types in a LINQ query.
            var Customers = customers.Select(x => new { x.Country, x.City, x.Sales });
            foreach (var customer in Customers)
                Console.WriteLine(customer);
        }
        public static void SelectDistinctQuery(List<Customer> customers)
        {
            // Distict for removing duplicat
            var queryResult = customers.Select(x => x.Region).Distinct();
        }
        public static void AnyMethod(List<Customer> customers)
        {

            // The LINQ Any() method applies the lambda expression you pass to it — c => c.Country == "USA"
            // against the data in the customers list
            // and returns true if the lambda expression is true for any of the customers in the list.

            bool anyUSA = customers.Any(c => c.Country == "USA");
            if (anyUSA)
            {
                Console.WriteLine("Some customers are in the USA");
            }
            else
            {
                Console.WriteLine("No customers are in the USA");
            }
        }
        public static void AllMethod(List<Customer> customers)
        {

            //The LINQ All() method applies the lambda expression against the data set and returns false, as
            //you would expect, because some customers are outside of Asia. You then print the appropriate
            //message based on the value of allAsia.

            bool allAsia = customers.All(c => c.Region == "Asia");
            if (allAsia)
            {
                Console.WriteLine("All customers are in Asia");
            }
            else
            {
                Console.WriteLine("Not all customers are in Asia");
            }
        }
        public static void MultiLevelOrdering(List<Customer> customers)
        {
            var Customers = customers.OrderBy(c => c.Region)
                .ThenBy(c => c.Country)
                .ThenBy(c => c.City)
                .ThenBy(c => c.Sales)
                .Select(c => new
                {
                    c.Region,
                    c.Country,
                    c.City,
                    c.Sales
                });

            foreach (var customer in Customers)
                Console.WriteLine(customer);
        }
        public static void GroupQuery(List<Customer> customers)
        {
            var queryResult = customers.GroupBy(c => c.Region)
                .Select(cg => new
                {
                    TotalSales = cg.Sum(c => c.Sales),
                    Region = cg.Key
                });

            var orderedResults = queryResult.OrderByDescending(cg => cg.TotalSales);

            foreach (var c in orderedResults)
                Console.WriteLine(c);
        }
    }
}
