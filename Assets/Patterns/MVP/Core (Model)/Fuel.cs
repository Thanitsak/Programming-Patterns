using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Fuel : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [Tooltip("Max Fuel Tank in Liter.")]
    [SerializeField] private float _maxFuelLevel = 5f;
    #endregion



    #region --Events-- (UnityEvent)
    [SerializeField] private UnityEvent _onFuelLevelMaxed;
    #endregion



    #region --Events-- (Delegate as Action)
    public event Action OnFuelLevelChanged;
    #endregion



    #region --Fields-- (In Class)
    private float _fuelLevel = 0f;
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public bool IsEmpty() => _fuelLevel <= 0f;

    public bool UseFuel(float useAmount)
    {
        if (_fuelLevel - useAmount >= 0f)
        {
            _fuelLevel -= useAmount;
            OnFuelLevelChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void AddFuel(float addAmount)
    {
        _fuelLevel += addAmount;

        if (_fuelLevel >= _maxFuelLevel)
        {
            _onFuelLevelMaxed?.Invoke();

            ResetFuel();
        }

        OnFuelLevelChanged?.Invoke();
    }
    #endregion



    #region --Methods-- (Custom PRIVATE)
    private void ResetFuel()
    {
        _fuelLevel = 0;

        OnFuelLevelChanged?.Invoke();
    }
    #endregion
}
