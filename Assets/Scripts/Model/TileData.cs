using UnityEngine;

namespace Model
{
    internal struct TileData
    {
        /// <summary>
        /// the tile used by "other" tile
        /// this made for blocks which biggest than 1x1
        /// </summary>
        public Vector2? ClaimedByTile;

        public IBlock TargetBlock;
    }
}