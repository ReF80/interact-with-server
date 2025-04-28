using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DogView : MonoBehaviour
{
    [SerializeField] private List<Text> dogsNamesList;

    public void DisplayData(BreedResponse breedData)
    {
        for (int i = 0; i < dogsNamesList.Count; i++)
        {
            var breed = breedData.data[i];
            dogsNamesList[i].text = $"{i+1} - {breed.attributes.name}";
        }
    }
}
