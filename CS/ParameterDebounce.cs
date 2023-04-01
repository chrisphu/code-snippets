using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Class <c>ParameterDebounce</c> sends UnityEvent signal to listeners when the selected parameter value changes.
/// </summary>
public class ParameterDebounce : MonoBehaviour
{
    public enum ParameterType
    {
        Bool,
        Float
    }

    [Header("Trigger")]
    public ParameterType parameterType;
    public bool boolValue = false;
    public float floatValue = 0.0f;

    [Header("Unity event")]
    public UnityEvent onValueChanged;

    bool boolDebounce = false;
    float floatDebounce = 0.0f;

    void Start()
    {
        boolDebounce = boolValue;
        floatDebounce = floatValue;
    }

    void Update()
    {
        if (parameterType == ParameterType.Bool)
        {
            if (boolDebounce != boolValue)
            {
                boolDebounce = boolValue;
                onValueChanged.Invoke();
            }
        }
        else if (parameterType == ParameterType.Float)
        {
            if (floatDebounce != floatValue)
            {
                floatDebounce = floatValue;
                onValueChanged.Invoke();
            }
        }
    }
}
