using Cysharp.Threading.Tasks;
using UnityEngine;

public class DogInfoController : MonoBehaviour
{
    public DogInfoModel dogInfoModel;
    public DogInfoView dogInfoView;
    
    public async UniTaskVoid StartDogInfoController(string id)
    {
        dogInfoView.WaitGetRequest();
        var dogInfo = await dogInfoModel.GetBreedInfo(id);
        dogInfoView.CreateText(dogInfo);
    }
}
