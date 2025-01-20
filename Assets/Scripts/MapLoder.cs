using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Tilemaps;

public class MapLoder : MonoBehaviour
{
	private string sheetData;
	//export?format=tsv&range=A1:AH13
	public string webAppUrl = "https://script.google.com/macros/s/AKfycbwrIbE8EISHPmZCxsctEQWGdwheVzWDtQh1-VO7eNyPsCo5QWDS-U3ZSyRah20tHcT-6A/exec";
	public string tileMapPath = "Assets/Resources/TileMap/TestMap";


	public SheetDataWrapper data;
	public Tilemap tile_maps;

	private void Start()
	{
		StartCoroutine(Load());
	}

	public IEnumerator Load()
	{
		UnityWebRequest request = UnityWebRequest.Get(webAppUrl);
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			string jsonResponse = request.downloadHandler.text;
			Debug.Log("Sheet Data: " + jsonResponse);

			// JSON 데이터를 파싱
			data = JsonUtility.FromJson<SheetDataWrapper>(jsonResponse);

			// 데이터 확인 (예제)
			foreach (var sheet in data.sheets)
			{
				Debug.Log($"Sheet Name: {sheet.Key}");
				foreach (var row in sheet.Value)
				{
					Debug.Log(string.Join(", ", row));
				}
			}
		}
		else
		{
			Debug.LogError("Error: " + request.error);
		}

	}

	public void TranslateMapData()
	{
		string[] line = sheetData.Split("\n");
		print(line);
	}
}

[System.Serializable]
public class SheetDataWrapper
{
	public Dictionary<string, List<string[]>> sheets = new Dictionary<string, List<string[]>>();
}

