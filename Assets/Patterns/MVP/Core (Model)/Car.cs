using System.Collections;
using UnityEngine;

public class Car : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private float _fuelBurnRatePerSec = 0.1f;
    #endregion



    #region --Fields-- (In Class)
    private int _traveledKM = 0;
    #endregion



    #region --Methods-- (Built In)
    private void Start()
    {
        StartCoroutine( StartEngine(GetComponent<Fuel>()) );
    }
    #endregion



    #region --Methods-- (Custom PUBLIC)
    public void IncrementTraveledKM() => ++_traveledKM;
    #endregion



    #region --Methods-- (Custom PRIVATE)
    private IEnumerator StartEngine(Fuel fuel)
    {
        while (!fuel.IsEmpty())
        {
            fuel.UseFuel(_fuelBurnRatePerSec);

            yield return new WaitForSeconds(1f);
        }
    }
    #endregion
}
