using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

namespace PolyFarm
{
    public class FarmItemLister : MonoBehaviour
    {
        [SerializeField] private TMP_Text listTextObject;

        [ContextMenu("ListAllFarmItems")]
        public void ListAllFarmItems()
        {
            Dictionary<string, int> itemsList = new Dictionary<string, int>();
            GatherAllItems(itemsList);
            ListTheItems(itemsList);
        }

        private void GatherAllItems(Dictionary<string, int> itemsList)
        {
            //Tip: allways use a sort mode when using find objects of by type
            IFarmItem[] farmItems = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID).OfType<IFarmItem>().ToArray();

            foreach (var farmItem in farmItems)
            {
                string itemName = farmItem.GetName;

                if (itemsList.ContainsKey(itemName))
                {
                    itemsList[itemName] += 1;
                }
                else
                {
                    itemsList.Add(itemName, 1);
                }
            }
        }

        private void ListTheItems(Dictionary<string, int> itemsList)
        {
            string listText = "";

            foreach (var item in itemsList)
            {
                listText += $"{item.Key}: {item.Value}\n";
            }

            listTextObject.text = listText;
        }
    } 
}
