using UnityEngine;

namespace PerryPixelAdventure {
    public class InteractionButtonHint : MonoBehaviour {
        [SerializeField] RectTransform hint;
        Transform focusedTransform;

        void Awake() {
            GameManager.Instance.RegisterInteractionButtonHint(this);
            hint.gameObject.SetActive(false);
        }

        void Start() {
            GameManager.Instance.RegisterInteractionButtonHint(this);
        }

        void Update() {
            if (focusedTransform != null) {
                transform.position = Camera.main.WorldToScreenPoint(focusedTransform.position);
            }
        }

        public void ShowHint(Transform focusedTransform) {
            this.focusedTransform = focusedTransform;
            hint.gameObject.SetActive(true);
        }

        public void HideHint() {
            hint.gameObject.SetActive(false);
            focusedTransform = null;
        }
    }
}
