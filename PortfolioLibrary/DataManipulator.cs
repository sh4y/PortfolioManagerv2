using System;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

public class DataManipulator
{
    private static T[] Slice<T>(T[] source, int start, int end)
    {
        var len = end - start;

        // Return new array.
        var res = new T[len];
        for (var i = 0; i < len; i++)
            res[i] = source[i + start];
        return res;
    }

    public string[] GetRawData(string content)
    {
        var data = content.Split('\n');
        return Slice(data, 7, data.Length - 1);
    }

    public void GetDayInfoFromStrings(string[] data)
    {
        var pairs = new Dictionary<string, Type>();
        foreach (string line in data)
        {
            string[] info = line.Split(',');
            
        }
    }
}