using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public abstract class AIDecision
    {
        protected AIController _controller;
        public bool InProgress { get; set; }

        public AIDecision(AIController controller)
        {
            Initialize(controller);
        }

        public virtual void Initialize(AIController controller)
        {
            _controller = controller;
        }

        public virtual void Convert(SerializableDictionary<string, string> properties)
        {

        }

        public abstract bool DoDecision();

        public virtual void OnEnterState()
        {
            InProgress = true;
        }

        public virtual void OnExitState()
        {
            InProgress = false;
        }
    }
}