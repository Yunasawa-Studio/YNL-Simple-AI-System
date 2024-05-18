#if YNL_UTILITIES
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIActionLookAtTarget : AIAction
    {
        public AIActionLookAtTarget() : base(null) { }
        public AIActionLookAtTarget(AIController controller) : base(controller) { }

        public AILookAtTargetType LookAtType = AILookAtTargetType.OnUpdate;

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            LookAtType = MEnum.Parse<AILookAtTargetType>(properties["LookAtType"]);
        }

        public override void DoAction()
        {
            if (LookAtType == AILookAtTargetType.OnUpdate) LookAtTarget();
        }

        public override void OnEnterState()
        {
            if (LookAtType == AILookAtTargetType.OnEnter) LookAtTarget();
        }

        public override void OnExitState()
        {
            if (LookAtType == AILookAtTargetType.OnExit) LookAtTarget();
        }

        private void LookAtTarget() => _controller.Root.transform.LookAtByY(_controller.Target);
    }

    public enum AILookAtTargetType
    {
        OnEnter, OnExit, OnUpdate
    }
}
#endif