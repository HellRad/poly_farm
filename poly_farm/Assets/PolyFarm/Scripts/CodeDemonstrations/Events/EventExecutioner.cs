using UnityEngine;

namespace CodeDemo.Events
{
    public class EventExecutioner : MonoBehaviour
    {
        [SerializeField] private EventHolder eventHolder;

        private void Start()
        {
            eventHolder.AnAction?.Invoke();     
        }
    }
}