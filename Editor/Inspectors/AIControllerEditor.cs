#if UNITY_EDITOR && YNL_EDITOR
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using YNL.Editors.UIElements.Flexs;
using YNL.Editors.Windows.Utilities;
using YNL.Extensions.Addons;

namespace YNL.SimpleAISystem.Editors
{
    [CustomEditor(typeof(AIController))]
    [CanEditMultipleObjects]
    public class AIControllerEditor : Editor
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

            _root.AddElements(new FlexComponentHeader()
                .SetGlobalColor("#8FF2FF")
                .AddIcon("Icons/AI Controller", MAddressType.Resources)
                .AddTitle("AI Controller")
                .AddDocumentation("https://github.com/Yunasawa-Studio/YNL-Simple-AI-System")
                .AddBottomSpace(10));

            InspectorElement.FillDefaultInspector(_root, serializedObject, this);
        }
    }
}
#endif