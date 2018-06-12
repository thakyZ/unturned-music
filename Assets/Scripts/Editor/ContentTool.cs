using UnityEditor;
using UnityEngine;
using System.IO;

namespace SDG.Unturned.Tools
{
    /// <summary>
    /// Simple tool to export all new assetbundles. 
    /// </summary>
	public class ContentTool : EditorWindow 
	{
		[MenuItem("Window/Content Tool")]
		public static void ShowWindow() 
		{
			GetWindow(typeof(ContentTool));
		}

        /// <summary>
        /// File path relative to Unity project folder to create assetbundle files.
        /// </summary>
        private string buildPath;
        
		private void OnGUI()
		{
            buildPath = EditorGUILayout.TextField("Build Path", buildPath);

            if(GUILayout.Button("Build AssetBundles"))
            {
                BuildPipeline.BuildAssetBundles(buildPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            }

            if(GUILayout.Button("Build AssetBundles (Force Rebuild)"))
            {
                BuildPipeline.BuildAssetBundles(buildPath, BuildAssetBundleOptions.ForceRebuildAssetBundle, BuildTarget.StandaloneWindows64);
            }
        }

        private void OnEnable()
        {
            titleContent = new GUIContent("Content Tool");
            
            buildPath = EditorPrefs.GetString("Content_Build_Path");
            if(string.IsNullOrEmpty(buildPath))
            {
                buildPath = "Builds/Shared/Content";
            }
        }
	}
}