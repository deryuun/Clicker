using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableInt : MonoBehaviour
{
    public int _value;
    public System.Action<int> OnValueChanged;

    public int Value
    {
        get => _value;
        set
        {
            if(_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }

    public ObservableInt(int value)
    {
        _value = value;
    }
    // Start is called before the first frame update
}
