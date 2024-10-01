#if UNITY_EDITOR
#if YNL_EDITOR
#if YNL_UTILITIES
using System;
using UnityEditor;
using UnityEngine;
using YNL.Editors.Visuals;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem.Editors
{
    public class WAIBehaviourEditor_Main : IMain
    {
        public WAIBehaviourEditor_Handler Handler;
        public WAIBehaviourEditor_Visual Visual;

        public EAIReference Reference;

        public WAIBehaviourEditor_Main(StyledWindowTagPanel tagPanel) : base()
        {
            Handler = new(this);
            Visual = new(tagPanel, this);

            Reference = "Scriptable Objects/AI Reference".LoadResource<EAIReference>();
            Visual.ReferencedBehaviour.Background.AssignObject(Reference.Behaviour);
        }

        public static void ShowWindow(AIBehaviour behaviour)
        {
            WSimpleAIEditor window = EditorWindow.GetWindow<WSimpleAIEditor>("Simple AI Editor");
            Texture2D texture = WSimpleAIEditor.WindowIconPath.LoadResource<Texture2D>();

            window.SwitchWindow(WRPGWindowTag.AIBehaviour);
            window.titleContent.image = texture;
            window.maxSize = new Vector2(800, 500);
            window.minSize = window.maxSize;

            window.AIBehaviourEditor.Visual.ReferencedBehaviour.Background.AssignObject(behaviour);
            window.AIBehaviourEditor.Reference.AssignBehaviour(behaviour);
        }

        public void OnGUI()
        {
            Visual.OnGUI();
        }
    }

    public static class WAIBehaviourEditor_Action
    {
        public static Action<AIStateKey> AddState;
        public static Action<AIStateKey> RemoveState;
    }
}
#endif
#endif
#endif