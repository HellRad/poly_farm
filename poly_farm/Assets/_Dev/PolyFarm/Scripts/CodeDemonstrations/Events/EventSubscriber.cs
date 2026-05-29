using UnityEngine;

namespace CodeDemo.Events
{
    public class EventSubscriber : MonoBehaviour
    {
        [SerializeField] private EventHolder eventHolder;

        private void OnEnable()
        {
            eventHolder.AnAction += SomeMethod;
            eventHolder.AUnityAction += SomeMethod;
            eventHolder.AUnityEvent.AddListener(SomeMethod);
        }

        private void OnDisable()
        {
            eventHolder.AnAction -= SomeMethod;
            eventHolder.AUnityAction -= SomeMethod;
            eventHolder.AUnityEvent.RemoveListener(SomeMethod);
        }

        private void SomeMethod()
        {
            Debug.Log("Some Method was executed");
        }
    }
}
