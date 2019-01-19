using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuBehaviour : MonoBehaviour {

	Animator cAnimator;


	// Use this for initialization
	void Start () {
		cAnimator = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1") && !cAnimator.GetBool("GameStart"))
        {
            cAnimator.SetBool("GameStart", true);
        }
	}

	public void ChangeScene(string scene){
		SceneManager.LoadScene(scene);
	}
}
