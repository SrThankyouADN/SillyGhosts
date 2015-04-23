using UnityEngine;
using System.Collections;

public class ParticleControl : MonoBehaviour
{
		public GameObject particles;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		public void PlayParticle ()
		{
				particles.particleSystem.Play ();
		}

}
