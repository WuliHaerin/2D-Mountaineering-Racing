using UnityEngine;
using System.Collections;

public class FinishTrigger : MonoBehaviour {

	// Use this for initialization
	public GameObject finishMenu;

	void Start () {
		Debug.Log(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col)
	{

		if (col.CompareTag ("Player")) {
			finishMenu.SetActive (true);
		}

	}
}
