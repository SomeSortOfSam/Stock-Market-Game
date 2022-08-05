using System;
using UnityEngine;

[Serializable]
/// Requires Unity 2020.1+
public struct Optional<T>
{
    [SerializeField] private bool enabled;
    [SerializeField] private T value;

    public bool Enabled => enabled;
    public T Value => value;

    public Optional(T initialValue)
    {
        enabled = true;
        value = initialValue;
    }

    public static implicit operator Optional<T>(T t) => new Optional<T>(t);
    public static implicit operator T(Optional<T> t) => t.value;
    public static implicit operator bool(Optional<T> t) => t.enabled;
}
