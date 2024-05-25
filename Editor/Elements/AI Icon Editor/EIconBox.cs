#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows.Utilities;

namespace YNL.SimpleAISystem.Editors
{
    public class EIconBox : Image
    {
        private const string _styleSheet = "Style Sheets/AI Icon Editor/Elements/EIconBox";

        public StyledInteractableImage Background;

        public EIconBox()
        {
            this.AddStyle(_styleSheet, EStyleSheet.Font).AddClass("Main");

            Background = new StyledInteractableImage().AddClass("Background");

            this.AddElements(Background);
        }


    }
}
#endif
#endif
#endif