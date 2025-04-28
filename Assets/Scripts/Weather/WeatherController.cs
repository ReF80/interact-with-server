using System;
using System.Collections;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Weather
{
    public class WeatherController : MonoBehaviour
    {
        [SerializeField] private WeatherModel weatherModel;
        [SerializeField] private WeatherView weatherView;
        private bool point;
    
        public void StartController()
        {
            point = true;
            StartAutomaticUpdate().Forget();
        }

        private async UniTaskVoid StartAutomaticUpdate()
        {
            while (point)
            {
                var weatherData = await weatherModel.GetTemperature();
                weatherView.UpdateValue(weatherData);
                await UniTask.Delay(TimeSpan.FromSeconds(5));
            }
        }
        
        public void CancelWeatherRequests()
        {
            point = false;
        }
    }
}
