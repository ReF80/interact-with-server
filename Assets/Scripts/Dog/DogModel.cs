using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class DogModel : MonoBehaviour
{
    private const string API = "https://dogapi.dog/api/v2/breeds";
    private BreedResponse _breed;
    public List<BreedResponse> dogsBreeds;

    public async UniTask<BreedResponse> GetBreeds()
    {
        using var request = UnityWebRequest.Get(API);
        await request.SendWebRequest().ToUniTask();
        // if (request.result == UnityWebRequest.Result.Success)
        // {
        string json = request.downloadHandler.text;
        Debug.Log(json);
        var breedData = JsonUtility.FromJson<BreedResponse>(json);
        //}
        return breedData;
    }
}
[System.Serializable]
public class BreedResponse
{
    public List<BreedData> data;
}

[System.Serializable]
public class BreedData
{
    public string id;
    public BreedAttributes attributes;
}

[System.Serializable]
public class BreedAttributes
{
    public string name;
}