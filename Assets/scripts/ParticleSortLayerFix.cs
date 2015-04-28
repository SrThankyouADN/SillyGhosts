using UnityEngine;
using System.Collections;

public class ParticleSortLayerFix : MonoBehaviour
{

	public string SortingLayerName = "Player";
	public int OrderInLayer = 0;



	// Use this for initialization
	void Start ()
	{
		particleSystem.renderer.sortingLayerName = SortingLayerName;
		particleSystem.renderer.sortingOrder = OrderInLayer;
	}
	
	// Update is called once per frame
		
}
