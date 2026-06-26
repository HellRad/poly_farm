using UnityEngine;

namespace PerryPixelAdventure {
    /// <summary>
    /// This class contains Pipers quest and her general behaviour. Usually you might have a whole system to cerate quests and manage dialogue logic. But a very easy and also very robust way is to just use one class and do every game logic that is related to this character within this class. Since we made a cool interface for interactions, we could just use this interface to trigger Pipers logic each time the player is interacting with her.
    /// </summary>
    public class PipersGdLogic : MonoBehaviour, IInteractable {
        public string Name => npc.Designation;
        public Transform Transform => this.gameObject.transform;

        [SerializeField] GameObject mainObj;
        [SerializeField] Npc npc;
        [SerializeField] FetchQuest fetchCratesQuest;
        string defaultText = "Hi Perry!";
        bool talking;
        bool greetedPerry;
        bool askedAgain;

        public void Interact() {
            if (talking) {
                StopTalking();
                return;
            }

            Talk();
        }

        void Talk() {
            talking = true;
            GameManager.Instance.OpenTextBox();

            if (fetchCratesQuest.Started) {
                return;
            }

            if (!greetedPerry) {
                GreetPerry();
                return;
            }

            if (!fetchCratesQuest.Started) {
                StartFetchQuest();
                return;
            }

            if (fetchCratesQuest.Started && !askedAgain) {
                StopTalking();
                return;
            }

            if (fetchCratesQuest.Started && !askedAgain) {
                askedAgain = true;
                DisplayText("You are still on it aren't you?");
                return;
            }

            if (fetchCratesQuest.Started && askedAgain) {
                askedAgain = !askedAgain;
                StopTalking();
                return;
            }
        }

        void DisplayText(string text) {
            GameManager.Instance.TextBox.DisplayCharacterText(Name, text);
        }

        void StopTalking() {
            talking = false;
            GameManager.Instance.CloseTextBox();
        }

        void GreetPerry() {
            DisplayText(defaultText);
            greetedPerry = true;
        }

        void StartFetchQuest() {
            DisplayText("Could you fetch me these crates? Thank youuuu!");
            fetchCratesQuest.Begin();
        }
    }
}
