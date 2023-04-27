using System.Collections.Generic;
using UnityEngine;
using System;

public class CleanCode : MonoBehaviour
{
    private void Start()
    {
        (string Name, float Price) item = ("Sock", 12.99f);
        print(item.Name); //Sock
        print(item.Price); //12.99

        (string Name, _) = item;
        print(Name); //Sock


        Tuple<string, float> tuple = Tuple.Create("Sock", 12.99f);
        Tuple<string, float> tuple2 = new Tuple<string, float>("Sock", 12.99f);


        //tuple.Item1 = "NewName";

        (string, int) test = ("test", 0);
        print(test.Item2);
        test.Item2 = 1;
        print(test.Item2);

        (string NewVariable1, int NewVariable2, _) = ("A", 5, 1.1f);
        print(NewVariable1);
        print(NewVariable2);

        // TODO comments;




        Dictionary<int, (string, string)> temp = new();

        temp.Add(0, ("Name", "Name2"));
        temp.Add(0, ("Name", "Name2"));
    }
}
