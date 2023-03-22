using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PolyFarm
{
    public class PlayerCommentTrigger : MonoBehaviour
    {
        [field: SerializeField] public string Comment { get; private set; } = "no_commment_text";

        void OnTriggerEnter(Collider other)
        {
            var interaction = other. GetComponent<PlayerInteraction>();
            if (interaction) 
            {
                interaction.PlayerSpeech.SayText(Comment);
            }
        }

        public void ChangeComment(string text)
        {
            Comment= text;
        }
    }
}
