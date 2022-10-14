using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public static class Extension
{
    #region --Methods-- (Extension)
    public static void PrintLine<T>(this IEnumerable<T> collection, string starterText)
    {
        string textLine = $"[{collection.Count()}] {starterText}";

        var list = collection.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            textLine += (i != list.Count - 1) ? $"{list[i]}, " : $"{list[i]}";
        }

        Debug.Log(textLine);
    }

    public static void PrintLine<T1, T2>(this IEnumerable<T1> collection, string starterText, Func<T1, T2> selector)
    {
        if (selector == null)
        {
            throw new ArgumentNullException("predicate");
        }

        string textLine = $"[{collection.Count()}] {starterText}";

        var list = collection.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            textLine += (i != list.Count - 1) ? $"{selector.Invoke(list[i])}, " : $"{selector.Invoke(list[i])}";
        }

        Debug.Log(textLine);
    }

    public static void PrintLineWhere<T>(this IEnumerable<T> collection, string starterText, Func<T, bool> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentNullException("predicate");
        }

        int counter = 0;
        string textBody = "";

        var list = collection.ToList();
        for (int i = 0; i < list.Count; i++)
        {
            if (predicate.Invoke(list[i]))
            {
                textBody += (i != list.Count - 1) ? $"{list[i]}, " : $"{list[i]}";
                counter++;
            }
        }
        string textLine = $"[{counter}] {starterText}{textBody}";

        Debug.Log(textLine);
    }
    #endregion
}