using System;
using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private float _fuelBurnRatePerSec = 0.1f;
    #endregion



    #region --Events-- (Delegate as Action)
    public event Action OnTravelChanged;
    #endregion



    #region --Properties-- (Auto)
    public int TraveledKM { get; private set; } = 0;
    #endregion



    #region --Methods-- (Built In)
    private void Start()
    {
        StartCoroutine( StartEngine(GetComponent<Fuel>()) );
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void IncrementTraveledKM()
    {
        ++TraveledKM;

        OnTravelChanged?.Invoke();
    }
    #endregion



    #region --Methods-- (Custom PRIVATE)
    private IEnumerator StartEngine(Fuel fuel)
    {
        while (true)
        {
            bool success = fuel.UseFuel(_fuelBurnRatePerSec);
            if (!success)
                Debug.LogWarning("Not Enough Fuel for the Car Engine!");

            yield return new WaitForSeconds(1f);
        }
    }
    #endregion
}
