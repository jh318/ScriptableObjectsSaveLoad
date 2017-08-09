using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SaveManager : MonoBehaviour {

	[System.Serializable]
	public class SaveState{
		public string sceneName;
		public Vector3 playerPos;
		public float playerHealth;
	}

	public static void Save(){
		SaveState saveState = new SaveState();

		saveState.sceneName = SceneManager.GetActiveScene().name;

		saveState.playerPos = Vector3.zero;
		saveState.playerHealth = 3;

		string path = Path.Combine(Application.persistentDataPath, "save.json");
		string json = JsonUtility.ToJson(saveState);

		File.WriteAllText(path, json);
	}

	public static void Load(){
		string path = Path.Combine(Application.persistentDataPath, "save.json");
		string json = File.ReadAllText(path);
		SaveState saveState = JsonUtility.FromJson<SaveState>(json);

		SceneManager.LoadScene(saveState.sceneName);
		Vector3 playerPos = saveState.playerPos;
		float health = saveState.playerHealth;
	}
}
