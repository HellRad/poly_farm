using UnityEngine;

namespace CodeDemo.Events
{
    public class EventSubscriberParameter : MonoBehaviour
    {
        [SerializeField] private EventHolderParameter eventHolder;

        private void OnEnable()
        {
            eventHolder.AnAction += SomeMethod;
        }

        private void OnDisable()
        {
            eventHolder.AnAction -= SomeMethod;
        }

        private void SomeMethod(string name)
        {
            Debug.Log("His epic name was: " + name);
        }
    }
}
