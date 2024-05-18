#if UNITY_EDITOR
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.UIElements;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class EStateBox : EInteractableButton
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/EStateBox";

        public Button Background;
        public Image Icon;
        public Label Title;
        public TextField Input;
        public Button Rename;
        public Button Delete;

        private EStatePanel _panel;

        public string Name;
        public bool Selected;

        public EStateBox(EStatePanel panel, AIStateKey state) : base()
        {
            this.AddStyle(_styleSheet, EAddress.USSFont).AddClass("Main");

            Texture2D icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().StateIcons.Find(i => i.Label == state.Name)?.Icon;
            if (icon.IsNull()) icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();
            Icon = new Image().AddClass("Icon").SetBackgroundImage(icon);
            Title = new Label(state.Name).AddClass("Title");

            Rename = new Button().AddClass("Rename");
            Rename.clickable.clicked += StartRenameState;

            Input = new TextField().AddClass("Input").SetName("RenameTextField");
            Input.RegisterCallback<FocusOutEvent>(EndRenameState);
            Input.RegisterValueChangedCallback(evt => state.Name = evt.newValue);

            Background = new Button().AddClass("Background").AddElements(Icon, Title, Rename);

            Delete = new Button().AddClass("Delete");
            Delete.clicked += RemoveState;

            this.AddElements(Delete, Background);
            this.OnPointerDown += SelectInPanel;

            _panel = panel;
            Name = state.Name;
        }

        public void SelectInPanel() => _panel.SelectState(Name);
        public void SelectState(bool selected)
        {
            Selected = selected;

            Background.EnableClass(selected, "Background_Selected");
            Title.EnableClass(selected, "Title_Selected");
            Icon.EnableClass(selected, "Icon_Selected");
        }

        private void StartRenameState()
        {
            Title.RemoveFromHierarchy();
            Rename.RemoveFromHierarchy();

            Background.AddElements(Input);
            Input.value = Title.text;
        }
        private void EndRenameState(FocusOutEvent evt)
        {
            Input.RemoveFromHierarchy();

            Title.SetText(Input.value);
            Background.AddElements(Title, Rename);

            Texture2D icon = $"Scriptable Objects/AI Icon".LoadResource<EAIIcon>().StateIcons.Find(i => i.Label == Input.value)?.Icon;
            if (icon.IsNull()) icon = "Textures/Behaviours/Null".LoadResource<Texture2D>();
            Icon.SetBackgroundImage(icon);

            Name = Input.value;
        }

        private void RemoveState()
        {
            int index = _panel.Scroll.Children().ToArray().IndexOf(this);
            WAIBehaviourEditor_Action.RemoveState?.Invoke(_panel.Behaviour.StateKeys[index]);

            _panel.Behaviour.StateKeys.RemoveAt(index);
            this.RemoveFromHierarchy();
        }
    }
}
#endif