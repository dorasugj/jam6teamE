using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleTouch : MonoBehaviour {
    
    //public float speed = 0.1F;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            //// Move object across XY plane
            //transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
            //Debug.LogError("Update: ");

            SceneManager.LoadScene("GameScene");
        }
    }

}
