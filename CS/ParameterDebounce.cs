using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class <c>ParameterDebounce</c> sends UnityEvent signal to listeners when the selected parameter value changes.
/// </summary>
public class ParameterDebounce<T> : MonoBehaviour
{
    [Header("Initial value")]
    [SerializeField] private T value;

    [Header("Unity event")]
    public UnityEvent OnValueChanged;

    private T _valueDebounce;

    private void Awake()
    {
        _valueDebounce = value;
    }

    private void Update()
    {
        if (!EqualityComparer<T>.Default.Equals(_valueDebounce, value))
        {
            _valueDebounce = value;
            OnValueChanged.Invoke();
        }
    }

    /// <summary>
    /// Void <c>SetValue</c> sets <c>ParameterDebounce</c> value to given value.
    /// </summary>
    /// <param name="value">Value to set <c>ParameterDebounce</c> value to.</param>
    public void SetValue(T value)
    {
        this.value = value;
    }

    /// <summary>
    /// T <c>GetValue</c> returns <c>ParameterDebounce</c> value.
    /// </summary>
    public T GetValue()
    {
        return value;
    }
}

// Normally in separate script BoolDebounce.cs
public class BoolDebounce : ParameterDebounce<bool> { }

// Normally in separate script FloatDebounce.cs
public class FloatDebounce : ParameterDebounce<float> { }
