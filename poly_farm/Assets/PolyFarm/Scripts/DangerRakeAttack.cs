using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class DangerRakeAttack : MonoBehaviour
    {
        public bool IsCooldown { get; private set; }

        [SerializeField] Animator _animator;
        [SerializeField] DeadlyElement _deadlyElement;
        [SerializeField] float _attackTime = 0.5f;
        [SerializeField] float _cooldownTime = 0.7f;

        void Awake()
        {
            _deadlyElement.gameObject.SetActive(false);
        }

        void OnTriggerEnter(Collider other)
        {
            Debug.Log("On trigger enter");

            if (other.CompareTag("Player"))
            {
                AttackAndCooldown();
            }
        }

        void AttackAndCooldown()
        {
            if (IsCooldown) { return; } //This is a "Guard Clause". It makes is easyer to read and understand the conditions under which the method is executed or not without having to read all the text inside the method.
            IsCooldown= true;
            Attack(); //Do the attack.
            Invoke("MakeRakeNotDeadlyWaitAndRearm", _attackTime); //Wait for an ammount of time, then execute the other function.
        }

        void Attack()
        {
            _animator.SetTrigger("attack");
            _deadlyElement.gameObject.SetActive(true);
        }

        void MakeRakeNotDeadlyWaitAndRearm()
        {
            _deadlyElement.gameObject.SetActive(false);
            Invoke("MakeDeadly", _cooldownTime);
        }

        void MakeDeadly() 
        {
            IsCooldown= false;
        }
    }
}
