#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine.UIElements;
using YNL.Editors.Visuals;
using YNL.Editors.Extensions;

namespace YNL.SimpleAISystem.Editors
{
    public class EIconBox : Image
    {
        private const string _styleSheet = "Style Sheets/AI Icon Editor/Elements/EIconBox";

        public FlexibleInteractImage Background;

        public EIconBox()
        {
            this.AddStyle(_styleSheet, ESheet.Font).AddClass("Main");

            Background = new FlexibleInteractImage().AddClass("Background");

            this.AddElements(Background);
        }


    }
}
#endif
#endif
#endif