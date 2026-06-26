using System.Collections.Generic;
using UnityEngine;

namespace PerryPixelAdventure {

    public class PlayerInteraction : MonoBehaviour {
        public IInteractable FocusedInteractable => focusedInteractable;
        public List<IInteractable> interactions = new();
        IInteractable focusedInteractable;

        void OnTriggerEnter2D(Collider2D collision) {
            if (collision.gameObject.TryGetComponent(out IInteractable interactable)) {
                interactions.Add(interactable);
            }
        }

        void OnTriggerExit2D(Collider2D collision) {
            if (collision.gameObject.TryGetComponent(out IInteractable interactable)) {
                interactions.Remove(interactable);
            }
        }

        void FixedUpdate() {
            TrySetFocusedInteractable();
        }

        public void InteractWithFocusedInteractable() {
            if (focusedInteractable != null) {
                focusedInteractable.Interact();
            }
        }

        void TrySetFocusedInteractable() {
            IInteractable closest = GetClosestInteractable();
            if (closest != focusedInteractable) {
                TryHighlightInteractible(focusedInteractable, false);
                TryHighlightInteractible(closest, true);
            }
            focusedInteractable = closest;
        }

        IInteractable GetClosestInteractable() {
            // This method will set the focusedInteractable to the closest interactable in the interactions list. This is done by calculating the distance from the player to each interactable and setting the focusedInteractable to the one with the smallest distance.
            IInteractable closestInteractable = null;
            foreach (IInteractable interactable in interactions) {
                if (closestInteractable == null) {
                    closestInteractable = interactable;
                    continue;
                }

                float distanceToCurrentFocused = Vector2.Distance(transform.position, closestInteractable.Transform.position);
                float distanceToNewInteractable = Vector2.Distance(transform.position, interactable.Transform.position);
                if (distanceToNewInteractable < distanceToCurrentFocused) {
                    closestInteractable = interactable;
                }
            }

            return closestInteractable;
        }

        //Normally, you want to have the highlight logic as a seperate system, not tightly coupled to the player. But for the sake of simplicity it's placed here, which is perfectly fine. Usually if you want to have the simplest and most straight forward place to store your game logic you are using the player or a game manager. Later, with more experience and bigger productions, you want to seperate and modulize your systems as much as possible.
        void TryHighlightInteractible(IInteractable interactable, bool doHighlight) {
            if (interactable == null) { return; } // This is called a guard clause. Generally we want to fail fast and continue with the rest of the code execution. In this case, if the interactable is null, than we want to do nothing here and contiune.

            if (!doHighlight) {
                GameManager.Instance.InteractionButtonHint.HideHint();
                return;
            }

            IHighlightable highlightable = TryGetAHighlightable(interactable);
            if (highlightable == null) { return; }

            if (doHighlight) {
                GameManager.Instance.InteractionButtonHint.ShowHint(highlightable.HighlightTransform);
                return;
            }
        }

        IHighlightable TryGetAHighlightable(IInteractable interactable) {
            //In this section we are using a declaration pattern to check if the focusedInteractable implementa the IHighlightable interface. This is generally called pattern matching and is a very useful tool expecially combined with using Interfaces. (You can also paraphrase it like this: Hey IInteractable are you by any way also an IHighlitable? When yes, then you can also be used by the TryHighlightInteractible mehod. Pls do so, thanks!) 
            if (interactable is IHighlightable highlightableInteractable) {
                return highlightableInteractable;
            }

            //We are searching for a highlightable game object on the interactable because we are doing the highlighting eihter by Interface only or by a MonoBehaviour which uses the interface. We are using trygetcomponent after here because it is less performant and we want to do the most performant method first.,
            if (interactable.Transform.gameObject.TryGetComponent(out IHighlightable highlightableComponent)) {
                return highlightableComponent;
            }

            return null;
        }
    }
}
