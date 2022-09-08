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



    #region --Properties-- (With Backing Fields)
    public float MaxFuelLevel { get => _maxFuelLevel; }
    #endregion



    #region --Properties-- (Auto)
    public float FuelLevel { get; private set; } = 4f;
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public bool IsEmpty() => FuelLevel <= 0f;

    public bool UseFuel(float useAmount)
    {
        if (FuelLevel - useAmount >= 0f)
        {
            FuelLevel -= useAmount;
            OnFuelLevelChanged?.Invoke();
            return true;
        }
        return false;
    }

    public void AddFuel(float addAmount)
    {
        FuelLevel += addAmount;

        if (FuelLevel >= MaxFuelLevel)
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
        FuelLevel = 0;

        OnFuelLevelChanged?.Invoke();
    }
    #endregion
}
