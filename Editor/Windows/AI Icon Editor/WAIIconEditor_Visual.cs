#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using UnityEngine;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Styled;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class WAIIconEditor_Visual : VisualElement
    {
        #region ▶ Editor Contants
        private const string _windowIcon = "Textures/Editors/Map";
        private const string _windowTitle = "AI Icon Editor";
        private const string _windowSubtitle = "Editor tool for customizing AI Icons";
        #endregion
        #region ▶ Visual Elements
        private WAIIconEditor_Main _main;

        private EWindowTitle _windowTitlePanel;
        private EWindowTagPanel _tagPanel;

        private VisualElement _handlerWindow;
        private Image _mainWindow;
        #endregion
        #region ▶ Editor Properties
        private float _tagPanelWidth = 200;
        #endregion

        public WAIIconEditor_Visual(EWindowTagPanel tagPanel, WAIIconEditor_Main main) : base()
        {
            _tagPanel = tagPanel;
            _main = main;

            CreateElements();

            PanelMarginHandler();
            MainWindowHandler();

            this.AddElements(_handlerWindow, _windowTitlePanel);
        }

        private void CreateElements()
        {
            _windowTitlePanel = new EWindowTitle(_windowIcon.LoadResource<Texture2D>(), _windowTitle, _windowSubtitle).AddClass("WindowTitle");

            this.AddStyle("Style Sheets/AI Icon Editor/WAIIconEditor", EStyleSheet.Font).AddClass("Main");
        }

        private void MainWindowHandler()
        {
            _handlerWindow = new VisualElement().AddClass("HandlerWindow");
            _mainWindow = new Image().AddClass("MainWindow");

            EIconPanel panel1 = new();
            EIconPanel panel2 = new();
            EIconPanel panel3 = new();

            _mainWindow.AddElements(panel1).AddVSpace(15).AddElements(panel2).AddVSpace(15).AddElements(panel3);

            _handlerWindow.AddElements(_mainWindow);
        }

        private void PanelMarginHandler()
        {
            _tagPanel.OnPointerEnter += () =>
            {
                _windowTitlePanel.Panel.SetMarginLeft(_tagPanelWidth - 150);
                _mainWindow.SetMarginLeft(_tagPanelWidth + 2);
            };
            _tagPanel.OnPointerExit += () =>
            {
                _windowTitlePanel.Panel.SetMarginLeft(0);
                _mainWindow.SetMarginLeft(_tagPanelWidth - 148);
            };
        }
    }
}
#endif
#endif
#endif