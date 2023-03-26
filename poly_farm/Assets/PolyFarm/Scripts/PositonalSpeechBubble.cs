using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PolyFarm.UI
{
    public class PositonalSpeechBubble : MonoBehaviour
    {
        [SerializeField] GameObject _speechBubblePanel;
        [SerializeField] TMP_Text _textField;
        [SerializeField] float _waitTimeInSec;

        private void Awake()
        {
            DeactivateBubble();
        }

        public void DisplayText(GameObject relatedObject, string text)
        {
            _textField.text = text;
            _speechBubblePanel.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(WaitAndClose(_waitTimeInSec));
            StartCoroutine(UpdateBubblePosition(relatedObject));
        }

        IEnumerator UpdateBubblePosition(GameObject relatedObject)
        {
            while (_speechBubblePanel.activeSelf) 
            {
                SetBubblePosition(relatedObject);
                yield return null;
            }
        }

        private void SetBubblePosition(GameObject relatedObject)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(relatedObject.transform.position);
            _speechBubblePanel.transform.position = screenPos;
        }

        IEnumerator WaitAndClose(float waitTimeInSec)
        {
            yield return new WaitForSeconds(waitTimeInSec);
            DeactivateBubble();
        }

        void DeactivateBubble()
        {
            _speechBubblePanel.SetActive(false);
        }
    }
}
