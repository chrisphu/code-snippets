public static class ArrayExtensions
{
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
