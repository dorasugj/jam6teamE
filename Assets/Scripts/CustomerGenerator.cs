using UnityEngine;
using System.Collections;

public class CustomerGenerator : MonoBehaviour {
	public GameObject[] customer;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 100; i++) {
			var kind = Random.Range (0, customer.Length);

			var x=Random.Range(9.0f,15.0f);
			if (Random.Range (0, 2) == 0)x *= -1;
			var y=Random.Range(-0.6f,-3.5f);
			var pos = new Vector3 (x , y, 0.0f);
			var rot = Quaternion.identity;
			Instantiate (customer [kind], pos, rot);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
