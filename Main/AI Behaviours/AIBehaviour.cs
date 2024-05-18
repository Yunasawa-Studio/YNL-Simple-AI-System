#if YNL_UTILITIES
using System.Collections.Generic;
using YNL.Extensions.Methods;
using YNL.Utilities.Addons;
#if UNITY_EDITOR
using UnityEditor.Callbacks;
using UnityEditor;
#endif
using UnityEngine;

namespace YNL.SimpleAISystem
{
    [CreateAssetMenu(fileName = "AI Behaviour", menuName = "🔗 YのL/💫 Simple AI System/🚧 AI: Behaviour")]
    public class AIBehaviour : ScriptableObject
    {
        public List<AIStateKey> StateKeys = new();

        #region ▶ Editor Methods
#if UNITY_EDITOR
        [OnOpenAsset]
        public static bool OnOpenAsset(int instanceID)
        {
            AIBehaviour asset = EditorUtility.InstanceIDToObject(instanceID) as AIBehaviour;
            if (asset != null)
            {
                //WAIBehaviourEditor_Main.ShowWindow(asset);
                return true;
            }
            return false;
        }

        private void OnEnable()
        {
            Texture2D icon = Resources.Load<Texture2D>("Icons/AIBehaviour Icon");
            EditorGUIUtility.SetIconForObject(this, icon);
        }

        [ContextMenu("Save Data")]
        public void SaveData()
        {
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
        #endregion

        #region ▶ Handler Methods
        public AIState[] GetStates(AIController controller)
        {
            List<AIState> states = new();
            AIState state;

            foreach (var stateKey in StateKeys)
            {
                state = new();
                state.Name = stateKey.Name;

                foreach (var actionKey in stateKey.Actions)
                {
                    AIAction action = controller.GetAction(actionKey.Label);
                    action.Convert(actionKey.Properties);
                    state.Actions.Add(action);
                }

                foreach (var decisionKey in stateKey.Transitions)
                {
                    AIDecision decision = controller.GetDecision(decisionKey.Label);
                    decision.Convert(decisionKey.Properties);
                    state.Transitions.Add(new(decision, decisionKey.True, decisionKey.False));
                }

                state.Initialize(controller);
                states.Add(state);
            }

            return states.ToArray();
        }

        public SerializableDictionary<string, AIAction> GetActions(AIController controller)
        {
            if (StateKeys.IsNullOrEmpty()) return null;

            SerializableDictionary<string, AIAction> dictionary = new();

            foreach (var stateKey in StateKeys)
            {
                foreach (var actionKey in stateKey.Actions)
                {
                    if (!dictionary.ContainsKey(actionKey.Label)) dictionary.Add(actionKey.Label, controller.GetAction(actionKey.Label));
                }
            }

            return dictionary;
        }
        #endregion
    }
}
#endif