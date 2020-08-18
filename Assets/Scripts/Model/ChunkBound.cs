using UnityEngine;

namespace Model
{
    internal partial class Chunk
    {
        public class ChunkBound
        { 
            public Vector2Int StartPos {get; private set;}
            public Vector2Int EndPos {get; private set;}
            
            public ChunkBound(Vector2Int startWorldPos, Vector2Int endWorldPos)
            {
                StartPos = startWorldPos;
                EndPos = endWorldPos;
            }
        }
    }
}