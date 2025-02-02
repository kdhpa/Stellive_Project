using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

public class MapLoadTool : EditorWindow
{

	private void OnGUI()
	{
		GUILayout.Space(50);
		GUILayout.Label("시트 갱신 해주기", EditorStyles.boldLabel);

		if ( GUILayout.Button("시트 갱신") )
		{
			EditorCoroutineUtility.StartCoroutineOwnerless(MapLoder.DataLoad());
		}

		GUILayout.Space(50);
		GUILayout.Label("맵 만들어주기", EditorStyles.boldLabel);

		if ( GUILayout.Button("맵 로드") )
		{
			EditorCoroutineUtility.StartCoroutineOwnerless(MapLoder.DataLoad());
		}
	}
}
