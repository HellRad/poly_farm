using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PolyFarm
{
    public class ChickenSpeechButton : MonoBehaviour
    {
        [SerializeField] Button speechButton;
        [SerializeField] Speech speech;
        [SerializeField] string text;

        private void Awake()
        {
            speechButton.onClick.AddListener(SayText);
        }

        void SayText()
        {
            speech.Say(text);
        }
    }
}
