using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text scoreText;
	public Text winText;

	private Rigidbody rb;
	private int score;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		score = 0;
		updateScoreText ();
		winText.text = "";
	}

    void Update()
    {
  		
    }

    void FixedUpdate()
    {
		// move with user input
		Vector3 movement = new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical"));
		rb.AddForce (movement * speed);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp")) 
		{
			other.gameObject.SetActive (false);
			score++;
			updateScoreText ();
		}
	}

	void updateScoreText()
	{
		scoreText.text = "Score: " + score;
		if (score >= 8)
			winText.text = "You've Won!";
	}

}
