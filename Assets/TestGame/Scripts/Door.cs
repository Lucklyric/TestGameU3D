using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public bool isLeft;
	private float xPosition;


	void Awake(){
		xPosition = transform.position.x;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLeft) {
			if (transform.position.x < xPosition){
				transform.position = new Vector3(xPosition,transform.position.y,transform.position.z);
			}
		}else{
			if (transform.position.x > xPosition){
				transform.position = new Vector3(xPosition,transform.position.y,transform.position.z);
			}
		}
	}

	IEnumerator OnMouseDown()
	{
		//将<strong>物体</strong>由世界坐标系转化为屏幕坐标系    ，由vector3 结构体变量ScreenSpace存储，以用来明确屏幕坐标系Z轴的位置
		Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
		//完成了两个步骤，1由于<strong>鼠标</strong>的坐标系是2维的，需要转化成3维的世界坐标系，2只有三维的情况下才能来计算<strong>鼠标</strong>位置与<strong>物体</strong>的距离，offset即是距离
		Vector3 offset = transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z));
		Quaternion rotation = transform.rotation;
		Debug.Log("down");
		
		//当<strong>鼠标</strong>左键按下时
		while(Input.GetMouseButton(0))
		{
			//得到现在<strong>鼠标</strong>的2维坐标系位置
			Vector3 curScreenSpace =  new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z);   
			//将当前<strong>鼠标</strong>的2维位置转化成三维的位置，再加上<strong>鼠标</strong>的移动量
			Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace)+offset;        
			//CurPosition就是<strong>物体</strong>应该的移动向量赋给transform的position属性     
			transform.position = new Vector3(CurPosition.x,transform.position.y,transform.position.z);
			//这个很主要
			yield return new WaitForFixedUpdate();
		}
	}


}
