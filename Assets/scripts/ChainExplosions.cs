using UnityEngine;
using System.Collections;

public class ChainExplosions : MonoBehaviour {

	public GameObject RedArea;



	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Enter");
		RedArea.gameObject.renderer.material.color = Color.red;

	}
	
		void OnTriggerExit2D(Collider2D other) {
		Debug.Log ("Exit");
		RedArea.gameObject.renderer.material.color = Color.white;
	}

	

		
}