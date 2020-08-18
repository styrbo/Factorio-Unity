using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class World
    {
        public static float DeltaTime;
        
        internal List<Chunk> UpdatingChunks;

        public void Tick()
        {
#if DEBUG
      UnityEngine.Profiling.Profiler.BeginThreadProfiling("Tick", "main");      
#endif
            foreach (var chunk in UpdatingChunks)
            {
                chunk.Update();
            }
            
#if DEBUG
            UnityEngine.Profiling.Profiler.EndThreadProfiling();      
#endif
        }
        
        internal IBlock GetBlock(Vector2Int position)
        {
            return null;
        }
    }
}