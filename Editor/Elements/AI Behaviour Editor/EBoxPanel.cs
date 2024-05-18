#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine.UIElements;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.Windows;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class EBoxPanel : Button
    {
        private const string _styleSheet = "Style Sheets/AI Behaviour Editor/Elements/EBoxPanel";

        public Image Background;
        public ScrollView Scroll;
        public Label Title;
        public Button AddBox;

        private bool _isAction = true;
        private WAIBehaviourEditor_Main _main;

        public EBoxPanel(bool isAction, WAIBehaviourEditor_Main main) : base()
        {
            _isAction = isAction;
            _main = main;

            this.AddStyle(_styleSheet, EAddress.USSFont).AddClass("Main");

            Title = new Label().AddClass("Title");

            if (isAction)
            {
                this.AddClass("MainRight");
                Title.text = "ACTION: AI's Actions";
            }
            else
            {
                this.AddClass("MainLeft");
                Title.text = "TRANSITION: AI's Decisions";
            }

            Scroll = new ScrollView().AddClass("Sroll");
            AddBox = new Button().SetText("Add").AddClass("AddBox");
            AddBox.clicked += CreateBox;
            Background = new Image().AddClass("Background").AddElements(Scroll, AddBox);

            this.AddElements(Title, Background);
        }

        public void ClearBoxes() => Scroll.Clear();
        public void AddBoxes(params VisualElement[] box)
        {
            Scroll.AddElements(box);
        }
        public void CreateBox()
        {
            if (_main.Handler.Behaviour.IsNull())
            {
                WMessagePopup.Show("Select an AI Behaviour asset first!");
                return;
            }

            if (_isAction)
            {
                AIActionKey key = new("...");
                if (_main.Handler.CurrentStateKey.IsNull())
                {
                    MDebug.Caution("Please create or select one <b>State</b> before adding any <b>Action</b>");
                    return;
                }
                _main.Handler.CurrentStateKey.Actions.Add(key);
                AddBoxes(new EActionBox(key, _main));
            }
            else
            {
                AITransitionKey key = new("...");
                if (_main.Handler.CurrentStateKey.IsNull())
                {
                    MDebug.Caution("Please create or select one <b>State</b> before adding any <b>Transition</b>");
                    return;
                }
                _main.Handler.CurrentStateKey.Transitions.Add(key);
                AddBoxes(new ETransitionBox(key, _main.Handler.Behaviour.StateKeys, _main));
            }
        }
    }
}
#endif
#endif
#endif