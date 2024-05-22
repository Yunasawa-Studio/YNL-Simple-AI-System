#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System;
using System.Linq;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.Windows;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class EStatePanel : VisualElement
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/EStatePanel";

        public Image Background;
        public ScrollView Scroll;
        public Button AddButton;

        private string[] States;
        public string CurrentState;

        public AIBehaviour Behaviour;

        public Action<string> OnSelectState;

        public EStatePanel(string[] states, AIBehaviour behaviour) : base()
        {
            this.AddStyle(_styleSheet, EStyleSheet.Font).AddClass("Main");

            Scroll = new ScrollView().AddClass("Scroll");
            AddButton = new Button().SetText("Add State").AddClass("Add");
            AddButton.clicked += AddState;
            Background = new Image().AddClass("Background").AddElements(Scroll, AddButton);

            this.AddElements(Background);

            States = states;
            Behaviour = behaviour;
        }

        public void AssignBehaviour(AIBehaviour behaviour) => Behaviour = behaviour;

        public void ShowState(AIStateKey state)
        {
            Scroll.AddElements(new EStateBox(this, state));
        }

        public void AddState()
        {
            if (Behaviour.IsNull())
            {
                WMessagePopup.Show("Select an AI Behaviour asset first!");
                return;
            }

            AIStateKey newKey = new("...");
            Behaviour.StateKeys.Add(newKey);
            Scroll.AddElements(new EStateBox(this, newKey));

            WAIBehaviourEditor_Action.AddState?.Invoke(newKey);
        }

        public void SelectState(int index)
        {
            if (Scroll.Children().ToArray().Length <= 0) return;
            (Scroll.Children().ToArray()[index] as EStateBox).SelectInPanel();
        }

        public void SelectState(string stateName)
        {
            this.CurrentState = stateName;

            foreach (EStateBox box in Scroll.Children().ToArray())
            {
                if (box.Name == stateName) box.SelectState(true);
                else box.SelectState(false);
            }

            OnSelectState?.Invoke(stateName);
        }
    }
}
#endif
#endif
#endif