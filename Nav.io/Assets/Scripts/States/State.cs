using UnityEngine;

public abstract class State {

    public abstract void OnStart(StateMachine sm);
    public abstract void OnUpdate(StateMachine sm);
    public abstract void OnFinish(StateMachine sm);
}
