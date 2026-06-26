using UnityEngine;

namespace PerryPixelAdventure {
    /// <summary>
    /// Interfaces are used to define a contract for classes that implement them. In this case, the Highlightable interface defines a property: HighlightWorldPosition. The HighlightWorldPosition property is used to get the world position of the object's highlight hint position for highlighting it when the player is close enough to interact with it. By using an interface, we can ensure that any class that implements the Highlightable interface will have this property, which allows us to easily highlight different types of objects in our game without having to worry about their specific implementation details.
    /// </summary>
    public interface IHighlightable {
        Transform HighlightTransform { get; }
    }
}
