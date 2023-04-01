using System;

public static class ArrayExtensions
{
    /// <summary>
    /// Static (int, T)[] <c>Enumerate</c> returns a tuple array where each tuple contains: [0] the array element index, and [1] the original array element. This is intended to mirror the enumerate function in Python.
    /// </summary>
    public static (int, T)[] Enumerate<T>(this T[] input)
    {
        (int, T)[] output = new (int, T)[input.Length];
        
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = (i, input[i]);
        }
        
        return output;
    }
}
