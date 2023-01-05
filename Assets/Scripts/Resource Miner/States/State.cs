using UnityEngine;

public abstract class State : MonoBehaviour
{
    [SerializeField] private Transition[] transitions;

    public void Enter()
    {
        if (enabled == false)
        {
            enabled = true;

            foreach (var transition in transitions)
                transition.enabled = true;
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach(var transition in transitions)
            {
                transition.enabled = false;
            }
            enabled = false;
        }
    }

    public State GetNextState()
    {
        foreach(var transition in transitions)
        {
            Debug.Log(transition.NeedSwitch);
            if (transition.NeedSwitch)
            {
                return transition.NextState;
            }
        }

        return null;
    }
}
