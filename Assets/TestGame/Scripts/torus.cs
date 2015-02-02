using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class torus : MonoBehaviour
{
		private Vector3 offset, screenSpace;
		private float lowerY;
		private Rigidbody _rigidbody;
		public GameObject _touchTrigger;
		private bool touching;
		/// <summary>
		/// cache reference to the SphereCollider 
		/// </summary>
		private BoxCollider _boxCollider;

		void Awake ()
		{
				_rigidbody = GetComponent<Rigidbody> (); 
				_boxCollider = GetComponent<BoxCollider> ();
				lowerY = transform.position.y;
				Input.multiTouchEnabled = true;
				touching = false;
		}

		public Rigidbody torusRigidBody {
				get {
						return _rigidbody;	
				}
		}
	
		public BoxCollider torusBoxCollider {
				get {
						return _boxCollider; 	
				}
		}


		// Use this for initialization
		void Start ()
		{
				//touchTriggerOffset = transform.position - _touchTrigger.transform.position;
		}
	
		// Update is called once per frame
		void Update ()
		{
				bool isTouching = false;
				foreach (Touch curTouch in Input.touches) {
						Ray ray = Camera.main.ScreenPointToRay (curTouch.position);
						RaycastHit hit;
						if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
								if (hit.collider == this._touchTrigger.collider) {
										isTouching = true;
										if (curTouch.phase == TouchPhase.Began && this.touching == false) {
												screenSpace = Camera.main.WorldToScreenPoint (this.transform.position);//将世界坐标点转为屏幕坐标点
												offset = this.transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (curTouch.position.x, curTouch.position.y, screenSpace.z));
										}
										//if (curTouch.phase == TouchPhase.Moved) {
										//var cameraTransform = Camera.main.transform.InverseTransformPoint (0, 0, 0);
										//object.transform.position = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, cameraTransform.z - 0.5));
										Vector3 curScreenSpace = new Vector3 (curTouch.position.x, curTouch.position.y, screenSpace.z);//获得初点的屏幕坐标点
										Vector3 curPosition = Camera.main.ScreenToWorldPoint (curScreenSpace) + offset;//换算出目标点的世界坐标						
										transform.position = new Vector3 (curPosition.x, curPosition.y, transform.position.z);
										//}
										break;
								}
								
						}
						
				}

				if (isTouching) {
						this.rigidbody.useGravity = false;	
						this.touching = true;
				} else {
						this.rigidbody.useGravity = true;
						this.touching = false;
				}
		}

//	IEnumerator OnMouseDown()
//	{
//		//将<strong>物体</strong>由世界坐标系转化为屏幕坐标系    ，由vector3 结构体变量ScreenSpace存储，以用来明确屏幕坐标系Z轴的位置
//		Vector3 ScreenSpace = Camera.main.WorldToScreenPoint(transform.position);
//		//完成了两个步骤，1由于<strong>鼠标</strong>的坐标系是2维的，需要转化成3维的世界坐标系，2只有三维的情况下才能来计算<strong>鼠标</strong>位置与<strong>物体</strong>的距离，offset即是距离
//		Vector3 offset = transform.position-Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z));
//		Quaternion rotation = transform.rotation;
//		Debug.Log("down");
//		
//		//当<strong>鼠标</strong>左键按下时
//		while(Input.GetMouseButton(0))
//		{
//			//得到现在<strong>鼠标</strong>的2维坐标系位置
//			Vector3 curScreenSpace =  new Vector3(Input.mousePosition.x,Input.mousePosition.y,ScreenSpace.z);   
//			//将当前<strong>鼠标</strong>的2维位置转化成三维的位置，再加上<strong>鼠标</strong>的移动量
//			Vector3 CurPosition = Camera.main.ScreenToWorldPoint(curScreenSpace)+offset;        
//			//CurPosition就是<strong>物体</strong>应该的移动向量赋给transform的position属性     
//			transform.position = CurPosition;
//			transform.rotation = rotation;
//			//这个很主要
//			yield return new WaitForFixedUpdate();
//		}
//	}
}
