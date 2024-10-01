#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using YNL.Extensions.Methods;
using YNL.Editors.Visuals;
using YNL.Editors.Extensions;

namespace YNL.SimpleAISystem.Editors
{
    public class WAIBehaviourEditor_Popup : PopupWindow<WAIBehaviourEditor_Popup>
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/WAIBehaviourEditor_Popup";

        public Image TitleBackground;
        public Image Background;

        public Button CloseButton;
        public ToolbarSearchField SearchField;

        public ScrollView Scroll;

        private bool _isAction = true;
        private EActionBox _actionBox;
        private ETransitionBox _transitionBox;

        private List<string> _labelList = new();

        public static void Open(params object[] parameters)
        {
            Show(parameters).CloseOnLostFocus().SetSize(300, 200).SetAnchor(true, PopupPivot.TopLeft);
        }

        protected override void Initialize(params object[] parameters)
        {
            _isAction = (bool)parameters[0];
            if (_isAction) _actionBox = (EActionBox)parameters[1];
            else _transitionBox = (ETransitionBox)parameters[1];

            CreateMainGUI();
        }

        public void CreateMainGUI()
        {
            this.rootVisualElement.AddStyle(_styleSheet, ESheet.Font).AddClass("Main");

            CloseButton = new Button().AddClass("CloseButton");
            CloseButton.clicked += this.Close;

            SearchField = new ToolbarSearchField().AddClass("SearchField");
            SearchField.RegisterValueChangedCallback(SearchingChanged);

            TitleBackground = new Image().AddClass("TitleBackground").AddElements(CloseButton, SearchField);

            Scroll = new ScrollView().AddClass("Scroll");

            Background = new Image().AddClass("Background").AddElements(Scroll);

            this.rootVisualElement.AddElements(TitleBackground, Background);

            CreateLabels();
            CreateBoxes(_labelList);
        }

        private void CreateLabels()
        {
            if (_isAction)
            {
                foreach (var type in MType.GetInheritedTypes<AIAction>())
                {
                    _labelList.Add(type.ToString().RemoveWord("YNL.SimpleAISystem.AIAction"));
                }
            }
            else
            {
                foreach (var type in MType.GetInheritedTypes<AIDecision>())
                {
                    _labelList.Add(type.ToString().RemoveWord("YNL.SimpleAISystem.AIDecision"));
                }
            }
        }
        private void CreateBoxes(List<string> list)
        {
            ClearBoxes();
            foreach (var type in list) AddBoxes(type);
        }
        private void AddBoxes(string label)
        {
            ESearchBox box = new ESearchBox(label, _isAction);
            box.Background.OnPointerDown += () => ChangeBox(box.Label);
            Scroll.AddElements(box);
        }
        private void ClearBoxes() => Scroll.Clear();

        private void ChangeBox(string label)
        {
            if (_isAction) _actionBox.OnSelectAction(label);
            else _transitionBox.OnSelectTransition(label);

            this.Close();
        }

        private void SearchingChanged(ChangeEvent<string> evt)
        {
            CreateBoxes(_labelList.Where(i => i.Contains(evt.newValue, System.StringComparison.OrdinalIgnoreCase)).ToList());

            evt.StopPropagation();
        }
    }
}
#endif
#endif
#endif