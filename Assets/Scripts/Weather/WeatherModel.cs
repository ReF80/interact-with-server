using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

namespace Weather
{
    public class WeatherModel : MonoBehaviour
    {
        //GET value from API
        private const string API = "https://api.weather.gov/gridpoints/TOP/32,81/forecast";
        public WeatherResponse temperature;
        

        public async UniTask<WeatherResponse> GetTemperature()
        {
            using (var request = UnityWebRequest.Get(API))
            {
                await request.SendWebRequest().ToUniTask();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    var weatherData = JsonUtility.FromJson<WeatherResponse>(json);
                    return weatherData;
                }
                return null;
            }
        }
    }

    [System.Serializable]
    public class WeatherResponse
    {
        public WeatherProperties properties;
    }

    [System.Serializable]
    public class WeatherProperties
    {
        public List<WeatherPeriod> periods;
    }

    [System.Serializable]
    public class WeatherPeriod
    {
        public int temperature;
    }
}