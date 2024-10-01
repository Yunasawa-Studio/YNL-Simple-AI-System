#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using YNL.Editors.Visuals;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class WAIIconEditor_Main : IMain
    {
        public WAIIconEditor_Visual Visual;
        public WAIIconEditor_Handler Handler;

        public EAIIcon Icon;

        public WAIIconEditor_Main(StyledWindowTagPanel tagPanel) : base()
        {
            Icon = "Scriptable Objects/AI Icon".LoadResource<EAIIcon>();

            Visual = new(tagPanel, this);
        }
    }
}
#endif
#endif
#endif