using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DogInfoModel : MonoBehaviour
{
    
    public async UniTask<BreedDetailsResponse> GetBreedInfo(string breedId)
    {
        using var request = UnityWebRequest.Get($"https://dogapi.dog/api/v2/breeds/{breedId}");
        await request.SendWebRequest().ToUniTask();
        string json = request.downloadHandler.text;
        var breedData = JsonUtility.FromJson<BreedDetailsResponse>(json);
        return breedData;
    }
}

[System.Serializable]
public class BreedDetailsResponse
{
    public BreedInfoAttributes attributes;
}

[System.Serializable]
public class BreedInfoAttributes
{
    public string name;
    public BreedLife life;
    public BreedFemaleWeight femaleWeight;
    public BreedMaleWeight maleWeight;
    public string description;
}

[System.Serializable]
public class BreedLife
{
    public int minimum;
    public int maximum;
}

[System.Serializable]
public class BreedMaleWeight
{
    public int minimum;
    public int maximum;
}

[System.Serializable]
public class BreedFemaleWeight
{
    public int minimum;
    public int maximum;
}