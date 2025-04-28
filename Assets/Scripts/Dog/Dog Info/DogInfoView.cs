using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DogInfoView : MonoBehaviour
{
    [FormerlySerializedAs("text")] [SerializeField] private Text infoDog;
    [SerializeField] private Text nameDog;
    [SerializeField] private GameObject panelInfo;
    [SerializeField] private GameObject loading;

    public void CreateText(BreedDetailsResponse breedInfo)
    {
        loading.SetActive(false);
        var info = breedInfo.attributes;
        nameDog.text = info.name;
        infoDog.text = $"Описание: {info.description}. Время жизни - от {info.life.minimum} до {info.life.maximum}. Вес женской породы - от {info.femaleWeight.minimum} до {info.femaleWeight.maximum}. " +
                       $"Вес мужской породы - от {info.maleWeight.minimum} до {info.maleWeight.maximum}.";
    }

    public void WaitGetRequest()
    {
        panelInfo.SetActive(true);
        loading.SetActive(true);
    }
    
    public void CloseInfoPanelBtn()
    {
        panelInfo.SetActive(false);
    }
}
