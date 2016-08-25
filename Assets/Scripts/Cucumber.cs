using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cucumber : MonoBehaviour {
	public AudioSource audioSource;
	public AudioClip[] se;


	public int score;
	public GameObject bomb;

	public Sprite boomSprite;
	public Camera _camera;
	public GameObject quakePoint;
	private bool tapFlag;
	private float goalY;
	private Vector3 cameraStartPosition;

	private float quakeTime;

	private SpriteRenderer sr;

	private float startTime;
	private bool flag=false;
	private float timer;
	public Text timerText;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		tapFlag = false;
		quakeTime = 0;
		cameraStartPosition = _camera.transform.position;
		timer = 10.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !tapFlag) {
			
			var pos = _camera.ScreenToWorldPoint(Input.mousePosition + _camera.transform.forward * 10);
			if (pos.y < -0.6f) {
				tapFlag = true;
				goalY = pos.y + (gameObject.GetComponent<SpriteRenderer> ().bounds.size.y / 2);
				pos.y = 50;
				this.transform.position = pos;
			}
		}
		if (tapFlag) {
			if (goalY < this.transform.position.y) {
				this.transform.Translate (0, -1, 0);
				var cuPos = transform.position;
				cuPos.z = quakePoint.transform.position.y * 0.1f;
				this.transform.position = cuPos;

			} else {
				if (sr.sprite != boomSprite) {
					earthquake();
				}
				sr.sprite = boomSprite;
			}
		}
		if (quakeTime > 0) {
			_camera.transform.position = cameraStartPosition + Random.insideUnitSphere * 0.3f;
			quakeTime -= 0.1f;
		} else {
			_camera.transform.position = cameraStartPosition;
		}

		if (flag) {
			if (Time.time - startTime > 3.0f) {
				SceneManager.LoadScene ("ResultScene");
			}
		} else {
			timer -= Time.deltaTime;
			if (timer < 0.0f) {
				PlayerPrefs.SetInt ("SCORE", score);
				SceneManager.LoadScene ("ResultScene");
			} else {
				timerText.text = timer.ToString ("F1");
			}
		}
	}

	void earthquake(){
		int point = 0;
		var pos = quakePoint.transform.position;
		pos.z = pos.y * 0.1f;
		Instantiate(bomb,pos,Quaternion.Euler(-90.0f,0.0f,0.0f));
		quakeTime = 6;
		GameObject[] cs = findCharactor ();
		foreach (GameObject c in cs) {
			float dist = Vector3.Distance(c.transform.position, quakePoint.transform.position);
			if (dist < 3) {
				c.SendMessage ("boom",quakePoint.transform.position);
				point++;
			}
		}
		owari (point);
	}

	void owari(int point){
		score = point;
		Debug.Log (point);
		startTime = Time.time;
		flag = true;
		PlayerPrefs.SetInt ("SCORE", score);
		audioSource.PlayOneShot (se [1]);
	}

	private GameObject[] findCharactor(){
		return GameObject.FindGameObjectsWithTag ("Enemy");
	}

}
