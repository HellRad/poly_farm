using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PolyFarm.UI;

namespace PolyFarm
{
    public class Speech : MonoBehaviour
    {
        [SerializeField] private PositonalSpeechBubble _positionalSpeechBubble;

        [ContextMenu("Say Stuff")]
        private void SayStuff() {
            Say("HI THERE!");
        }

        public void Say(string text)
        {
            _positionalSpeechBubble.DisplayText(this.gameObject, text);
        }
    }
}
