using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyFarm.UI;

namespace PolyFarm
{
    public class PlayerSpeech : MonoBehaviour
    {
        [SerializeField] SpeechBubble _speechBubble;

        public void SayText(string text)
        {
            _speechBubble.DisplayText(text);
        }

        public void SayHi()
        {
            _speechBubble.DisplayText("Hi there!");
        }

        public void SayHurt()
        {
            _speechBubble.DisplayText("Ouchy!");
        }
    }
}
