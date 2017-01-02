using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites; 
	public static int breakableCount = 0;
	public GameObject smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start() {
		isBreakable  = (this.tag == "Breakable");
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update() {

	}

	void OnCollisionEnter2D(Collision2D col) {
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1; // infer max hits by number of damage sprites in array
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			SmokeEffect();
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}

	void SmokeEffect() {
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}

	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]) {  // to guard against accidentally omitted sprites
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Block sprite missing.");
		}
	}

	// TODO Remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}

