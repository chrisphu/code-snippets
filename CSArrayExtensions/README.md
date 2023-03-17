# C# array extensions

## [Enumerate](Enumerate.cs)

This extension function returns a tuple array where each tuple contains the array element index and the original array element. This is intended to mirror the [enumerate function in Python](https://docs.python.org/3/library/functions.html?highlight=enumerate#enumerate).

### Example usage

#### Input

```cs
string[] values = {"hello", "world"};

foreach (var (index, value) in values.Enumerate())
{
    Console.WriteLine(index.ToString() + " " + value);
}
```

#### Output

```
0 hello
1 world
```

### Misc

- Found a more robust [IEnumerable extension function on StackOverflow](https://stackoverflow.com/a/45239105) after having already written this extension function.
