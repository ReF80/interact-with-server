using System.Diagnostics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Weather;

public class TabSystem : MonoBehaviour
{
    [SerializeField] private Button weatherTabButton;
    [SerializeField] private Button dogBreedsTabButton;
    [SerializeField] private Image weatherImage;
    [SerializeField] private Image dogsBreedImage;
    [SerializeField] private GameObject weatherPanel;
    [SerializeField] private GameObject dogBreedsPanel;
    
    private readonly Color _activeColor = new(0.37f, 0.37f, 0.4f, 1f);
    private readonly Color _enactiveColor = new(0.31f, 0.31f, 0.35f,1f);

    public WeatherController weatherController;
    public DogController dogController;
    
    
    private void Start()
    {
        weatherTabButton.onClick.AddListener(() => SwitchTab("Weather"));
        dogBreedsTabButton.onClick.AddListener(() => SwitchTab("DogBreeds"));
        
        CloseAllTabs();
    }

    private void SwitchTab(string tabName)
    {
        CloseAllTabs();
        weatherController.CancelWeatherRequests();
        
        if (tabName == "Weather")
        {
            weatherPanel.SetActive(true);
            weatherImage.color = _activeColor;
            weatherController.StartController();
        }
        else if (tabName == "DogBreeds")
        {
            dogBreedsPanel.SetActive(true);
            dogsBreedImage.color = _activeColor;
            dogController.StartDogController();
        }
    }

    private void CloseAllTabs()
    {
        weatherImage.color = _enactiveColor;
        dogsBreedImage.color = _enactiveColor;
        weatherPanel.SetActive(false);
        dogBreedsPanel.SetActive(false);
    }
}

