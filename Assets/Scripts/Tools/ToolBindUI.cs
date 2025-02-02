using UnityEditor;

public class ToolBindUI : EditorWindow
{
	[MenuItem("Tools/MapLoader")]
	public static void MapLoad()
	{
		CreateWindow<MapLoadTool>();
	}
}
