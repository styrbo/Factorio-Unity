#if UNITY_EDITOR
using JetBrains.Annotations;
#endif
    
using UnityEngine;

namespace Model
{
    internal partial class Chunk
    {
        public TileData[,] Data { get; }
        public ChunkBound Bounds { get; }

#if UNITY_EDITOR
        
        [UsedImplicitly]
        private Chunk()
        {
            
        }
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">x.length this width y.length this height</param>
        /// <param name="startWorldPos">left and down tile position</param>
        public Chunk(TileData[,] data, Vector2Int startWorldPos, World world)
        {
            Data = data;

            Bounds = new ChunkBound(startWorldPos, startWorldPos + new Vector2Int(
                                                       data.GetLength(0) - 1,
                                                       data.GetLength(1) - 1));

            for (var x = 0; x < data.GetLength(0); x++)
            for (var y = 0; y < data.GetLength(1); y++)
            {
                var tileData = data[x, y];
                tileData.TargetBlock.Position = new Vector2Int(x,y) + startWorldPos;
            }
        }

        public void Update()
        {
#if DEBUG
            UnityEngine.Profiling.Profiler.BeginSample("Update Chunk");
#endif
            TileData data;
            
            for (var x = 0; x < Data.GetLength(0); x++)
            {
                for (var y = 0; y < Data.GetLength(1); y++)
                {
                    data = Data[x, y];

                    if (data.ClaimedByTile.HasValue)
                    {
                        
                    }
                    else
                    {
                        data.TargetBlock.OnUpdate();
                    }
                }
            }
            
#if DEBUG
            UnityEngine.Profiling.Profiler.EndSample();
#endif
        }
    }
}