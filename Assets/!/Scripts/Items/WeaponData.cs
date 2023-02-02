using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Item
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Gladiator/Item/Weapon")]
    public class WeaponData : ItemData
    {
        public override itemType Type => ItemData.itemType.weapon;

        [Header("Weapon")]
        public int Attack = 1;
        public int Range = 1;
        public bool TwoHands;

        public override ItemData Clone()
        {
            var item = CreateInstance(typeof(WeaponData)) as WeaponData;
            item.Name = Name;
            item.Sprite = Sprite;
            item.SpriteUI = SpriteUI;
            item.Attack = Attack;
            item.Range = Range;
            item.TwoHands = TwoHands;
            return item;
        }
    }
}