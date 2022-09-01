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
    #region --Fields-- (In Class)
    LocomotionState _currentState = new GroundedState();
    #endregion



    #region --Methods-- (Custom PUBLIC) ~Actions~
    public void Crouch() => _currentState.Crouch(this);

    public void Fall() => _currentState.Fall(this);

    public void Jump() => _currentState.Jump(this);

    public void Land() => _currentState.Land(this);
    #endregion



    #region --Methods-- (Interface)
    void LocomotionContext.SetState(LocomotionState newState)
    {
        _currentState = newState;
    }
    #endregion
}

public class GroundedState : LocomotionState
{
    #region --Methods-- (Interface)
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
    #endregion
}

public class CrouchingState : LocomotionState
{
    #region --Methods-- (Interface)
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
    #endregion
}

public class InAirState : LocomotionState
{
    #region --Methods-- (Interface)
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
    #endregion
}