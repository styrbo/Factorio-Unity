using UnityEngine;

namespace Model
{
    /// <summary>
    /// implimitation there for made in game block
    /// </summary>
    public interface IBlock
    {
        Vector2Int Position { get; set; }
        World TargetWorld { get; set; }

        void OnUpdate();
    }
}