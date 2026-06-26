using UnityEngine;

namespace PerryPixelAdventure {
    public class GameManager : MonoBehaviour {
        public PlayerMovement PlayerMovement => playerMovement;
        public PlayerInput PlayerInput => playerInput;
        public TextBox TextBox => textBox;
        public InteractionButtonHint InteractionButtonHint => interactionButtonHint;

        PlayerMovement playerMovement;
        PlayerInput playerInput;
        TextBox textBox;
        InteractionButtonHint interactionButtonHint;
        public static GameManager Instance;


        void Awake() {
            MakeSingleton();
        }

        //This is a simple singleton pattern. Usually you can do every reference you want just by using the UnityEditor and reference fields (like with "SerializeField"). But this gets tricky when using several scenes at once because you can't have editor references reaching different scenes. This pattern enables you to make the game manager a singular entity that can be called from anywhere. This works by using the "static" keyword. A static property is not instanciated an exists only once. When you make a Singleton like this, it might be wise to set it to the start of the Script execution order in Edit > Project Settings > Script Execution Order
        void MakeSingleton() {
            if (Instance != null) {
                Destroy(this); //If there is already a game manager, destroy this one
                return;
            }

            Instance = this; //make this a static instance
            DontDestroyOnLoad(gameObject); //mark this game obect as not to be destroyed when switching scenes. Normally you would add this GameManager to a dedicated "Main" scene, load this main scene at the start of the game and never unload it. But this also works quite well.
        }


        //In case we are using several scenes, to make sure we are using the right object, we make necessary objects register here. This might look different depending on your personal setup. For exapmle if you are using DontDestroyOnLoad or a specialized scene on your Canvas.

        public void RegisterPlayer(Player player) {
            if (this.playerMovement == null) {
                this.playerMovement = player.GetComponentInChildren<PlayerMovement>();
            }

            if (this.playerInput == null) {
                this.playerInput = player.GetComponentInChildren<PlayerInput>();
            }
        }

        public void RegisterTextBox(TextBox textBox) {
            if (this.textBox == null) {
                this.textBox = textBox;
            }
        }

        public void RegisterInteractionButtonHint(InteractionButtonHint interactionButtonHint) {
            if (this.interactionButtonHint == null) {
                this.interactionButtonHint = interactionButtonHint;
            }
        }

        public void OpenTextBox() { 
            playerMovement.enabled = false;
            textBox.OpenTextBox();
        }

        public void CloseTextBox() {
            playerMovement.enabled = true;
            textBox.CloseTextBox();
        }
    }
}
