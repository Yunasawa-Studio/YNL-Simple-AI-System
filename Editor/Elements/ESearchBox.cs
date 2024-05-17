#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.UIElements;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class ESearchBox : VisualElement
    {
        private const string _styleSheet = "Style Sheets/Elements/ESearchBox";

        public EInteractableImage Background;

        public Image TagIcon;
        public Label Title;

        private Texture2D _icon;
        public string Label;

        public ESearchBox(string label, bool isAction) : base()
        {
            Label = label;

            this.AddStyle(_styleSheet, EAddress.USSFont).SetName("Root").AddClass("MainA");

            TagIcon = new Image().AddClass("TagIcon");
            if (isAction) TagIcon.SetBackgroundImage("Textures/Icons/Tag");
            else TagIcon.SetBackgroundImage("Textures/Icons/Decision"); ;
            _icon = $"Textures/Behaviours/Actions/{label}".LoadResource<Texture2D>();
            if (_icon.IsNull()) _icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();

            Title = new Label(label.AddSpaces()).AddClass("Title");

            Background = new EInteractableImage().AddClass("Background").AddElements(TagIcon, Title);

            this.AddElements(Background);
        }
    }
}
#endif