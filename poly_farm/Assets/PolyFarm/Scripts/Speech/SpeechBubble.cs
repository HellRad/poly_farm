using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PolyFarm.UI
{
    public class SpeechBubble : MonoBehaviour
    {
        [SerializeField] GameObject _speechBubblePanel;
        [SerializeField] TMP_Text _textField;
        [SerializeField] float _waitTimeInSec;

        private void Awake()
        {
            DeactivateBubble();
        }

        public void DisplayText(string text)
        {
            _textField.text = text;
            _speechBubblePanel.SetActive(true);
            StopAllCoroutines();
            StartCoroutine(WaitAndClose(_waitTimeInSec));
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
