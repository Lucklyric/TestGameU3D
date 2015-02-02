using UnityEngine;
using System.Collections;

public class GameController: MonoBehaviour
{


		private static GameController _instance = null;
	
		public static GameController SharedInstance {
				get {
						if (_instance == null) {
								_instance = GameObject.FindObjectOfType (typeof(GameController)) as GameController;
						}
			
						return _instance;
				}
		}
	
		void Awake ()
		{      
				_instance = this; 
		}


		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void BackToHomePage ()
		{
				Application.LoadLevel (0);
		}

		public void OnRing()
		{
				Debug.Log("onRing");
		}
}
