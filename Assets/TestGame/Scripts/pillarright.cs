using UnityEngine;
using System.Collections;

public class pillarright : MonoBehaviour {

	public torus mTorus1,mTorus2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		//进入触发器执行的代码
		if (collider.Equals(mTorus1.torusBoxCollider) || collider.Equals(mTorus2.torusBoxCollider)) {
			Debug.Log("chufa");		
		}
	}
}
