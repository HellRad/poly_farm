using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class DoorMechanism : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OpenDoor();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CloseDoor();
            }
        }

        void OpenDoor()
        {
            _animator.SetTrigger("open");
        }

        void CloseDoor() 
        {
            _animator.SetTrigger("close");
        }
    }
}
