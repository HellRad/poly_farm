using System;
using UnityEngine;

namespace PolyFarm
{
    public class RaycastInteractor : MonoBehaviour
    {
        public RayInteraction CurrentInteractable { get; private set; }
        public Action<RayInteraction> OnNewInteractableFocused;
        public Action OnInteractableUnfocused;

        [SerializeField] Camera castCamera; //Since UI code is usually not part of the player character controller the reference to the speech bubble should normally not be done by a reference field like this. This is for demontration puroses. To connect to ui use something like a singleton pattern or dependency injection.
        [SerializeField] float originAdjustment;
        [SerializeField] float maxDistance;
        [SerializeField] LayerMask layerMask;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (CurrentInteractable)
                {
                    CurrentInteractable.InteractWith();
                }
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!castCamera){return;}

            if (Physics.Raycast(castCamera.transform.position + castCamera.transform.forward * originAdjustment, castCamera.transform.forward, out RaycastHit hitInfo, maxDistance, layerMask))
            {
                var rayInteraction = hitInfo.transform.GetComponent<RayInteraction>();
                if (rayInteraction)
                {
                    if (CurrentInteractable != rayInteraction)
                    {
                        CurrentInteractable = rayInteraction;
                        OnNewInteractableFocused?.Invoke(rayInteraction);
                    }
                }
            }
            else
            {
                CurrentInteractable = null;
                OnInteractableUnfocused?.Invoke();
            }
        }

//more about: https://docs.unity3d.com/Manual/PlatformDependentCompilation.html
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            if (!castCamera){return;}

            Gizmos.color = Color.yellow;
            if (CurrentInteractable)  {Gizmos.color = Color.green;}
            var origin = castCamera.transform.position + castCamera.transform.forward * originAdjustment;
            Gizmos.DrawLine(origin, origin + castCamera.transform.forward * maxDistance);
        }
#endif
    }
}