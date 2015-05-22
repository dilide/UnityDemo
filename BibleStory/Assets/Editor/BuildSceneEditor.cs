using UnityEngine;
using UnityEditor;
using System.Collections;

public class BuildSceneEditor{
	[@MenuItem("Build/BuildPlayer")]
	static void Build(){
		string[] levels = new string[]{"Assets/Scenes/Main.unity"};
		BuildPipeline.BuildPlayer (levels,"streamed.unity3d",BuildTarget.iOS,BuildOptions.BuildAdditionalStreamedScenes);
		AssetDatabase.Refresh ();
	}
}