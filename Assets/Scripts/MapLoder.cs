using System.Collections;
using System.Collections.Generic;
using System.IO;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Tilemaps;

public class MapLoder : MonoBehaviour
{
	public static string map_file_path = "Resources/MapData";
	public static string map_file_name = "map_data.txt";
	public static string webAppUrl = "https://script.google.com/macros/s/AKfycbwrIbE8EISHPmZCxsctEQWGdwheVzWDtQh1-VO7eNyPsCo5QWDS-U3ZSyRah20tHcT-6A/exec";

	public string tileMapPath = "Resources/TileMap/TestMap";

	public Tilemap tile_maps;

	public static IEnumerator DataLoad()
	{
		UnityWebRequest request = UnityWebRequest.Get(webAppUrl);
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			string jsonResponse = request.downloadHandler.text;
			string path = Path.Combine(Application.dataPath, map_file_path);
			string full_path = Path.Combine(path, map_file_name);

			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}

			File.WriteAllText(full_path, jsonResponse);
		}
		else
		{
			Debug.LogError("Error: " + request.error);
		}

	}

	//async 공부 중
	//public static async Task _DataLoad()
	//{
	//	using (HttpClient client = new HttpClient())
	//	{
	//		HttpResponseMessage response = await client.GetAsync(webAppUrl);
	//		response.EnsureSuccessStatusCode(); // 오류 발생 시 예외 처리

	//		string responseBody = await response.Content.ReadAsStringAsync();
	//		Console.WriteLine("응답 데이터:\n" + responseBody);

	//		string path = Path.Combine(Application.dataPath, map_file_path);
	//		string full_path = Path.Combine(path, map_file_name);

	//		if (!Directory.Exists(map_file_path))
	//			Directory.CreateDirectory(map_file_path);

	//		File.WriteAllText(full_path, responseBody);
	//	}
	//}

	public void TranslateMapData()
	{
		List<SheetData> data;
		string txt = string.Empty;
		txt = File.ReadAllText(map_file_path);
		data = JsonUtility.FromJson<List<SheetData>>(txt);
	}
}

[System.Serializable]
public class SheetDataWrapper
{
	public List<SheetData> sheets;
}

[System.Serializable]
public class SheetData
{
	public string name;
	public List<List<string>> data;
}

