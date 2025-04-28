using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;

public class DogController : MonoBehaviour
{
    [SerializeField] private DogModel dogModel;
    [SerializeField] private DogView dogView;
    public BreedResponse dogsData;
    public async UniTaskVoid StartDogController()
    {
        dogsData = await dogModel.GetBreeds();
        dogView.DisplayData(dogsData);
    }
}
