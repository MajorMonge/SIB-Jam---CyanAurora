using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    [SerializeField]
    private State currentState;

    public State CurrentState
    {
        get { return currentState; }
        private set { currentState = value; }
    }

    protected virtual void Update()
    {
        CurrentState.OnUpdate(this);
    }

    public void ChangeState(State state)
    {
        if (CurrentState != null) CurrentState.OnFinish(this);
        CurrentState = state;
        CurrentState.OnStart(this);
    }
}