using UnityEngine;
using PolyFarm.UI;

namespace PolyFarm {
    public class PlayerSpeech : MonoBehaviour {
        //Since UI code is usually not part of the player character controller the reference to the speech bubble should normally not be done by a reference field like this. This is for demontration puroses. To connect to ui use something like a singleton pattern or dependency injection.
        [SerializeField] SpeechBubble speechBubble;

        public void SayText(string text) {
            speechBubble.DisplayText(text);
        }

        public void SayHi() {
            speechBubble.DisplayText("Hi there!");
        }

        public void SayHurt() {
            speechBubble.DisplayText("Ouchy!");
        }
    }
}
