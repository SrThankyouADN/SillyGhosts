using UnityEngine;
using System.Collections;

public class LoadLevelScript : MonoBehaviour {
	
	public void loadLevel (string ToLoad) {
		Application.LoadLevel (ToLoad);
		}
}
