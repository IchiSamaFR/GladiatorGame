using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gladiator.Item
{
    public abstract class ItemData : ScriptableObject
    {
        public enum itemType
        {
            none,
            weapon,
            armor,
            shield,
        }

        public abstract itemType Type { get; }

        [Header("Infos")]
        public string Name;
        public Sprite Sprite;
        public Sprite SpriteUI;

        public virtual ItemData Clone()
        {
            var item = CreateInstance(typeof(ItemData)) as ItemData;
            item.Name = Name;
            item.Sprite = Sprite;
            item.SpriteUI = SpriteUI;
            return item;
        }
    }
}