using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndLevelControl : MonoBehaviour
{
	
		public GameObject EndLevel1Star;
		public GameObject EndLevel2Star;
		public GameObject EndLevel3Star;
		//public Animator EndScore;
		public Text FinalScore;
		public GameObject EndScoreGO;
		private string scoreF;
		// Use this for initialization
		float time = 0.3f;
		void Start ()
		{
				EndScoreGO.SetActive (false);
				EndLevel1Star.SetActive (false);
				EndLevel2Star.SetActive (false);
				EndLevel3Star.SetActive (false);
		}
	
		// Update is called once per frame
		void Update ()
		{
				scoreF = "" + ScoreManager.score;
		}
		public void ShowStars ()
		{
				StartCoroutine (coShowStar ());
				FinalScore.text = scoreF;
		}

		IEnumerator coShowStar ()
		{
				if (ScoreManager.StarsNumber >= 1) {
						//EndLevel1Star.Play ("StarGain");
						EndLevel1Star.SetActive (true);
						yield return new WaitForSeconds (time);
				}

				

				if (ScoreManager.StarsNumber >= 2) {
						//EndLevel2Star.Play ("StarGain");
						EndLevel2Star.SetActive (true);
						yield return new WaitForSeconds (time);
				}

				
		
				if (ScoreManager.StarsNumber >= 3) {
						//EndLevel3Star.Play ("StarGain");
						EndLevel3Star.SetActive (true);
						yield return new WaitForSeconds (time + time);
				}
				
				EndScoreGO.SetActive (true);
				//EndScore.Play ("EndLevelPopup_Score");
		}


}
