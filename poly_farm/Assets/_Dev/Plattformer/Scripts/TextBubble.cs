using TMPro;
using UnityEngine;

namespace PennyPixelPlattformer {
    public class TextBubble : MonoBehaviour {
        [SerializeField] TMP_Text text;
        [SerializeField] float textDisplayTime = 2f;

        void Awake() {
            DeleteText();
        }


        public void DisplayText(string content) {
            text.text = content;
            Invoke(nameof(DeleteText), textDisplayTime);
        }

        void DeleteText() {
            text.text = string.Empty;
        }
    }
}
