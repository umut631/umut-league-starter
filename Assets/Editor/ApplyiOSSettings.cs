#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public static class UmutLeagueiOSSettings
{
    [MenuItem("UmutLeague/Apply iOS 60FPS Settings")]
    public static void ApplySettings()
    {
        // Basic PlayerSettings
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "com.yourname.umutleague");
        PlayerSettings.iOS.targetOSVersionString = "13.0";
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.iOS, ScriptingImplementation.IL2CPP);
        PlayerSettings.SetArchitecture(BuildTargetGroup.iOS, iOSArchitecture.ARM64);

        // Graphics API: Metal only
        PlayerSettings.SetGraphicsAPIs(BuildTarget.iOS, new[] { GraphicsDeviceType.Metal });

        // VSync off, encourage 60 FPS
        QualitySettings.vSyncCount = 0;

        // Try to find a URP asset in the project and assign it
        string[] guids = AssetDatabase.FindAssets("t:UniversalRenderPipelineAsset");
        if (guids.Length > 0)
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            var urp = AssetDatabase.LoadAssetAtPath<UniversalRenderPipelineAsset>(path);
            if (urp != null)
            {
                GraphicsSettings.renderPipelineAsset = urp;
                Debug.Log("Assigned URP Asset: " + path);
                // Enable SRP Batcher if available
#if UNITY_2021_2_OR_NEWER
                GraphicsSettings.useScriptableRenderPipelineBatcher = true;
#endif
            }
        }
        else
        {
            Debug.LogWarning("No UniversalRenderPipelineAsset found in project. Create a URP Asset and re-run this command.");
        }

        // Informative log
        Debug.Log("Applied iOS 60FPS settings. Please review Bundle Identifier and other project-specific values.");

        // Suggest creating a runtime targetFrameRate script
        if (EditorUtility.DisplayDialog("Apply Runtime TargetFrameRate?", "Do you want to add a small runtime script that sets Application.targetFrameRate = 60 on startup? (Recommended)", "Yes", "No"))
        {
            string runtimePath = "Assets/Scripts/ApplyRuntimeSettings.cs";
            if (!System.IO.File.Exists(runtimePath))
            {
                System.IO.File.WriteAllText(runtimePath, GetRuntimeScriptContent());
                AssetDatabase.ImportAsset(runtimePath);
                Debug.Log("Added runtime targetFrameRate script at " + runtimePath);
            }
            else
            {
                Debug.Log("Runtime script already exists: " + runtimePath);
            }
        }
    }

    static string GetRuntimeScriptContent()
    {
        return @"using UnityEngine;

[DefaultExecutionOrder(-100)]
public class ApplyRuntimeSettings : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        // Optional: reduce resolution on older devices or provide quality switching
        Debug.Log("ApplyRuntimeSettings: targetFrameRate set to 60");
    }
}
";
    }
}
#endif
