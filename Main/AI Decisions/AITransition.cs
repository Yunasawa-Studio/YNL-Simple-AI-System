using UnityEngine;

namespace YNL.SimpleAISystem
{
    [System.Serializable]
    public class AITransition
    {
        [SerializeReference] public AIDecision Decision;
        public string True;
        public string False;

        public AITransition(AIDecision decision, string @true, string @false)
        {
            Decision = decision;
            True = @true;
            False = @false;
        }
    }
}