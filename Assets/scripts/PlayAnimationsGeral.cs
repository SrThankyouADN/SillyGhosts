using UnityEngine;
using System.Collections;

public class PlayAnimationsGeral : MonoBehaviour
{
		public GameObject particles;

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
