#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows;
using YNL.Extensions.Methods;
using YNL.Editors.Windows.Utilities;
using YNL.Utilities.Addons;

namespace YNL.SimpleAISystem.Editors
{
    public class EActionBox : Button
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/EActionBox";

        public Image LabelBackground;
        public StyledInteractableImage TitleBackground;
        public Image TagIcon;
        public Label Title;
        public StyledInteractableImage Expander;
        public ScrollView Properties;
        public Button Delete;

        private AIActionKey _key;

        private Texture2D _icon;
        private bool _isExpanded;

        public SerializableDictionary<string, string> ReferencedProperties = new();
        private WAIBehaviourEditor_Main _main;

        public EActionBox(AIActionKey actionKey, WAIBehaviourEditor_Main main) : base()
        {
            _main = main;
            _key = actionKey;
            ReferencedProperties = _key.Properties;

            this.AddStyle(_styleSheet, EStyleSheet.Font).SetName("Root").AddClass("Main");

            TagIcon = new Image().AddClass("TagIcon").SetBackgroundImage($"Textures/Icons/Tag");
            _icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().ActionIcons.Find(i => i.Label == _key.Label)?.Icon;
            if (_icon.IsNull()) _icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title = new Label(_key.Label.AddSpaces()).AddClass("Title");

            TitleBackground = new StyledInteractableImage().AddClass("TitleBackground").AddElements(TagIcon, Title);
            TitleBackground.OnPointerEnter += () => OnPointerHoverTitlePanel(true);
            TitleBackground.OnPointerExit += () => OnPointerHoverTitlePanel(false);
            TitleBackground.OnPointerDown += () => WAIBehaviourEditor_Popup.Open(300, 200, WPopupPivot.TopLeft, true, this);

            Expander = new StyledInteractableImage().AddClass("Expander");
            Expander.OnPointerDown += ExpandView;

            Delete = new Button().AddClass("Delete");
            Delete.clicked += DeleteBox;

            LabelBackground = new Image().AddClass("LabelBackground").AddElements(Delete, TitleBackground, Expander);

            Properties = new ScrollView().AddClass("Properties");

            this.AddElements(LabelBackground, Properties);
        }

        private void OnPointerHoverTitlePanel(bool enter)
        {
            if (_isExpanded) TitleBackground.EnableClass(enter, "TitleBackground".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else TitleBackground.EnableClass(enter, "TitleBackground".ECustom("HoverOnTitle"));

            TagIcon.EnableClass(enter, "TagIcon".ECustom("HoverOnTitle"));
            if (!enter) TagIcon.SetBackgroundImage("Textures/Icons/Tag");
            else TagIcon.SetBackgroundImage(_icon);
            Title.EnableClass(enter, "Title".ECustom("HoverOnTitle"));

            if (_isExpanded) Expander.EnableClass(enter, "Expander".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else Expander.EnableClass(enter, "Expander".ECustom("HoverOnTitle"));

            if (_isExpanded) Properties.EnableClass(enter, "Properties".ECustom("HoverOnTitle").ECustom("OnExpand"));
            else Properties.EnableClass(enter, "Properties".ECustom("HoverOnTitle"));

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
            Properties.EnableClass(_isExpanded, "Properties".ECustom("OnExpand"));
        }

        public void AddProperties()
        {
            Type type = MType.GetTypeIgnoreAssembly($"YNL.SimpleAISystem.AIAction{_key.Label}");
            
            if (type.IsNull()) return;

            FieldInfo[] fields = type.GetFieldsInSubclass();

            foreach (var field in fields)
            {
                string getProperty = null;
                if (ReferencedProperties.ContainsKey(field.Name)) getProperty = ReferencedProperties[field.Name];
                Properties.AddElements(EAIUtilities.CustomField(field, field.Name, getProperty, (a) => ReferencedProperties[field.Name] = a.ToString(), "LabelField", "BaseField"));
            }
        }

        public void OnSelectAction(string label)
        {
            _key.Update(label);

            ReferencedProperties = _key.Properties;

            TagIcon.SetBackgroundImage($"Textures/Icons/Tag");
            //_icon = $"Textures/Behaviours/Actions/{_key.Label}".LoadResource<Texture2D>();
            _icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().ActionIcons.Find(i => i.Label == _key.Label)?.Icon;
            if (_icon.IsNull()) _icon = $"Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title.SetText(_key.Label.AddSpaces());
        }

        private void DeleteBox()
        {
            _main.Handler.CurrentStateKey.Actions.Remove(_key);
            this.RemoveFromHierarchy();
        }
    }
}
#endif
#endif
#endif