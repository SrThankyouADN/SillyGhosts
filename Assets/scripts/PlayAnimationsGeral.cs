using UnityEngine;
using System.Collections;

public class PlayAnimationsGeral : MonoBehaviour
{
		public GameObject particles;
		// Use this for initialization
		void Start ()
		{
	
		}
		public void PlayParticle ()
		{
				particles.particleSystem.Play ();
		}
		public void PlayStars ()
		{

		}
}
