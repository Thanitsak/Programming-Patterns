using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;

public class Course1 : MonoBehaviour
{
    private void Start()
    {
        //print(SentenceSummarizer("This is going to be a really really really really really long sentence.", 25));
    }

    private string SentenceSummarizer(string sentence, int maxLetters)
    {
        StringBuilder sb = new StringBuilder();
        int counter = 0;
        string[] words = sentence.Split(' ');

        foreach (string each in words)
        {
            if (counter + each.Length > maxLetters)
            {
                sb.Remove(sb.Length - 1, 1);
                sb.Append($"...");
                break;
            }

            counter += each.Length + 1;
            sb.Append($"{each} ");
        }

        return sb.ToString();
    }

    private void TestString()
    {
        // STRING
        string name = "Thanitsak";

        // Format
        string formatResult1 = name.ToLower(); // thanitsak
        string formatResult2 = name.ToUpper(); // THANITSAK

        // Search
        int searchResult1 = name.IndexOf('a'); // 2
        int searchResult2 = name.IndexOf("nit"); // 3
        int searchResult3 = name.LastIndexOf('a'); // 7
        int searchResult4 = name.LastIndexOf("nit"); // 3

        // Substring
        string subResult1 = name.Substring(2); // anitsak
        string subResult2 = name.Substring(4, 2); // it

        // Replace
        string replaceResult1 = name.Replace('a', 'b'); // Thbnitsbk
        string replaceResult2 = name.Replace("sak", "Boat"); // ThanitBoat

        // Useful Checker
        bool checkResult1 = string.IsNullOrEmpty(name); // False
        bool checkResult2 = string.IsNullOrWhiteSpace(name); // False

        // Split
        string[] splitResult = name.Split('a'); // Th, nits, k

        // Conversion
        int convertResult1 = Convert.ToInt32("1234"); // 1234
        //int convertResult2 = Convert.ToInt32(""); // Error
        int convertResult3 = int.Parse("1234"); // 1234
        //int convertResult4 = int.Parse(""); // Error

        // String Format Specifier
        int number = 12_345;
        string result1 = number.ToString("N0"); // 12,345
        string result2 = number.ToString("C"); // $12,345.00
        string result3 = $"{number:N0}"; // 12,345
        string result4 = $"{number:C}"; // $12,345.00


        print(formatResult1);
        print(formatResult2);

        print(searchResult1);
        print(searchResult2);
        print(searchResult3);
        print(searchResult4);

        print(subResult1);
        print(subResult2);

        print(replaceResult1);
        print(replaceResult2);

        print(checkResult1);
        print(checkResult2);

        foreach (string each in splitResult)
            print(each);

        print(convertResult1);
        print(convertResult3);

        print(result1);
        print(result2);
        print(result3);
        print(result4);
    }

    private void TestTimeSpan()
    {
        // TIMESPAN

        // Creating
        TimeSpan timeSpan1 = new TimeSpan(1, 2, 3);
        TimeSpan timeSpan2 = new TimeSpan(1, 62, 3);
        print(timeSpan1); // 01:02:03
        print(timeSpan2); // 02:02:03

        TimeSpan oneHourTimeSpan1 = new TimeSpan(1, 0, 0);
        TimeSpan oneHourTimeSpan2 = TimeSpan.FromHours(1);
        print(oneHourTimeSpan1); // 01:00:00
        print(oneHourTimeSpan2); // 01:00:00

        DateTime start = DateTime.Now;
        DateTime end = start.AddMinutes(62);
        TimeSpan duration = end - start;
        print(duration); // 01:02:00

        // Properties
        print(timeSpan1.Minutes); // 2
        print(timeSpan1.TotalMinutes); // 62.05

        // Adding & Subtracting
        print(timeSpan1.Add(TimeSpan.FromMinutes(5))); // 01:07:03
        print(timeSpan1.Add(new TimeSpan(0, 5, 0))); // 01:07:03
        print(timeSpan1.Subtract(TimeSpan.FromMinutes(5))); // 00:57:03
        print(timeSpan1.Subtract(new TimeSpan(0, 5, 0))); // 00:57:03

        // ToString
        print(timeSpan1.ToString()); // 01:02:03

        // Parse
        print(TimeSpan.Parse("01:02:59")); // 01:02:59
        print(TimeSpan.Parse("01:02:60")); // Error
    }

    private void TestDateTime()
    {
        // DATETIME
        DateTime dateTimeDefault = new DateTime();
        print(dateTimeDefault); // 01/01/0001 00:00:00

        DateTime today = DateTime.Today;
        DateTime now = DateTime.Now;
        DateTime utcNow = DateTime.UtcNow;
        print(today); // 03/12/2023 00:00:00
        print(now); // 03/12/2023 21:01:37
        print(utcNow); // 03/12/2023 14:01:37

        DateTime tomorrow = now.AddDays(1);
        DateTime yesterday = now.AddDays(-1);
        print(tomorrow); // 03/13/2023 21:01:37
        print(yesterday); // 03/11/2023 21:01:37

        print(now.ToLongDateString()); // Sunday, March 12, 2023
        print(now.ToShortDateString()); // 3/12/2023
        print(now.ToLongTimeString()); // 9:01:37 PM
        print(now.ToShortTimeString()); // 9:01 PM
        print(now.ToString()); // 3/12/2023 9:01:37 PM
        print(now.ToString("dd-MM-yyyy HH mm ss")); // 12-03-2023 21 01 37
    }

    private void TestArraysAndLists()
    {
        //ARRAYS AND LISTS
        List<int> tempList = new List<int>() { 1, 2, 5, 3, 2, 1, 5, 9, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        PrintList(tempList);

        // My Solution
        Remove1FromBoat(tempList);
        PrintList(tempList);

        //Lecturer Solution
        //Remove1FromLecturer(tempList);
        //PrintList(tempList);
    }

    private void Remove1FromBoat(List<int> tempList)
    {
        while (tempList.Remove(1))
            tempList.Remove(1);
    }

    private void Remove1FromLecturer(List<int> tempList)
    {
        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i] == 1)
                tempList.Remove(1);
        }
    }

    private void PrintList<T>(List<T> list)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("{ ");
        for (int i = 0; i < list.Count; i++)
            sb.Append((i == list.Count - 1) ? $"{list[i]}" : $"{list[i]}, ");
        sb.Append(" }");

        print(sb);
    }
}