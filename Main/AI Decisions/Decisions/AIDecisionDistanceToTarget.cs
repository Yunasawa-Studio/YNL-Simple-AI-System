using UnityEngine;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem
{
    public class AIDecisionDistanceToTarget : AIDecision
    {
        public AIDecisionDistanceToTarget() : base(null) { }
        public AIDecisionDistanceToTarget(AIController controller) : base(controller) { }

        [Tooltip("Type of comparisons")] public NotEqualComparison Comparison = NotEqualComparison.Greater;
        [Tooltip("Distance to compare with, unit is meter")] public float Distance = 0;

        private float _distance;

        public override void Convert(SerializableDictionary<string, string> properties)
        {
            Comparison = MEnum.Parse<NotEqualComparison>(properties["Comparison"]);
            Distance = float.Parse(properties["Distance"]);
        }

        public override bool DoDecision()
        {
            return HandleDistance();
        }

        protected virtual bool HandleDistance()
        {
            if (_controller.Target.IsNull()) return false;

            _distance = Vector3.Distance(_controller.transform.parent.position, _controller.Target.position);
            if (Comparison == NotEqualComparison.Lower) return _distance < Distance.AIRescale();
            if (Comparison == NotEqualComparison.LowerOrEqual) return _distance <= Distance.AIRescale();
            if (Comparison == NotEqualComparison.Greater) return _distance > Distance.AIRescale();
            if (Comparison == NotEqualComparison.GreaterOrEqual) return _distance >= Distance.AIRescale();
            return false;
        }
    }

    public enum NotEqualComparison
    {
        Greater, GreaterOrEqual, Lower, LowerOrEqual
    }
}