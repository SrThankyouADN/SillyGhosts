using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy_Controller : MonoBehaviour
{

		public float maximumSpeed;
		public int Health = 10;
		public int Damage = 5;
		public int ScoreToAdd;
		public Animator ExplodeAnim;
		public GameObject Raio;
		public GameObject HitScore_Prefab;
		private SpriteRenderer RaioS;
		private float explodeRadius = 1;
		private int HalfHealth;
		public bool CanExplode; // only for debug

		static Vector3 center = new Vector3 (0, 0, 0);
		//private int count = 1;
		//static Vector3 TheCenter = new Vector3 (0, 0, 0);
		
		
		GameObject UiReceiver;
		//private int CurrMultipler = 0;

		void Start ()
		{
				UiReceiver = GameObject.FindWithTag ("UiReceiver"); 	
				RaioS = Raio.GetComponent<SpriteRenderer> ();
				//explodeRadius = Raio.transform.localScale.x;
				HalfHealth = Health / 2;
				CanExplode = false;
				
		}

		void FixedUpdate ()
		{

				float speed = Vector3.Magnitude (rigidbody2D.velocity);  // test current object speed
		
				if (speed > maximumSpeed) {
						float brakeSpeed = speed - maximumSpeed;  // calculate the speed decrease
						Vector3 normalisedVelocity = rigidbody2D.velocity.normalized;
						Vector3 brakeVelocity = normalisedVelocity * brakeSpeed;  // make the brake Vector3 value
						rigidbody2D.AddForce (-brakeVelocity);  // apply opposing brake force
				}

		}

		void OnMouseDrag ()
		{
				StartCoroutine (MouseDrag ());
				//Raio.SetActive(true);
				RaioS.enabled = true;
		}

		void OnMouseUp ()
		{
				//Raio.SetActive (false);
				RaioS.enabled = false;
		}

		void OnMouseExit ()
		{
				//CanExplode = true;
				//Raio.SetActive (false);
				RaioS.enabled = false;
		}

		void OnMouseOver ()
		{
				//Raio.SetActive(true);
				RaioS.enabled = true;
				if (Input.GetMouseButtonDown (0)) {
						CanExplode = true;
				}
				StartCoroutine ("wait");
				if (CanExplode) {

						if (Input.GetMouseButtonUp (0)) {
								
								ExplodeAnim.Play ("Ghost_explode");
								PopMulti (ExplodeAnim.transform.position);
								
			
						}
			
				}
		}

		IEnumerator MouseDrag ()
		{
				yield return new WaitForSeconds (0.1f);
				CanExplode = false;
		}
		//IEnumerator MouseUp(){
		//	yield return new WaitForSeconds(0.001f);
		//	CanExplode = true;
		//	}
		IEnumerator wait ()
		{
				yield return new WaitForSeconds (0.001f);
		}

		void Destroy ()
		{
				
				Collider2D[] colliders = Physics2D.OverlapCircleAll (transform.position, explodeRadius);
				foreach (Collider2D col in colliders) {
						//TheCenter = center / count;
						
					
						if (col.tag == "GhostEnemy") {
								//Destroy(col.collider2D.gameObject);
								center = col.transform.position;							
								col.collider2D.gameObject.SendMessage ("ApplyDamage", Damage);						
						}
						
				}
				SetMultiText.MultiTxt = SetMultiText.MultiTxt + 1;
				ScoreManager.ComboTimerP = ScoreManager.SetComboTimer;
				UiReceiver.GetComponent<ScoreManager> ().AddScore (ScoreToAdd, SetMultiText.MultiTxt);
				//destroi todos os GO dentro do raio
				Destroy (this.gameObject);
				//aumenta a contagem de inimigos mortos
				ScoreManager.EnemyCountDead++;

		}

		void PopMulti (Vector3 posicao)//Popup de Multiple HitScore
		{
				if (SetMultiText.MultiTxt >= 1) { 						
						//TheCenter = center / count;
						Instantiate (HitScore_Prefab, posicao, new Quaternion (0, 0, 0, 0));
				}
		}

		IEnumerator ApplyDamage (int Damage)
		{
				Health = Health - Damage;
				yield return new WaitForSeconds (0.05f);
				if (Health <= 0) {
						yield return new WaitForSeconds (0.4f);
						ExplodeAnim.Play ("Ghost_explode");

						PopMulti (ExplodeAnim.transform.position);
				}
				//inimigo ferido
				if (Health <= HalfHealth & Health > 0) { 
						this.gameObject.renderer.material.color = Color.magenta;
				}
		}
}


