#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem.Editors
{
    public class ETransitionBox : Button
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/ETransitionBox";

        public Image LabelBackground;
        public StyledInteractableImage TitleBackground;
        public Image TagIcon;
        public Label Title;
        public StyledInteractableImage Expander;
        public Image TransitionBackground;
        public StyledStringEnumField TrueTransition;
        public StyledStringEnumField FalseTransition;
        public ScrollView Properties;
        public Button Delete;

        private AITransitionKey _key;
        private List<AIStateKey> _states;

        private Texture2D _icon;
        private bool _isExpanded;

        public SerializableDictionary<string, string> ReferencedProperties = new();
        private List<string> _availableState = new();

        private WAIBehaviourEditor_Main _main;

        public ETransitionBox(AITransitionKey key, List<AIStateKey> states, WAIBehaviourEditor_Main main) : base()
        {
            _main = main;
            _key = key;
            _states = states;
            ReferencedProperties = _key.Properties;
            _availableState = _states.Select(i => i.Name).ToList();

            this.AddStyle(_styleSheet, EStyleSheet.Font).SetName("Root").AddClass("Main");

            TagIcon = new Image().AddClass("TagIcon").SetBackgroundImage($"Textures/Icons/Decision");
            _icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().DecisionIcons.Find(i => i.Label == _key.Label)?.Icon;
            if (_icon.IsNull()) _icon = $"Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title = new Label(_key.Label.AddSpaces()).AddClass("Title");

            TitleBackground = new StyledInteractableImage().AddClass("TitleBackground").AddElements(TagIcon, Title);
            TitleBackground.OnPointerEnter += () => OnPointerHoverTitlePanel(true);
            TitleBackground.OnPointerExit += () => OnPointerHoverTitlePanel(false);
            TitleBackground.OnPointerDown += () => WAIBehaviourEditor_Popup.Open(300, 200, WPopupPivot.TopLeft, false, this);

            Expander = new StyledInteractableImage().AddClass("Expander");
            Expander.OnPointerDown += ExpandView;

            Delete = new Button().AddClass("Delete");
            Delete.clicked += DeleteBox;

            LabelBackground = new Image().AddClass("LabelBackground").AddElements(Delete, TitleBackground, Expander);

            TransitionBackground = new Image().AddClass("TransitionBackground");
            CreateTrueFalse();

            Properties = new ScrollView().AddClass("ClipPanel");

            this.AddElements(LabelBackground, TransitionBackground, Properties);
            this.RegisterCallback<DetachFromPanelEvent>(OnDetachedFromPanel);

            WAIBehaviourEditor_Action.AddState += OnStateAdded;
            WAIBehaviourEditor_Action.RemoveState += OnStateRemoved;
        }

        public void OnDetachedFromPanel(DetachFromPanelEvent evt)
        {
            WAIBehaviourEditor_Action.AddState -= OnStateAdded;
            WAIBehaviourEditor_Action.RemoveState -= OnStateRemoved;
        }

        private void OnPointerHoverTitlePanel(bool enter)
        {
            if (_isExpanded) TitleBackground.EnableClass(enter, "TitleBackground".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else TitleBackground.EnableClass(enter, "TitleBackground".ECustom("HoverOnTitle"));

            TagIcon.EnableClass(enter, "TagIcon".ECustom("HoverOnTitle"));
            if (!enter) TagIcon.SetBackgroundImage($"Textures/Icons/Decision");
            else TagIcon.SetBackgroundImage(_icon);
            Title.EnableClass(enter, "Title".ECustom("HoverOnTitle"));

            if (_isExpanded) Expander.EnableClass(enter, "Expander".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else Expander.EnableClass(enter, "Expander".ECustom("HoverOnTitle"));

            if (_isExpanded) Properties.EnableClass(enter, "ClipPanel".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else Properties.EnableClass(enter, "ClipPanel".ECustom("HoverOnTitle"));

            TransitionBackground.EnableClass(enter, "TransitionBackground".ECustom("HoverOnTitle"));

            Delete.EnableClass(enter, "Delete".ECustom("HoverOnTitle"));
        }
        private void ExpandView()
        {
            _isExpanded = !_isExpanded;

            if (_isExpanded)
            {
                AddProperties();
            }
            else
            {
                Properties.RemoveAllElements();
            }

            this.EnableClass(_isExpanded, "Main".ECustom("OnExpand"));
            Expander.EnableClass(_isExpanded, "Expander".ECustom("OnExpand"));
            Properties.EnableClass(_isExpanded, "ClipPanel".ECustom("OnExpand"));
        }
        public void AddProperties()
        {
            Type type = MType.GetTypeIgnoreAssembly($"YNL.SimpleAISystem.AIDecision{_key.Label}");

            if (type.IsNull()) return;

            FieldInfo[] fields = type.GetFieldsInSubclass();

            foreach (var field in fields)
            {
                string getProperty = null;
                if (ReferencedProperties.ContainsKey(field.Name)) getProperty = ReferencedProperties[field.Name];
                Properties.AddElements(EAIUtilities.CustomField(field, field.Name, getProperty, (a) => ReferencedProperties[field.Name] = a.ToString(), "LabelField", "BaseField"));
            }
        }

        private void CreateTrueFalse()
        {
            TrueTransition = new StyledStringEnumField("True", _availableState, (@true) => _key.True = FixSelectedState(@true), _key.True).AddClass("TransitionLabel", "TransitionField");
            FalseTransition = new StyledStringEnumField("False", _availableState, (@false) => _key.False = FixSelectedState(@false), _key.False).AddClass("TransitionLabel", "TransitionField");
            TransitionBackground.Clear();
            TransitionBackground.AddElements(TrueTransition, FalseTransition);
        }
        private void OnStateAdded(AIStateKey key)
        {
            _availableState.Add(key.Name);
            CreateTrueFalse();
        }
        private void OnStateRemoved(AIStateKey key)
        {
            _availableState.Remove(key.Name);
            CreateTrueFalse();
        }

        private string FixSelectedState(string state)
        {
            if (state.IsNullOrEmpty() || state == "_") state = "";
            return state;
        }

        public void OnSelectTransition(string label)
        {
            _key.Update(label);

            ReferencedProperties = _key.Properties;

            TagIcon.SetBackgroundImage($"Textures/Icons/Decision");
            _icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().DecisionIcons.Find(i => i.Label == _key.Label)?.Icon; 
            if (_icon.IsNull()) _icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title.SetText(_key.Label.AddSpaces());
        }
        private void DeleteBox()
        {
            _main.Handler.CurrentStateKey.Transitions.Remove(_key);
            this.RemoveFromHierarchy();
        }
    }
}
#endif
#endif
#endif