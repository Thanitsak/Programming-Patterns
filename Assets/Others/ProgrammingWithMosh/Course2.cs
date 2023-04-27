using UnityEngine;
using System;

public class Course2 : MonoBehaviour
{
    #region --Methods-- (Built In)
    private void Start()
    {
        try
        {
            TestError();
        }
        catch (Exception ex)
        {
            print(ex.Message);
        }
    }
    #endregion



    #region --Methods-- (Custom PRIVATE) ~Tester~
    private void TestError()
    {
        try
        {
            throw new Exception("LOWER LEVEL Exception");
        }
        catch (Exception ex)
        {
            print("TEST");
            throw new CustomException("My Custom Exception Error Message!!!!!!!!!!", ex);
        }
    }

    private void ParameterModifierTester()
    {
        ParamasModifier(1, 2, 3); // option 1
        ParamasModifier(new int[] { 1, 2, 3 }); // option 2

        int number = 1;
        RefModifier(ref number);
        print(number);

        // option 1
        int temp1;
        if (OutModifier(out temp1))
        {
            // do something ...
        }

        // option 2
        if (OutModifier(out int temp2))
        {
            // do something ...
        }

        print(temp1);
        print(temp2);


        InModifier(10);
    }
    #endregion



    #region --Methods-- (Custom PRIVATE) ~Parameter Modifier~
    private void ParamasModifier(params int[] values) // Must use with a single dimension array or Jagged array
    {
        foreach (int each in values)
        {
            print(each);
        }
    }

    private void RefModifier(ref int value)
    {
        value += 1;
    }

    private bool OutModifier(out int value)
    {
        value = 1;
        return true;
    }

    private void InModifier(in int value)
    {
        //value = 1; // error
        print(value);
    }
    #endregion
}