using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Dog.Dog_Info
{
    public class Buttons : MonoBehaviour
    {
        public DogController dogController;
        public DogInfoController dogInfoController;
        [FormerlySerializedAs("btns")] [SerializeField] private Button[] buttons;

        private void Start()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[i].onClick.AddListener(() => OnButtonClick(index));
            }
        }

        private void OnButtonClick(int index)
        {
            string id = dogController.dogsData.data[index].id;
            dogInfoController.StartDogInfoController(id);
        }
    }
}