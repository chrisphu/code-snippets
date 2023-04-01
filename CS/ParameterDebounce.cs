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
    [SerializeField] private T _value;

    [Header("Unity event")]
    public UnityEvent OnValueChanged;

    private T _valueDebounce;

    private void Awake()
    {
        _valueDebounce = _value;
    }

    private void Update()
    {
        if (!EqualityComparer<T>.Default.Equals(_valueDebounce, _value))
        {
            _valueDebounce = _value;
            OnValueChanged.Invoke();
        }
    }

    /// <summary>
    /// Void <c>SetValue</c> sets <c>ParameterDebounce</c> _value to given value.
    /// </summary>
    /// <param name="value">Value to set <c>ParameterDebounce</c> _value to.</param>
    public void SetValue(T value)
    {
        _value = value;
    }

    /// <summary>
    /// T <c>GetValue</c> returns <c>ParameterDebounce</c> _value.
    /// </summary>
    public T GetValue()
    {
        return _value;
    }
}
