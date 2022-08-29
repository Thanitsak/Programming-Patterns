using UnityEngine;

/*
    In Reality, we put these classes and interface into their separate files.
    We could also have Update() within each of the State, so that it only runs when we are in specific State.
 */

public interface LocomotionContext
{
    void SetState(LocomotionState newState);
}

public interface LocomotionState
{
    void Jump(LocomotionContext context);
    void Fall(LocomotionContext context);
    void Land(LocomotionContext context);
    void Crouch(LocomotionContext context);
}

public class LocomotionStatePattern : MonoBehaviour, LocomotionContext
{
    LocomotionState currentState = new GroundedState();

    public void Crouch() => currentState.Crouch(this);

    public void Fall() => currentState.Fall(this);

    public void Jump() => currentState.Jump(this);

    public void Land() => currentState.Land(this);

    void LocomotionContext.SetState(LocomotionState newState)
    {
        currentState = newState;
    }
}

public class GroundedState : LocomotionState
{
    public void Crouch(LocomotionContext context)
    {
        // **** Usually we have to enact some code here, not just changing the state ****
        context.SetState(new CrouchingState());
    }

    public void Fall(LocomotionContext context)
    {
        // **** Usually we have to enact some code here, not just changing the state ****
        context.SetState(new InAirState());
    }

    public void Jump(LocomotionContext context)
    {
        // **** Usually we have to enact some code here, not just changing the state ****
        context.SetState(new InAirState());
    }

    public void Land(LocomotionContext context)
    {
    }
}

public class CrouchingState : LocomotionState
{
    void LocomotionState.Crouch(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    void LocomotionState.Fall(LocomotionContext context)
    {
        context.SetState(new InAirState());
    }

    void LocomotionState.Jump(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }

    void LocomotionState.Land(LocomotionContext context)
    {
    }
}

public class InAirState : LocomotionState
{
    void LocomotionState.Crouch(LocomotionContext context)
    {
    }

    void LocomotionState.Fall(LocomotionContext context)
    {
    }

    void LocomotionState.Jump(LocomotionContext context)
    {
    }

    void LocomotionState.Land(LocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
}