#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using UnityEngine;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows.Utilities;
using YNL.Editors.Windows;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class WSimpleAIEditor : EditorWindow
    {
        #region ▶ Editor Asset Fields/Properties
        public const string WindowIconPath = "Textures/Editors/Shield Bordered";
        #endregion

        #region ▶ Visual Elements
        public WAIBehaviourEditor_Main AIBehaviourEditor;
        public WAIIconEditor_Main AIIconEditor;

        public EWindowTagPanel WindowTagPanel;
        #endregion

        #region ▶ General Fields/Properties
        private float _tagPanelWidth = 200;

        private IMain _selectedWindow;
        #endregion

        [MenuItem("🔗 YのL/🔗 Windows/🔗 Simple AI Editor")]
        public static void ShowWindow()
        {
            WSimpleAIEditor window = GetWindow<WSimpleAIEditor>("Simple AI Editor");
            Texture2D texture = WindowIconPath.LoadResource<Texture2D>();

            window.titleContent.image = texture;
            window.maxSize = new Vector2(800, 500);
            window.minSize = window.maxSize;
        }

        #region ▶ Editor Messages
        private void OnSelectionChange()
        {
            if (!_selectedWindow.IsNull()) _selectedWindow.OnSelectionChange();
        }

        public void CreateGUI()
        {
            Texture2D windowIcon = "Textures/Editors/Shield".LoadResource<Texture2D>();

            Texture2D aiBehaviourIcon = "Textures/Editors/Scroll1".LoadResource<Texture2D>();
            Texture2D aiIconIcon = "Textures/Editors/Map".LoadResource<Texture2D>();

            Texture2D waitIcon = "Textures/Icons/Time1".LoadResource<Texture2D>();

            WindowTagPanel = new(windowIcon, "Simple AI", "Editor Center", _tagPanelWidth, new EWindowTag[]
            {
                new EWindowTag(aiBehaviourIcon, "AI Behaviour Editor", "Simple AI", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.AIBehaviour)),
                new EWindowTag(aiIconIcon, "AI Icon Editor", "Simple AI", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.AIIcon)),
                new EWindowTag(waitIcon, "Coming Soon", "", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.C))
            });

            AIBehaviourEditor = new WAIBehaviourEditor_Main(WindowTagPanel);
            AIIconEditor = new WAIIconEditor_Main(WindowTagPanel);

            SwitchWindow(WRPGWindowTag.AIBehaviour);
        }

        public void OnGUI()
        {
            if (!_selectedWindow.IsNull()) _selectedWindow.OnGUI();
        }
        #endregion

        public void SwitchWindow(WRPGWindowTag windowTag)
        {
            WindowTagPanel.ForceSelectTag((int)windowTag);
            rootVisualElement.RemoveAllElements();
            switch (windowTag)
            {
                case WRPGWindowTag.AIBehaviour:
                    _selectedWindow = AIBehaviourEditor;
                    rootVisualElement.Add(AIBehaviourEditor.Visual);
                    break;
                case WRPGWindowTag.AIIcon:
                    _selectedWindow = AIIconEditor;
                    rootVisualElement.Add(AIIconEditor.Visual);
                    break;
            }
            rootVisualElement.Add(WindowTagPanel);
        }
    }

    public enum WRPGWindowTag
    {
        AIBehaviour, AIIcon, C, D, E, F
    }
}
#endif
#endif
#endif
