using System.Collections.Generic;
using Model.Items;
using UnityEngine;

namespace Model.Blocks
{
    public class Belt : IBlock
    {
        public struct BeltLine
        {
            public Dictionary<Item, float> ItemsAndProgress;

            public BeltLine(Dictionary<Item, float> itemsAndProgress)
            {
                ItemsAndProgress = itemsAndProgress;
            }
        }

        public List<BeltLine> Lines;
        public Vector2Int Direction;
        public float Speed;

        public static uint MaxItemsOnLine = 3;
        public static uint LinesCount = 2;

        public Vector2Int Position { get; set; }
        public World TargetWorld { get; set; }


        public void OnUpdate()
        {
            foreach (var beltLine in Lines)
            foreach (var item in beltLine.ItemsAndProgress)
            {
                beltLine.ItemsAndProgress[item.Key] = item.Value + World.DeltaTime * Speed;

                if (!(item.Value > 1)) continue;

                var nextbelt = TargetWorld.GetBlock(Position + Direction) as Belt;

                if (nextbelt == null && TryTransferItemToOtherBelt(item.Key, this, nextbelt))
                    return;

                beltLine.ItemsAndProgress.Remove(item.Key);
            }
        }

        public static bool TryTransferItemToOtherBelt(Item item, Belt from, Belt to)
        {
            if (to.Direction == -from.Direction)
                return false;


            return true;
        }
    }
}