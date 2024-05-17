using YNL.Extensions.Methods;
using YNL.Utilities.Addons;
using YNL.Utility.Extension.Method;

namespace YNL.SimpleAISystem
{
    public class AIActionPlayAnimation : AIAction
    {
        public AIActionPlayAnimation() : base(null) { }
        public AIActionPlayAnimation(AIController controller) : base(controller) { }

        public string Animation = "";
        public AIPlayAnimationMode PlayMode = AIPlayAnimationMode.Harsh;

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            Animation = properties["Animation"];
            PlayMode = MEnum.Parse<AIPlayAnimationMode>(properties["PlayMode"]);
        }

        public override void DoAction()
        {
            _controller.Animator?.WaitPlay(Animation, 0.1f);
        }

        public override void OnEnterState()
        {
            if (PlayMode == AIPlayAnimationMode.Wait) _controller.Animator?.WaitPlay(Animation, 0.1f);
            if (PlayMode == AIPlayAnimationMode.Immediate) _controller.Animator?.ImmediatePlay(Animation, 0.1f);
            if (PlayMode == AIPlayAnimationMode.Same) _controller.Animator?.SamePlay(Animation, 0.1f);
            if (PlayMode == AIPlayAnimationMode.Harsh) _controller.Animator?.HarshPlay(Animation);
        }
    }

    public enum AIPlayAnimationMode
    {
        Wait, Immediate, Same, Harsh
    }
}