using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class moveCamera : MonoBehaviour
{
		public GameObject MainCamera;    //reference for MainMenupanel
		public Animator mainMenuAnimator;   //Animator reference
		String curr; // painel atual

		public void ToLevels ()
		{
				mainMenuAnimator.Play ("cameraToLevels");
				curr = "levels";
		}
		public void ToMarket ()
		{
				mainMenuAnimator.Play ("cameraToMarket");
				curr = "market";
		}

		public void ToPrincipal ()
		{
				if (curr == "levels") {
						mainMenuAnimator.Play ("cameraFromLevels");	
				}
				if (curr == "market") {
						mainMenuAnimator.Play ("cameraFromMarket");	
				}
		}
}

//old snippets
//mainMenuAnimator.SetBool("voltar", false);
