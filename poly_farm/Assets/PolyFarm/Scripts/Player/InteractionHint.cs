using System.Collections;
using UnityEngine;
using TMPro;

namespace PolyFarm
{
    public class InteractionHint : MonoBehaviour
    {
        [SerializeField] RaycastInteractor playerRaycastInteractor;
        [SerializeField] TMP_Text interactionHintObject;

        void Awake()
        {
            HideText();
            playerRaycastInteractor.OnNewInteractableFocused += UpdateInteractionHint;
            playerRaycastInteractor.OnInteractableUnfocused += HideText;
        }

        private void OnDestroy()
        {
            playerRaycastInteractor.OnNewInteractableFocused -= UpdateInteractionHint;
            playerRaycastInteractor.OnInteractableUnfocused -= HideText;
        }

        void UpdateInteractionHint(RayInteraction rayInteraction)
        {
            interactionHintObject.gameObject.SetActive(true);
            interactionHintObject.text = rayInteraction.interactionSettings.InteractionText;
        }

        void HideText()
        {
            interactionHintObject.gameObject.SetActive(false);
            interactionHintObject.text = "no text";
        }
    }
}