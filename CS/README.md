# C# code snippets

## [Enumerate](Enumerate.cs)

This extension function returns a tuple array where each tuple contains the array element index and the original array element. This is intended to mirror the [enumerate function in Python](https://docs.python.org/3/library/functions.html?highlight=enumerate#enumerate).

### Example usage

#### Script

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

- This file would actuallly be named `ArrayExtensions.cs` (the class name)
- Found a more robust [IEnumerable extension function on StackOverflow](https://stackoverflow.com/a/45239105) after having already written this extension function.

## [ParameterDebounce](ParameterDebounce.cs)

This Unity class sends a signal (UnityEvent) when the selected parameter value has changed.

### Example usage

#### Script

```cs
using UnityEngine;
using UnityEngine.Events;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] ParameterDebounce aKeyDebounce;    // parameterType = ParameterType.Bool
    
    void Start()
    {
        aKeyDebounce.onValueChanged.AddListener(aKeyDebounceTriggered); // Otherwise assigned in inspector
    }
    
    void Update()
    {
        aKeyDebounce.boolValue = Input.GetKey(KeyCode.A);
    }
    
    public void aKeyDebounceTriggered()
    {
        // ...
    }
}
```
