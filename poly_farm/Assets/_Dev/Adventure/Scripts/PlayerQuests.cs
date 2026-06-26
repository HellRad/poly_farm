using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

namespace PerryPixelAdventure {
    public class PlayerQuests : MonoBehaviour {
        [SerializeField] List<Quest> quests = new();

        public void AddQuest(Quest quest) {
            quests.Add(quest);
            quest.Begin();
        }

        public void ManageQuestsWithCollectedItem(Collectable collectable) {
            foreach (Quest quest in quests) {
                if (quest is FetchQuest fetchquest) {
                    fetchquest.UpdateQuestWithCollectedItem(collectable);
                }
            }
        }

        //you might also want to add some logic that gets triggered when an item is discarded or when you find and manage items that are required for several quests at once.
    }
}
