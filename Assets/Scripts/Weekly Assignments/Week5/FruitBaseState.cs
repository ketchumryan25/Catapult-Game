using UnityEngine;

public abstract class FruitBaseState
{
    public abstract void EnterState(FruitStateMachine fruit);

    public abstract void UpdateState(FruitStateMachine fruit);

    public abstract void ExitState(FruitStateMachine fruit);
}
