#if YNL_UTILITIES
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    public static class AIUtilities
    {
        public static float AIRescale(this float number) => number.Multiply(1);

        public static AIAction GetAction(this AIController controller, string label)
        {
            return (AIAction)MType.CreateInstance($"YNL.SimpleAISystem.AIAction{label}", controller);
        }

        public static AIDecision GetDecision(this AIController controller, string label)
        {
            return (AIDecision)MType.CreateInstance($"YNL.SimpleAISystem.AIDecision{label}", controller);
        }
    }
}
#endif