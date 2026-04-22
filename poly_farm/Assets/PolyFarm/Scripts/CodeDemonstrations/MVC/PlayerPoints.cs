using System;
using UnityEngine;

namespace CodeDemo
{
    public class PlayerPoints : MonoBehaviour
    {
        public Action<int> onCounterUpdated;

        public void AddPoints(int ammount)
        {
            GameManager.Instance.GameData.points += ammount;
            onCounterUpdated?.Invoke(GameManager.Instance.GameData.points);
        }
    }
}
