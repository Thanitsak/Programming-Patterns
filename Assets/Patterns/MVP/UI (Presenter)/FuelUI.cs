using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FuelUI : MonoBehaviour
{
    #region --Fields-- (Inspector)
    [SerializeField] private TMP_Text _fuelLevelText;
    [SerializeField] private Slider _fuelBarSlider;
    [SerializeField] private Button _fuelButton;
    #endregion



    #region --Fields-- (In Class)
    private Fuel _fuel;
    #endregion



    #region --Methods-- (Built In)
    private void Awake()
    {
        _fuel = GameObject.FindWithTag("Player").GetComponentInChildren<Fuel>();

        _fuelButton.onClick.AddListener(AddFuel);
    }

    private void OnEnable()
    {
        _fuel.OnFuelLevelChanged += RefreshUI;
    }

    private void Start()
    {
        RefreshUI();
    }

    private void OnDisable()
    {
        _fuel.OnFuelLevelChanged -= RefreshUI;
    }
    #endregion



    #region --Methods-- (Subscriber)
    private void RefreshUI()
    {
        _fuelBarSlider.value = _fuel.FuelLevel / _fuel.MaxFuelLevel;

        _fuelLevelText.text = $"{_fuel.FuelLevel:N2} L";
    }

    private void AddFuel()
    {
        _fuel.AddFuel(1f);
    }
    #endregion
}