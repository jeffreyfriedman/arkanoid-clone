using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: " + name);
		Block.breakableCount = 0;
		SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log("Quit requested.");
		Application.Quit();
	}

	public void LoadNextLevel() {
		Scene scene = SceneManager.GetActiveScene();
		Block.breakableCount = 0;
		SceneManager.LoadScene(scene.buildIndex + 1);
	}

	public void BrickDestroyed() {
		if (Block.breakableCount <= 0) {
			LoadNextLevel();
		}
	}

}
