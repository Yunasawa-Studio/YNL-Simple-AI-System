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
            EditorManifest.AddRegistry("YunasawaStudio", "https://package.openupm.com", "com.yunasawa.ynl.editor", "com.yunasawa.ynl.utilities");
            EditorManifest.AddDependency("com.yunasawa.ynl.editor", "1.4.3");
            EditorManifest.AddDependency("com.yunasawa.ynl.utilities", "1.3.2");
            EditorDefineSymbols.AddSymbols("YNL_UTILITIES", "YNL_EDITOR");
        }
    }
}
#endif