#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

namespace YNL.SimpleAISystem
{
    [CreateAssetMenu(fileName = "AI Icon", menuName = "🔗 YのL/💫 Simple AI System/🚧 AI: Icon (Editor)")]

    public class EAIIcon : ScriptableObject
    {
        public List<EIconPair> StateIcons = new();
        public List<EIconPair> ActionIcons = new();
        public List<EIconPair> DecisionIcons = new();
    }

    [System.Serializable]
    public class EIconPair
    {
        public string Label;
        public Texture2D Icon;
    }
}
#endif