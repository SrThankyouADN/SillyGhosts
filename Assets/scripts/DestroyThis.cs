using UnityEngine;
using System.Collections;

public class DestroyThis: MonoBehaviour
{
	public GameObject DestroyTarget;

	void Destruir (){
		Destroy (DestroyTarget);
	}
}