using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickToReStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button button = this.GetComponent<Button>();
        button.onClick.AddListener(() => {
            Debug.Log("Clicked.");
            SceneManager.LoadScene("GameScene");
        });
    }
	
	// Update is called once per frame
	void Update () {

    }
}
