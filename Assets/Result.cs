using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Result : MonoBehaviour {

    public Canvas myCanvas;
    public GameObject button, button1, RealChara005;
    public Text scoreText;
    public int score, max;

    public AudioClip[] se;
    public AudioSource audioSource;

    private float startTime;
    private int mode;


    // Use this for initialization
    void Start () {
        //myCanvas.gameObject.SetActive(false);
		score=PlayerPrefs.GetInt("SCORE");

        max = 0;
        startTime = Time.time;
        mode = 0;
        audioSource.PlayOneShot(se[0]);
    }
	
	// Update is called once per frame
	void Update () {
        if(mode == 0){
            if (max < score)
            {
                if (Time.time - startTime > 0.05f)
                {
                    max++;
                    string sco = max.ToString();

                    scoreText.text = sco;

                    startTime = Time.time;
                }
            } else
            {
                button.SetActive(true);
                button1.SetActive(true);
                RealChara005.SetActive(true);
                mode = 1;
                audioSource.PlayOneShot(se[1]);
            }
        }
        else if (mode == 1)
        {

        }

        
    }
}
