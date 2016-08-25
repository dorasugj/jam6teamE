using UnityEngine;
using System.Collections;

public class Charactor : MonoBehaviour {
	public Vector3 vec;

	void Start () {
		var speed = Random.Range (1.0f, 3.0f);
		if (transform.position.x<0.0f) {
			vec.x = speed;
			transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
		} else {
			vec.x = -speed;
			transform.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);
		}
	}

	void Update () {
		var pos = transform.position;
		pos.z = (pos.y - (gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2)) * 0.1f;

		transform.position = pos + vec * Time.deltaTime;
	}

	void boom(Vector3 pos){
		if (transform.position.x > pos.x)
			vec.x = Random.Range (1.0f, 3.0f);
		else vec.x = Random.Range (-1.0f, -3.0f);

		vec.y = Random.Range (1.0f, 3.0f);
		vec = vec.normalized*30.0f;
	}
}
