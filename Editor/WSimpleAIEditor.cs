#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEditor;
using UnityEngine;
using YNL.Editors.Visuals;
using YNL.Extensions.Methods;
using YNL.Editors.Windows;
using YNL.Editors.Extensions;

namespace YNL.SimpleAISystem.Editors
{
    public class WSimpleAIEditor : EditorWindow
    {
        #region ▶ Editor Asset Fields/Properties
        public const string WindowIconPath = "Textures (Obsoleted)/Editors/Shield Bordered";
        #endregion

        #region ▶ Visual Elements
        public WAIBehaviourEditor_Main AIBehaviourEditor;
        public WAIIconEditor_Main AIIconEditor;

        public StyledWindowTagPanel WindowTagPanel;
        #endregion

        #region ▶ General Fields/Properties
        private float _tagPanelWidth = 200;

        private IMain _selectedWindow;
        #endregion

        [MenuItem("🔗 YのL/▷ YNL - Simple AI System/🎲 Editor Window")]
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
            Texture2D windowIcon = "Textures (Obsoleted)/Editors/Shield".LoadResource<Texture2D>();

            Texture2D aiBehaviourIcon = "Textures (Obsoleted)/Editors/Scroll1".LoadResource<Texture2D>();
            Texture2D aiIconIcon = "Textures (Obsoleted)/Editors/Map".LoadResource<Texture2D>();

            Texture2D waitIcon = "Textures (Obsoleted)/Icons/Time1".LoadResource<Texture2D>();

            WindowTagPanel = new(windowIcon, "Simple AI", "Editor Center", _tagPanelWidth, new StyledWindowTag[]
            {
                new StyledWindowTag(aiBehaviourIcon, "AI Behaviour Editor", "Simple AI", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.AIBehaviour)),
                new StyledWindowTag(aiIconIcon, "AI Icon Editor", "Simple AI", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.AIIcon)),
                new StyledWindowTag(waitIcon, "Coming Soon", "", Color.white, _tagPanelWidth - 15, () => SwitchWindow(WRPGWindowTag.C))
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

    public interface IMain
    {
        public virtual void OnSelectionChange() { }
        public virtual void CreateGUI() { }
        public virtual void OnGUI() { }

        public virtual void OpenInstruction() { }
    }
}
#endif
#endif
#endif
