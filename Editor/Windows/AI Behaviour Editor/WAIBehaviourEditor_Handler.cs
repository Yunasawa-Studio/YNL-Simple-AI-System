#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System.Collections.Generic;
using System.Linq;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem.Editors
{
    public class WAIBehaviourEditor_Handler
    {
        #region ▶ Fields/Properties
        private WAIBehaviourEditor_Main _main;

        public AIBehaviour Behaviour;

        private string _currentStateName = "";
        public AIStateKey CurrentStateKey;

        private Dictionary<AIActionKey, SerializableDictionary<string, string>> _actionProperties = new();
        #endregion

        public WAIBehaviourEditor_Handler(WAIBehaviourEditor_Main main)
        {
            _main = main;
        }

        public void OnChangeBehaviour(AIBehaviour behaviour)
        {
            _main.Visual.ActionPanel.ClearBoxes();
            _main.Visual.TransitionPanel.ClearBoxes();

            Behaviour = behaviour;

            _main.Visual.StatePanel.AssignBehaviour(behaviour);

            if (!Behaviour.IsNull())
            {
                if (!Behaviour.StateKeys.IsEmpty()) OnChangeState(Behaviour.StateKeys[0].Name);
            }
            RefreshStateBoxes();

            _main.Reference.AssignBehaviour(behaviour);
        }
        public void OnChangeState(string state)
        {
            _currentStateName = state;
            CurrentStateKey = Behaviour.StateKeys.FirstOrDefault(i => i.Name == _currentStateName);
            RefreshBehaviourBoxes();
        }
        public void RefreshStateBoxes()
        {
            if (Behaviour.IsNull()) return;

            _main.Visual.StatePanel.Scroll.Clear();
            foreach (var state in Behaviour.StateKeys)
            {
                _main.Visual.StatePanel.ShowState(state);
            }
            _main.Visual.StatePanel.SelectState(0);
        }
        public void RefreshBehaviourBoxes()
        {
            if (CurrentStateKey.IsNull()) return;

            _main.Visual.ActionPanel.ClearBoxes();
            foreach (var action in CurrentStateKey.Actions)
            {
                EActionBox box = new EActionBox(action, _main);
                _main.Visual.AddActionBoxes(box);
            }

            _main.Visual.TransitionPanel.ClearBoxes();
            foreach (var transition in CurrentStateKey.Transitions)
            {
                ETransitionBox box = new ETransitionBox(transition, Behaviour.StateKeys, _main);
                _main.Visual.AddTransitionBoxes(box);
            }
        }
        public void UpdateTrueFalseState()
        {

        }
    }
}
#endif
#endif
#endif