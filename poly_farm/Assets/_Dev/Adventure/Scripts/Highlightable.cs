using UnityEngine;

namespace PerryPixelAdventure {
    /// <summary>
    /// This makes Game Objects highlightable. Why not using the interface only on another class? Good Question! This enables us to switch the option to highlight things on and off in case some this are static and should not be highlighted anymore.
    /// </summary>
    public class Highlightable : MonoBehaviour, IHighlightable {
        public Transform HighlightTransform => highlightTransform;
        [SerializeField] Transform highlightTransform;
    }
}
