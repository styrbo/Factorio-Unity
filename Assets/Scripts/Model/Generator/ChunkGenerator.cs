using System.Collections.Generic;
using Model.Blocks;
using UnityEngine;

namespace Model
{
    internal class ChunkGenerator
    {
        public static Chunk GenerateByPos(string seed, Vector2Int position)
        {
            var data = new TileData[16,16];
            
            for (var x = 0; x < 16; x++)
            for (var y = 0; y < 16; y++)
            {
                var tile = data[x, y];
                
                tile.TargetBlock = new Belt();
            }
            
            return new Chunk(data, Vector2Int.zero, null);
        }
    }
}