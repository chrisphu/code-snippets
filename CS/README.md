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

## [LocalTransformExtensions](LocalTransformExtensions.cs)

In Unity, properties such as `transform.right` are given in world space. These Unity extension functions allows for an easy way to call their local versions.

### Example usage

#### Script

```cs
using UnityEngine;

public class ExampleClass : MonoBehaviour
{
    void Start()
    {
        transform.rotation *= Quaternion.AngleAxis(180.0f, transform.LocalRight());
    }
}
```

### Misc

- Simple answer on converting from world space to a transform's local space was found on [Unity Answers](https://answers.unity.com/questions/316918/local-forward.html)

## [ParameterDebounce](ParameterDebounce.cs)

This Unity class sends a UnityEvent signal to listeners when the selected parameter value has changed. A class inheriting `ParameterDebounce.cs` (ex. `public class BoolDebounce : ParameterDebounce<bool> { }`) can be attached as a component.

### Example usage

#### Script

```cs
using UnityEngine;
using UnityEngine.Events;

public class ExampleClass : MonoBehaviour
{
    [SerializeField] private BoolDebounce _bKeyValueDebounce;   // Assign in editor

    private void Awake()
    {
        _bKeyValueDebounce.OnValueChanged.AddListener(BKeyValueChanged);
    }
    
    private void Update()
    {
        // Setting value example
        _bKeyValueDebounce.Value = Input.GetKey(KeyCode.B);
        
        // Getting value example
        bool exampleBool = _bKeyValueDebounce.Value;
    }
    
    private void BKeyValueChanged()
    {
        // ...
    }
}
```

### Misc

- Base generic T class `ParameterDebounce` cannot be attached as component in Unity editor
- `public UnityEvent OnValueChanged;` can be replaced with `public UnityEvent<T> OnValueChanged;` if needing to send a dynamic signal
    - `OnValueChanged.Invoke();` then also needs to be replaced with `OnValueChanged.Invoke(Value);`
