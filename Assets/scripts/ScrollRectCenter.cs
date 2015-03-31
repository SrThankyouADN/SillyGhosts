using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(ScrollRect))]
public class ScrollRectCenter : MonoBehaviour
{

		public RectTransform centerTarget;
		public GameObject scrollerPanel;
		public Vector2 MainPos;
		public Vector3 LevelsPos;
		public Vector3 MarketPos;
		public float speed = 5f;
		public float SnapSize = 100f;
		public bool mktClicked = false;
		public bool lvlClicked = false;
		public bool mainClicked = false;
		public bool IsDrag = false;
		float time = 0;
		float positionX;
		Vector2 lugar;
		float TelaAtual = 0;
	
		void Awake ()
		{

		//ScrollRect scroller = gameObject.GetComponent<ScrollRect> ();

		}

		void Update ()
		{
				gotoPanel ();
				//print (TelaAtual);
				//print (centerTarget.anchoredPosition.x);
				if (time > 1) {
						if (centerTarget.anchoredPosition.x > (-SnapSize * 2) & centerTarget.anchoredPosition.x < (SnapSize * 2)) {
								TelaAtual = 0;
						}
						if (centerTarget.anchoredPosition.x > (MarketPos.x - SnapSize) & centerTarget.anchoredPosition.x < (MarketPos.x + SnapSize)) {
								TelaAtual = 1;
						}
						if (centerTarget.anchoredPosition.x > (LevelsPos.x - SnapSize) & centerTarget.anchoredPosition.x < (LevelsPos.x + SnapSize)) {
								TelaAtual = 2;
						}
						mktClicked = false;
						lvlClicked = false;
						mainClicked = false;
						time = 0f;
						lugar = MainPos;
				}
		}

		public void isDragin ()
		{
				IsDrag = true;
		}

		public void isNotDragin ()
		{
				IsDrag = false;
		}

		public void SnapPanel ()
		{
				if (IsDrag == true) {
						if (TelaAtual == 0) {
								if (centerTarget.anchoredPosition.x < -SnapSize) {
										//Debug.Log ("Snap Levels!");
										lugar = LevelsPos;	
										lvlClicked = true;
										gotoPanel ();
										
								}
								if (centerTarget.anchoredPosition.x > SnapSize) {
										//Debug.Log ("Snap Market!");
										lugar = MarketPos;	
										mktClicked = true;
										gotoPanel ();
										
								}
								if (centerTarget.anchoredPosition.x > -SnapSize & centerTarget.anchoredPosition.x < SnapSize) {
										//Debug.Log ("Snap Main!");						
										lugar = MainPos;	
										mainClicked = true;
										gotoPanel ();
										
								}
						}
						if (TelaAtual == 1) {
			
								if (centerTarget.anchoredPosition.x > (MarketPos.x - SnapSize)) {
										//Debug.Log ("Snap Market!");
										lugar = MarketPos;	
										mktClicked = true;
										gotoPanel ();										
								}
								if (centerTarget.anchoredPosition.x < (MarketPos.x - SnapSize)) {
										//Debug.Log ("Snap Main!");						
										lugar = MainPos;	
										mainClicked = true;
										gotoPanel ();										
								}

						}
						if (TelaAtual == 2) {
				
								if (centerTarget.anchoredPosition.x < (LevelsPos.x + SnapSize)) {
										//Debug.Log ("Snap levels!");
										lugar = LevelsPos;	
										mktClicked = true;
										gotoPanel ();										
								}
								if (centerTarget.anchoredPosition.x > (LevelsPos.x + SnapSize)) {
										//Debug.Log ("Snap Main!");						
										lugar = MainPos;	
										mainClicked = true;
										gotoPanel ();										
								}
				
						}


			
			
				}//fim de IsDrag
		}
	
		public void ToLevels ()
		{
				lugar = LevelsPos;	
				lvlClicked = true;
				TelaAtual = 2;
		}

		public void ToMarket ()
		{
				lugar = MarketPos;	
				mktClicked = true;
				TelaAtual = 1;
		}
	
		public void ToMain ()
		{
				lugar = MainPos;	
				mainClicked = true;
				TelaAtual = 0;
		}
	
		void gotoPanel ()
		{
				if (lvlClicked == true || mktClicked == true || mainClicked == true) {
						time += Time.deltaTime;
						centerTarget.anchoredPosition = Vector3.Lerp (centerTarget.anchoredPosition, lugar, speed * time);
				}
		}
	
}
