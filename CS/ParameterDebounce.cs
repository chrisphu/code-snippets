using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

/// <summary>
/// Class <c>ParameterDebounce</c> sends UnityEvent signal to listeners when the selected parameter value changes.
/// </summary>
/// <list type="bullet">
/// <item>
/// <description><c>ParameterDebounce</c> cannot include generic T as Unity cannot display it in editor.</description>
/// </item>
/// <item>
/// <description>Use <c>public enum ParameterType</c> rather than <c>Type</c> to allow dropdown in Unity editor</description>
/// </item>
/// </list>
public class ParameterDebounce : MonoBehaviour
{
    public enum ParameterType
    {
        Bool,
        Float
    }

    [Header("Trigger")]
    [SerializeField] private ParameterType _valueType;
    [SerializeField] private bool _boolValue = false;
    [SerializeField] private float _floatValue = 0.0f;

    [Header("Unity event")]
    public UnityEvent OnValueChanged;

    private bool _boolDebounce = false;
    private float _floatDebounce = 0.0f;

    private void Awake()
    {
        _boolDebounce = _boolValue;
        _floatDebounce = _floatValue;
    }

    private void Update()
    {
        if (_valueType == ParameterType.Bool)
        {
            if (_boolDebounce != _boolValue)
            {
                _boolDebounce = _boolValue;
                OnValueChanged.Invoke();
            }
        }
        else if (_valueType == ParameterType.Float)
        {
            if (_floatDebounce != _floatValue)
            {
                _floatDebounce = _floatValue;
                OnValueChanged.Invoke();
            }
        }
    }

    /// <summary>
    /// Void <c>SetValue</c> sets <c>ParameterDebounce</c> value to given value.
    /// </summary>
    /// <typeparam name="T"><c>bool float</c></typeparam>
    /// <param name="value">Value of generic type to set <c>ParameterDebounce</c> value to.</param>
    public void SetValue<T>(T value)
    {
        if (typeof(T) == typeof(bool))
        {
            _boolValue = (bool)Convert.ChangeType(value, typeof(bool));
        }
        else if (typeof(T) == typeof(float))
        {
            _floatValue = (float)Convert.ChangeType(value, typeof(float));
        }
    }

    /// <summary>
    /// T <c>GetValue</c> returns <c>ParameterDebounce</c> stored value of given type.
    /// </summary>
    /// <typeparam name="T"><c>bool float</c></typeparam>
    public T GetValue<T>()
    {
        if (typeof(T) == typeof(bool))
        {
            return (T)Convert.ChangeType(_boolValue, typeof(T));
        }
        else if (typeof(T) == typeof(float))
        {
            return (T)Convert.ChangeType(_floatValue, typeof(T));
        }

        return default;
    }
}
