using UnityEngine;
using System.Collections;

public class EndLevelControl : MonoBehaviour
{
	
		public Animator EndLevel1Star;
		public Animator EndLevel2Star;
		public Animator EndLevel3Star;
		// Use this for initialization
		float time = 0.3f;
		void Start ()
		{	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		public void ShowStars ()
		{
				StartCoroutine (coShowStar ());
		}

		IEnumerator coShowStar ()
		{
				if (ScoreManager.StarsNumber >= 1) {
						EndLevel1Star.Play ("StarGain");
				}

				yield return new WaitForSeconds (time);

				if (ScoreManager.StarsNumber >= 2) {
						EndLevel2Star.Play ("StarGain");
				}

				yield return new WaitForSeconds (time);
		
				if (ScoreManager.StarsNumber >= 3) {
						EndLevel3Star.Play ("StarGain");
				}
		}

}
