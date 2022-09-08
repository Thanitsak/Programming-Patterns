using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarUI : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private TMP_Text _traveledKMText;
    #endregion



    #region --Fields-- (In Class)
    private Car _car;
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        _car = GameObject.FindWithTag("Player").GetComponentInChildren<Car>();
    }

    private void OnEnable()
    {
        _car.OnTravelChanged += RefreshUI;
    }

    private void Start()
    {
        RefreshUI();
    }

    private void OnDisable()
    {
        _car.OnTravelChanged -= RefreshUI;
    }
    #endregion



    #region --Methods-- (Subscriber)
    private void RefreshUI()
    {
        _traveledKMText.text = $"Car Traveled : {_car.TraveledKM} KM";
    }
    #endregion
}