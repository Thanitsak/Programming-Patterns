using UnityEngine;

public class LocomotionFSM : MonoBehaviour
{
    private enum State
    {
        Grounded,
        InAir,
        Crouching
    }



    #region --Fields-- (In Class)
    private State _currentState = State.Grounded;
    #endregion



    #region --Methods-- (Custom PUBLIC) ~FSM Actions~
    public void Jump()
    {
        switch (_currentState)
        {
            case State.Grounded:
                _currentState = State.InAir;
                // **** Usually we have to enact some code here, not just changing the state ****
                break;

            case State.Crouching:
                _currentState = State.Grounded;
                // **** Usually we have to enact some code here, not just changing the state ****
                break;
        }
    }

    public void Fall()
    {
        switch (_currentState)
        {
            case State.Grounded:
                _currentState = State.InAir;
                break;
            case State.Crouching:
                _currentState = State.InAir;
                break;
        }
    }

    public void Land()
    {
        switch (_currentState)
        {
            case State.InAir:
                _currentState = State.Grounded;
                break;
        }
    }

    public void Crouch()
    {
        switch (_currentState)
        {
            case State.Grounded:
                _currentState = State.Crouching;
                break;
            case State.Crouching:
                _currentState = State.Grounded;
                break;
        }
    }
    #endregion
}