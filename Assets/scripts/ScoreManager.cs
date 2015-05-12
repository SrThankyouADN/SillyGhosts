using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

		public GameObject ScoreGo; // GO que contem o texto de Score
		private Text scoreText; // Texto de Score
		public static int score; // Valor de Score
		public GameObject Spawner;//o modulo de spawn de inimigos
		public GameObject GhostNum; // o Gobject que contem o texto de Numero de Inimigos
		private Text Gnum; // texto Numero de inimigos
		public Slider sliderScore; // Slider do Score
		public float MaxScore; // Score maximo da fase
		public float OneStarScore; // Score necessario para uma estrela
		public GameObject OneStar;
		public float TwoStarScore ;// Score necessario para duas estrelas
		public GameObject TwoStar;
		public float TreeStarScore; // Score necessario para tres estrelas
		public GameObject TreeStar;

		public Slider sliderMulti; // Slider do tempo de combo
		public float ComboTimer; // tempo de combo
		private int newScoreValue;
		public static int StarsNumber = 0;


		private Text text;

		static float EnemyNumber;
		private Text Gdeath;
		static float EnemyTotal;
		static float EnemyRestantes;
		public static float EnemyCountDead = 0;
		public static Vector3 MiddlePosition;
		//public GameObject MiddlePostionGO;
		public static float ComboTimerP; //valor interno do tempo de combo
		public static float SetComboTimer; // parametro para ser acessado por outro script

		//endLevelPopPup
	
		public GameObject EndLevelPopup;
		

		void Start ()
		{
				score = 0;
				scoreText = ScoreGo.GetComponent<Text> ();
				UpdateScore ();

				Gnum = GhostNum.GetComponent<Text> ();
		
				//Configurar o tempo de combo
				ComboTimerP = ComboTimer;
				SetComboTimer = ComboTimer;
				sliderMulti.minValue = 0;
				sliderMulti.maxValue = SetComboTimer;
				sliderScore.minValue = 0;
				sliderScore.maxValue = MaxScore;

				OneStar.renderer.material.color = new Color (0, 0, 0, .10f);
				TwoStar.renderer.material.color = new Color (0, 0, 0, .10f);
				TreeStar.renderer.material.color = new Color (0, 0, 0, .10f);
				EnemyCountDead = 0;
				StarsNumber = 0;
				EndLevelPopup.SetActive (false);
				
		
		}
		public void AddScore (int toAdd, int Mtxt)
		{

				// toAdd = score do inimigo ex. 10;
				// Mtxt = numero do combo atual ex. 2, 5 ou 10;

				newScoreValue = toAdd + 1 + (toAdd * ((Mtxt + 1) / 5));

				score += newScoreValue;
				UpdateScore ();
		}
		void UpdateScore ()
		{
				scoreText.text = "Score: " + score;
		}
		void Update ()
		{
				EnemyNumber = Spawner.GetComponent<SpawnScript> ().EnemyCurrNum;
				EnemyTotal = Spawner.GetComponent<SpawnScript> ().EnemyNum;
				EnemyRestantes = EnemyTotal - EnemyNumber;
				Gnum.text = "x" + EnemyRestantes;
				sliderMulti.value = ComboTimerP;
				//sliderScore.value = score;
				
				sliderScore.value = Mathf.Lerp (sliderScore.value, score, (Time.fixedDeltaTime * 0.5f));
				SetStars ();
				//print (EnemyCountDead);
				if (EnemyCountDead == EnemyTotal) {
						LevelFinished ();
				}

		}
		void FixedUpdate ()
		{
				if (ComboTimerP > 0) {
						ComboTimerP -= Time.deltaTime;
				} else {
						SetMultiText.MultiTxt = 0;
						ComboTimerP = SetComboTimer;		
				}
		}

		void SetStars ()// calculo da quantidade de estrelas
		{
				if (score >= OneStarScore) {
						StarsNumber = 1;
						OneStar.renderer.material.color = new Color (1, 1, 1, 1);
				}
				if (score >= TwoStarScore) {
						TwoStar.renderer.material.color = new Color (1, 1, 1, 1);
						StarsNumber = 2;
		
				}
				if (score >= TreeStarScore) {
						StarsNumber = 3;
						TreeStar.renderer.material.color = new Color (1, 1, 1, 1);
				}
		}
		public void LevelFinished ()
		{
				StartCoroutine (coShowStar ());
		}
	
		IEnumerator coShowStar ()
		{
				yield return new WaitForSeconds (1f);		
				//Debug.Log ("FINISHED!!");
				EndLevelPopup.SetActive (true);
				
		}		

}
