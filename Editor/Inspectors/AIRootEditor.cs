#if UNITY_EDITOR && YNL_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using YNL.Editors.Visuals;
using YNL.Editors.Extensions;
using YNL.Extensions.Addons;

namespace YNL.SimpleAISystem.Editors
{
    [CustomEditor(typeof(AIRoot))]
    [CanEditMultipleObjects]
    public class AIRootEditor : Editor
    {
        private VisualElement _root;

        public override VisualElement CreateInspectorGUI()
        {
            Initialization();

            return _root;
        }

        private void Initialization()
        {
            _root = new VisualElement();

            _root.SetAsFlexInsppector();

            _root.AddElements(new StyledComponentHeader()
                .SetGlobalColor("#8FF2FF")
                .AddIcon("Icons/AI Root", MAddressType.Resources)
                .AddTitle("AI Root")
                .AddDocumentation("https://github.com/Yunasawa-Studio/YNL-Simple-AI-System")
                .AddBottomSpace(10));

            InspectorElement.FillDefaultInspector(_root, serializedObject, this);
        }
    }
}
#endif