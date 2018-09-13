using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof (SceneController))]
public class GUIController : MonoBehaviour {

    public Text scoreText;
    public Slider healthSlider;
    SceneController scene;

	void Start () {
        scene = GetComponent<SceneController>();
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + scene.score;

        //healthSlider.value = playerHealth / playerhealthMax;
	}
    public void SliderValueChanged(float value)
    {
        print("DERP: " + value);
    }
}
