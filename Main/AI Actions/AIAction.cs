using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public abstract class AIAction
    {
        protected AIController _controller;
        public bool InProgress { get; set; }

        public AIAction(AIController controller)
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

        public virtual void DoAction() { }

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