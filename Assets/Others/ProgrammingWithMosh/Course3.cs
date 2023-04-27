//public class Course3<T> where T : struct
//{
//    T item;

//    public void UpdateItem(T newItem)
//    {
//        item = newItem;
//    }
//}

//public class Course3
//{
//    public void GenericMethod<T>(T newItem) where T : class
//    {
        
//    }
//}

using System;
public class CustomException : Exception
{
    public CustomException() : base()
    {
    }
    public CustomException(string message) : base(message)
    {
    }
    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}