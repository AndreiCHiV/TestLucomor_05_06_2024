using System;
using UnityEngine;

namespace Assets.Project_S
{
    public class AddItemTag : MonoBehaviour, IReadOnlyTag
    {
        [SerializeField] private EntryPoint _entryPoint;

        private const string NAMETAG = "addItem";

        public string NameTag => NAMETAG;

        public void Calling(string valueTag)
        {
            string[] keyTag = valueTag.Split("_");

            if (keyTag.Length != 2)
            {
                throw new ArgumentException("Неправельное оформление тега! Срочно исправить!");
            }

            string name = keyTag[0].Trim();
            int amount = int.Parse(keyTag[1].Trim());

            _entryPoint.InventoryService.AddItems(_entryPoint.ActiveCharacter, name, amount);
        }
    }
}