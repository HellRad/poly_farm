using UnityEngine;
using TMPro;

namespace PerryPixelAdventure {
    public class TextBox : MonoBehaviour {
        [SerializeField] RectTransform textBox;
        [SerializeField] TMP_Text textField;

        void Awake() {
            GameManager.Instance.RegisterTextBox(this);
            CloseTextBox();
        }

        public void OpenTextBox() {
            textBox.gameObject.SetActive(true);
        }

        public void DisplayText(string text) {
            textField.text = text;
            textBox.gameObject.SetActive(true);
        }

        public void DisplayCharacterText(string characterDesignation, string text) {
            DisplayText($"{characterDesignation}: {text}");
        }

        public void CloseTextBox() {
            textBox.gameObject.SetActive(false);
        }
    }
}
