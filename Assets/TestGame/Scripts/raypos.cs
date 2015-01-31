using UnityEngine;
using System.Collections;

public class raypos: MonoBehaviour {
	private Ray ray;
	private RaycastHit[] hits;//用来存储碰撞的物体
	private RaycastHit hit;
	public torus ball;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);//射线目标点位置
		Debug.DrawRay(Camera.main.transform.position,ray.direction*10,Color.green);
		hits = Physics.RaycastAll(Camera.main.transform.position,ray.direction,10,50);//返回布尔类型，当光线投射与任何碰撞器交叉时为真，否则为假
		//最后一个参数的意义：只选定Layermask层内的碰撞器，其它层内碰撞器忽略。即在50范围内
		for (int i = 0; i < hits.Length; i++) {

			hit = hits[1];
			if (hit.collider.tag == "screen") {//如果鼠标移到小球外，即屏幕上
				ball.transform.position = hit.point;//将射线射到屏幕上的点的坐标赋给球
			}
		}
	}
}
