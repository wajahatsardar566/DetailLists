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
            // linqs method syntax
            var queryResults = names.Where(item => item.StartsWith("S"));

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
        public static void QueringCustomer(List<Customer> Customers)
        {
            var CustomerList = Customers.OrderByDescending(x => x.Country.Substring(x.Country.Count() - 1)).Where(x => x.Region == "Asia").Select(x => new { x.Country, x.City, x.Sales });
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
        public static void SelectDistinctQuery(List<Customer> Customers)
        {
            var queryResult = Customers.Select(x => x.Region).Distinct();
        }

    }
}
