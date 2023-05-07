using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class Player : MonoBehaviour
    {
        [SerializeField] PlayerInteraction _playerInteraction;
        [SerializeField] bool _isTired;
        [SerializeField] string _tiredText;
        [SerializeField] string _notTiredText;

        void Start()
        {
            if (_isTired)
            {
                _playerInteraction.PlayerSpeech.SayText(_tiredText);
            }
            else
            {
                _playerInteraction.PlayerSpeech.SayText(_notTiredText);
            }

            ChoresProgress.StartedDay = true;
            ChoresProgress.PlayerInHurry= _isTired;
        }
    }
}
