using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
	public static MainManager Instance { get; private set; }

	public Color teamColor;

	private void Awake()
	{
		if (Instance != null)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(this);

		LoadColor();
	}

	public void SaveColor()
	{
		SaveData data = new SaveData();
		data.TeamColor = teamColor;

		string json = JsonUtility.ToJson(data);

		File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
	}

	public void LoadColor()
	{
		string path = Application.persistentDataPath + "/savefile.json";
		if (File.Exists(path))
		{
			string json = File.ReadAllText(path);
			SaveData data = JsonUtility.FromJson<SaveData>(json);

			teamColor = data.TeamColor;
		}
	}

}
[System.Serializable]
class SaveData
{
	public Color TeamColor;
}

