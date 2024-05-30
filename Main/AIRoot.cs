#if YNL_UTILITIES
using UnityEngine;
using YNL.Extensions.Methods;

namespace YNL.SimpleAISystem
{
    public class AIRoot : MonoBehaviour
    {
        public AIController Controller;

        #region MonoBehaviour
        private void OnValidate()
        {
            if (Controller.IsNull()) Controller = GetComponentInChildren<AIController>();
        }

        private void Start()
        {
            if (Controller.IsNull()) Controller = GetComponentInChildren<AIController>();
        }
        #endregion

        public void EnableAI(bool enable) => Controller.enabled = enable;
    }
}
#endif