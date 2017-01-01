using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Quit requested.");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Scene scene = SceneManager.GetActiveScene();
		print ("Scene: " + scene.buildIndex);
		SceneManager.LoadScene(scene.buildIndex + 1);
	}

}
