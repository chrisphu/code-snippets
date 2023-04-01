using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class <c>ParameterDebounce</c> sends UnityEvent signal to listeners when the selected parameter value changes.
/// </summary>
public class ParameterDebounce<T> : MonoBehaviour
{
    [Header("Parameter")]
    public T Value;

    [Header("Unity event")]
    public UnityEvent OnValueChanged;

    private T _valueDebounce;

    private void Awake()
    {
        _valueDebounce = Value;
    }

    private void Update()
    {
        if (!EqualityComparer<T>.Default.Equals(_valueDebounce, Value))
        {
            _valueDebounce = Value;
            OnValueChanged.Invoke();
        }
    }
}

// Normally in its own script BoolDebounce.cs
public class BoolDebounce : ParameterDebounce<bool> { }

// Normally in its own script FloatDebounce.cs
public class FloatDebounce : ParameterDebounce<float> { }
