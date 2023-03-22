using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class DoorMechanism : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        //TODO: There is something missing here for it to work!

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
