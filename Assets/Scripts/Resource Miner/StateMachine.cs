using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State firstState;

    private State _currentState;

    private void Start()
    {
        _currentState = firstState;
        _currentState.Enter();
    }

    private void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();
        if (nextState != null)
            SwitchState(nextState);
    }

    private void SwitchState(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = nextState;

        if (_currentState != null)
            _currentState.Enter();
    }
}
