#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows.Utilities;

namespace YNL.SimpleAISystem.Editors
{
    public class EIconPanel : Image
    {
        private const string _styleSheet = "Style Sheets/AI Icon Editor/Elements/EIconPanel";

        public StyledInteractableAssetsField<Texture2D> Wrapper;
        public ScrollView Scroll;
        public EIconBox Box;

        public EIconPanel()
        {
            this.AddStyle(_styleSheet, EStyleSheet.Font).AddClass("Main");

            //Wrapper = new EInteractableAssetsField<Texture2D>().AddClass("Wrapper");
            //Wrapper.OnDragEnter += OnDragEnter;
            //Wrapper.OnDragExit += OnDragExit;
            //Wrapper.OnDragPerform += OnDragPerform;

            Box = new EIconBox().AddClass("Box");

            Scroll = new ScrollView().AddClass("Scroll");

            for (int i = 0; i < 20; i++)
            {
                Scroll.AddElements(new EIconBox().AddClass("Box"));
            }

            this.AddElements(Scroll);
        }

        private void OnDragEnter()
        {
            Wrapper.EnableClass("WrapperEnter");
        }

        private void OnDragExit()
        {
            Wrapper.DisableClass("WrapperEnter");
        }

        private void OnDragPerform(Texture2D[] texture)
        {
            Wrapper.DisableClass("WrapperEnter");
        }
    }
}
#endif
#endif
#endif