using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

public class MapLoadTool : EditorWindow
{

	private void OnGUI()
	{
		GUILayout.Space(50);
		GUILayout.Label("��Ʈ ���� ���ֱ�", EditorStyles.boldLabel);

		if ( GUILayout.Button("��Ʈ ����") )
		{
			EditorCoroutineUtility.StartCoroutineOwnerless(MapLoder.DataLoad());
		}

		GUILayout.Space(50);
		GUILayout.Label("�� ������ֱ�", EditorStyles.boldLabel);

		if ( GUILayout.Button("�� �ε�") )
		{
			EditorCoroutineUtility.StartCoroutineOwnerless(MapLoder.DataLoad());
		}
	}
}
