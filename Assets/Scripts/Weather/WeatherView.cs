using UnityEngine;
using UnityEngine.UI;

namespace Weather
{
    public class WeatherView : MonoBehaviour
    {
        [SerializeField] private Text valueText;

        public void UpdateValue(WeatherResponse weather) => valueText.text = $"Сегодня - {weather.properties.periods[0].temperature}F";
    }
}
