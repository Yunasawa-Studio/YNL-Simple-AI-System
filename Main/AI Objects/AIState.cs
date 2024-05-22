#if YNL_UTILITIES
using System.Collections.Generic;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    [System.Serializable]
    public class AIState
    {
        protected AIController _controller;

        public string Name;
        public List<AIAction> Actions = new();
        public List<AITransition> Transitions = new();

        public void Initialize(AIController controller)
        {
            MDebug.Notify("ASDASDASD");

            _controller = controller;
            foreach (var action in Actions) action.Initialize(controller);
            foreach (var transition in Transitions) transition.Decision.Initialize(controller);
        }

        public void ExecuteActions()
        {
            if (Actions.IsNullOrEmpty()) return;
            foreach (var action in Actions)
            {
                if (!action.IsNull()) action.DoAction();
                else MDebug.Error($"An action of state {Name} is null.");
            }
        }

        public void ExecuteTransitions()
        {
            if (Transitions.IsNullOrEmpty()) return;
            foreach (var node in Transitions)
            {
                if (node.Decision.IsNull()) return;
                if (node.Decision.DoDecision())
                {
                    if (!node.True.IsNullOrEmpty())
                    {
                        _controller.TransitionToState(node.True);
                        break;
                    }
                }
                else
                {
                    if (!node.False.IsNullOrEmpty())
                    {
                        _controller.TransitionToState(node.False);
                        break;
                    }
                }
            }
        }

        public void Enter()
        {
            Initialize(_controller);
            foreach (AIAction action in Actions) if (!action.IsNull()) action.OnEnterState();
            foreach (AITransition transition in Transitions) if (!transition.Decision.IsNull()) transition.Decision.OnEnterState();
        }
        public void Exit()
        {
            foreach (AIAction action in Actions) if (!action.IsNull()) action.OnExitState();
            foreach (AITransition transition in Transitions) if (!transition.Decision.IsNull()) transition.Decision.OnExitState();
        }
    }
}
#endif