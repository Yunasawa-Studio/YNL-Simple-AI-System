#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.UIElements;
using YNL.Editors.Windows.Utilities;

namespace YNL.SimpleAISystem.Editors
{
    public class EIconPanel : Image
    {
        private const string _styleSheet = "Style Sheets/AI Icon Editor/Elements/EIconPanel";

        public EInteractableAssetsField<Texture2D> Wrapper;

        public EIconPanel()
        {
            this.AddStyle(_styleSheet, EAddress.USSFont).AddClass("Main");

            Wrapper = new EInteractableAssetsField<Texture2D>().AddClass("Wrapper");

            this.AddElements(Wrapper);
        }
    }
}
#endif
#endif
#endif