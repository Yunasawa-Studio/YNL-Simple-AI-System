using System.Collections.Generic;

namespace YNL.SimpleAISystem
{
    [System.Serializable]
    public class AIStateKey
    {
        public string Name;
        public List<AIActionKey> Actions = new();
        public List<AITransitionKey> Transitions = new();

        public AIStateKey(string name)
        {
            Name = name;
        }
    }
}
