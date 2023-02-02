using Gladiator.Item;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Gladiator.Item.ItemData;

namespace Gladiator.Item
{
    [CreateAssetMenu(fileName = "Accessory", menuName = "Gladiator/Item/Accessory")]
    public class AccessoryData : ItemData
    {
        public override itemType Type => ItemData.itemType.shield;

        [Header("Data")]
        public int Armor;

        public override ItemData Clone()
        {
            var item = CreateInstance(typeof(AccessoryData)) as AccessoryData;
            item.Name = Name;
            item.Sprite = Sprite;
            item.SpriteUI = SpriteUI;
            item.Armor = Armor;
            return item;
        }
    }
}