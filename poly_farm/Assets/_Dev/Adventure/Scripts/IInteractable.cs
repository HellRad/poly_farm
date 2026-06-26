using UnityEngine;

namespace PerryPixelAdventure {
    /// <summary>
    /// Interfaces are used to define a contract for classes that implement them. In this case, the Interactable interface defines two methods: Highlight and Interact. The Highlight method is used to highlight the interactable object when the player is close enough to interact with it, and the Interact method is used to define what happens when the player interacts with the object. By using an interface, we can ensure that any class that implements the Interactable interface will have these two methods, which allows us to easily interact with different types of objects in our game without having to worry about their specific implementation details.
    /// </summary>
    public interface IInteractable {
        string Name { get; }
        Transform Transform { get; }
        void Interact();
    }
}
