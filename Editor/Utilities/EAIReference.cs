#if UNITY_EDITOR
using UnityEngine;

namespace YNL.SimpleAISystem
{
    [CreateAssetMenu(fileName = "AI Reference", menuName = "🔗 YのL/💫 Simple AI System/🚧 AI: Reference")]

    public class EAIReference : ScriptableObject
    {
        public AIBehaviour Behaviour;

        public void AssignBehaviour(AIBehaviour behaviour)
        {
            Behaviour = behaviour;
        }
    }
}
#endif