using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetMultiText : MonoBehaviour
{

	public Text txt;
	public static int MultiTxt;
	public Text PopText;
	//testre
	
		
	// Use this for initialization
	void Start ()
	{
		//txt = gameObject.GetComponent<Text> (); 
		txt.text = "" + MultiTxt; 
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		txt.text = "" + MultiTxt; 
				
	}
	void PopCurrText ()
	{
		PopText.text = "" + (MultiTxt + 1);
	}
}
