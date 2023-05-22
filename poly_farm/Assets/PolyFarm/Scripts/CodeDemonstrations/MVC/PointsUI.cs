using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace CodeDemo
{
    public class PointsUI : MonoBehaviour
    {
        public TMP_Text textComp;
        public PlayerPoints playerPoints;

        private void OnEnable()
        {
            UpdatePoints(GameManager.Instance.GameData.points);

            playerPoints.onCounterUpdated += UpdatePoints;
        }

        private void OnDisable()
        {
            playerPoints.onCounterUpdated -= UpdatePoints;
        }

        private void UpdatePoints(int points)
        {
            textComp.text = points.ToString();
        }
    }
}
