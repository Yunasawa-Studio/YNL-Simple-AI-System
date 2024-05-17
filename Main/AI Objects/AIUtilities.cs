using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    public static class AIUtilities
    {
        public static float AIRescale(this float number) => number.Multiply(3.6f);

        public static AIAction GetAction(this AIController controller, string label)
        {
            return (AIAction)MType.CreateInstance($"YNL.RPG.AI.AIAction{label}", controller);
        }

        public static AIDecision GetDecision(this AIController controller, string label)
        {
            return (AIDecision)MType.CreateInstance($"YNL.RPG.AI.AIDecision{label}", controller);
        }
    }
}