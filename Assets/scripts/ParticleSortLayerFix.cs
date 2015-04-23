using UnityEngine;
using System.Collections;

public class ParticleSortLayerFix : MonoBehaviour
{

		public string LayerName = "Player";
		


		// Use this for initialization
		void Start ()
		{
				particleSystem.renderer.sortingLayerName = LayerName;
				particleSystem.renderer.sortingOrder = -1;
		}
	
		// Update is called once per frame
		
}
