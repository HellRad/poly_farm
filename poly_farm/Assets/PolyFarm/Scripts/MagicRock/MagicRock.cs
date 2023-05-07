using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class MagicRock : MonoBehaviour
    {
        [SerializeField] GameObject _rock;
        [SerializeField] float _rotationAmmountInAngles = 7f;

        // Triggered before awake
        void Awake()
        {
            //Debug.Log("This is triggered on Awake");
        }

        // Start is called before the first frame update
        void Start()
        {
            //Debug.Log("This is triggered on Start");
            Rotate();
        }

        // Update is called once per frame
        void Update()
        {
            //Debug.Log("This is triggered on Update");
        }

        // Every "fixed" frame
        void FixedUpdate()
        {
            //Debug.Log("This is triggered on FixedUpdate");
        }

        private void OnEnable()
        {
            //Debug.Log("This is triggered on OnEnable");
        }

        private void OnDisable()
        {
            //Debug.Log("This is triggered on OnDisable");
        }

        private void OnDestroy()
        {
            //Debug.Log("This is triggered on OnDestroy");
        }

        private void OnValidate()
        {
            //Debug.Log("This is triggered on OnValidate");
        }

        void Rotate() 
        {
            _rock.transform.transform.Rotate(new Vector3(0, 0, 1), _rotationAmmountInAngles);
        }
    }
}
