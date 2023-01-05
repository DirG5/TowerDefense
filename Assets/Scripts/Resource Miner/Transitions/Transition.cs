using System;
using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State nextState;

    public bool NeedSwitch { get; protected set; }

    public State NextState
    {
        get => nextState;
    }

    private void OnEnable()
    {
        NeedSwitch = false;
    }

    private void OnDisable()
    {
        NeedSwitch = false;
    }
}
