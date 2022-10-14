using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExperiment : MonoBehaviour
{
    #region --Fields-- (In Class)
    private string[] _cities = { "Bangkok", "New York", "Rome", "Paris", "Istanbul", "Amsterdam", "Hong Kong", "Rome", "Bangkok", "Paris" };
    private List<Employee> _employees = new List<Employee>
    {
        new Employee() { firstName = "Harvey", lastName = "Marshall", age = 24, salary = 50000f },
        new Employee() { firstName = "Edmond", lastName = "Dawson", age = 45, salary = 30000f },
        new Employee() { firstName = "Jesse", lastName = "Elliott", age = 59, salary = 250000f },
        new Employee() { firstName = "Prudence", lastName = "Harrett", age = 37, salary = 100000f },
        new Employee() { firstName = "Myra", lastName = "Barker", age = 18, salary = 500000f }
    };
    #endregion



    #region --Methods-- (Built In)
    private void Start()
    {
        // Query Syntax to Method Syntax
        IEnumerable<Employee> queryAdult =
            from employee in _employees
            where employee.age >= 30
            select employee;

        IEnumerable<Employee> methodAdult = _employees.Where(e => e.age > 30);

        queryAdult.PrintLine("QuerySyntax : ", e => e.age);
        methodAdult.PrintLine("MethodSyntax : ", e => e.age);


        // Any - check whether at least one of the elements satisfies a given condition or not. (CAN check base on Specific Class Member, Ex - Exployee.age)
        bool isFoundParis = _cities.Any(x => x == "Paris");
        print($"Cities == \"Paris\" (.Any): {isFoundParis}");
        bool isFoundAge = _employees.Any(x => x.age <= 25);
        print($"Employees Age <= 25 (.Any): {isFoundAge}");


        // Contains - check whether the element is exist in the Collection or not. (CAN NOT check base on Specific Class Member, Ex - Exployee.age)
        bool isFoundParis2 = _cities.Contains("Paris");
        print($"Cities == \"Paris\" (.Contains) : {isFoundParis2}");


        // Distinct - creates new Collection without any duplicates.
        var uniqueCities = _cities.Distinct();
        uniqueCities.PrintLine("Unique Cities : ");


        // Where - creates new Collection base on a given condition.
        var longCities = _cities.Where(s => s.Length > 8);
        longCities.PrintLine("Long Cities : ");
        // custom Extension Method, check Programming Patterns project -> Extension.cs
        _cities.PrintLineWhere("Long Cities (Extension Method) : ", s => s.Length > 8);

        // testing Func<T, int, bool> usually we don't need this 'int' , but it refers to the 'index' in the collection.
        var testFuncInt = _employees.Where((Employee e, int i) => { print($"{e.firstName} / {i}, "); return true; });


        // OrderByDescending
        var sortedByAgeDesc = _employees.Where(e => e.age <= 30).OrderByDescending(e => e.age);
        sortedByAgeDesc.PrintLine("Sorted Desc : ", e => e.age);

        var sortedByAgeDescReverse = _employees.Where(e => e.age <= 30).OrderByDescending(e => e.age).Reverse();
        sortedByAgeDescReverse.PrintLine("Sorted Desc Reverse : ", e => e.age);


        // Average
        var averageSalary = _employees.Average(e => e.salary);
        print($"Average Salary : {averageSalary}");


        // Count
        var everyone = _employees.Count();
        print($"Everyone : {everyone}");

        var adult = _employees.Count(e => e.age > 30);
        print($"Adult : {adult}");


        // Min & Max
        var youngest = _employees.Min(e => e.age);
        print($"Youngest : {youngest}");

        var oldest = _employees.Max(e => e.age);
        print($"Oldest : {oldest}");


        // ForEach
        //_cities.ToList().ForEach(s => print($"{s}"));
    }
    #endregion



    #region --Methods-- (Subscriber)
    private bool Checker(string x) // We can even pass this in for Func<>
    {
        return (x == "Paris");
    }
    #endregion



    #region --Classes-- (Custom PRIVATE)
    private class Employee
    {
        public string firstName;
        public string lastName;
        public int age;
        public float salary;
    }
    #endregion
}