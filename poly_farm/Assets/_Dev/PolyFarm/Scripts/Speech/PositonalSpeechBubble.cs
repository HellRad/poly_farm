using System.Collections;
using TMPro;
using UnityEngine;

namespace PolyFarm.UI {
    public class PositonalSpeechBubble : MonoBehaviour {
        [SerializeField] GameObject speechBubblePanel;
        [SerializeField] TMP_Text textField;
        [SerializeField] float waitTimeInSec;

        void Awake() {
            DeactivateBubble();
        }

        public void DisplayText(GameObject relatedObject, string text) {
            textField.text = text;
            speechBubblePanel.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(WaitAndClose(waitTimeInSec));
            StartCoroutine(UpdateBubblePosition(relatedObject));
        }

        IEnumerator UpdateBubblePosition(GameObject relatedObject) {
            while (speechBubblePanel.activeSelf) {
                SetBubblePosition(relatedObject);
                yield return null;
            }
        }

        void SetBubblePosition(GameObject relatedObject) {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(relatedObject.transform.position);
            speechBubblePanel.transform.position = screenPos;
        }

        IEnumerator WaitAndClose(float waitTimeInSec) {
            yield return new WaitForSeconds(waitTimeInSec);
            DeactivateBubble();
        }

        void DeactivateBubble() {
            speechBubblePanel.SetActive(false);
        }
    }
}
