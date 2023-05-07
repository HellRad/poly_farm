using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace PolyFarm
{
    public class ChoreSong : MonoBehaviour
    {
        [SerializeField] string _gettingRdyLine = "Hmhmhm...";
        [SerializeField] string _firstLine = "This iiiis a niiice daaay...";
        [SerializeField] string _altFirstLine = "Hurry hurry hurry...";
        //[SerializeField] string _cropsLine = "";
        //[SerializeField] string _chicksLine = "";
        //[SerializeField] string _easterEggLine = "";

        //TODO: add more lines to the chore song!

        void OnTriggerEnter(Collider other)
        {
            var interaction = other.GetComponent<PlayerInteraction>();
            if (interaction)
            {
                SingSong(interaction.PlayerSpeech);
            }
        }

        void SingSong(PlayerSpeech playerSpeech)
        {
            var text = "";

            text += _gettingRdyLine;

            if (ChoresProgress.PlayerInHurry)
            {
                text += " " + _altFirstLine;
            }
            else
            {
                text += " " + _firstLine;
            }

            playerSpeech.SayText(text);
        }
    }
}
