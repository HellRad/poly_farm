using System.Collections.Generic;
using UnityEngine;

namespace PerryPixelAdventure {
    public class FetchQuest : Quest {
        [SerializeField] List<Collectable> questItems = new();
        List<string> collectedItems = new();

        public override void Begin() {
            started = true;
        }

        public void UpdateQuestWithCollectedItem(Collectable collectable) {
            foreach (var item in questItems) {
                if (collectedItems.Count < questItems.Count && item == collectable) {
                    collectedItems.Add(collectable.Name);
                }
            }

            if (collectedItems.Count == questItems.Count) {
                fulfilled = true;
            }
        }

        public void UpdateQuestWithRemovedItem(Collectable collectable) {
            foreach (var item in questItems) {
                if (item == collectable) {
                    collectedItems.Remove(collectable.Name);
                }
            }

            if (collectedItems.Count < questItems.Count) {
                fulfilled = false;
            }
        }
    }
}
