#if UNITY_EDITOR
using System.Linq;
using UnityEditor;

namespace YNL.SimpleAISystem.Editors
{
    public class YNLSimpleAISystemSetup : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            var inPackages = importedAssets.Any(path => path.StartsWith("Packages/")) ||
                deletedAssets.Any(path => path.StartsWith("Packages/")) ||
                movedAssets.Any(path => path.StartsWith("Packages/")) ||
                movedFromAssetPaths.Any(path => path.StartsWith("Packages/"));

            if (inPackages)
            {
                InitializeOnLoad();
            }
        }

        public static void InitializeOnLoad()
        {
#if !YNL_EDITOR
        Debug.Log($"<color=#FF983D><b>⚠ Caution:</b></color> <color=#fffc54><b>YNL - Simple AI System</b></color> requires <a href=\"https://github.com/Yunasawa/YNL-Utilities\"><b>YNL - Editor</b></a>");
#elif !YNL_UTILITIES
        Debug.Log($"<color=#FF983D><b>⚠ Caution:</b></color> <color=#fffc54><b>YNL - Simple AI System</b></color> requires <a href=\"https://github.com/Yunasawa/YNL-Editor\"><b>YNL - Utilities</b></a>");
#endif
        }
    }
}
#endif