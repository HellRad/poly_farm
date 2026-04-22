using UnityEngine;

namespace PolyFarm
{
    public class PlayerInteraction : MonoBehaviour
    {
        [field: SerializeField] public PlayerSpeech PlayerSpeech { get; set; }
        [SerializeField] string _hurtText;

        public void GetHurt()
        {
            PlayerSpeech.SayText(_hurtText);
        }
    }
}
