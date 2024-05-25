#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.UIElements.Styled;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class ESearchBox : VisualElement
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/ESearchBox";

        public StyledInteractableImage Background;

        public Image TagIcon;
        public Label Title;

        private Texture2D _icon;
        public string Label;

        public ESearchBox(string label, bool isAction) : base()
        {
            Label = label;

            this.AddStyle(_styleSheet, EStyleSheet.Font).SetName("Root").AddClass("MainA");

            TagIcon = new Image().AddClass("TagIcon");
            if (isAction) TagIcon.SetBackgroundImage("Textures/Icons/Tag");
            else TagIcon.SetBackgroundImage("Textures/Icons/Decision"); ;
            _icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().ActionIcons.Find(i => i.Label == label)?.Icon;
            if (_icon.IsNull()) _icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title = new Label(label.AddSpaces()).AddClass("Title");

            Background = new StyledInteractableImage().AddClass("Background").AddElements(TagIcon, Title);

            this.AddElements(Background);
        }
    }
}
#endif
#endif
#endif