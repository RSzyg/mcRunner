using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdaptation : MonoBehaviour {
	public float PreSetHeight = 19.2f;
	public float PreSetWidth = 10.8f;
	//宽高比
	public float AspectRatio;
	//屏幕 高度
	public float ScreenHeight;
	//屏幕 宽度
	public float ScreenWidth;
	//摄像机实际宽度
	public float CameraWidth;
	//摄像机实际高度
	public float CameraHeight;

	// Use this for initialization
	void Start () {
		ScreenHeight = Screen.height;
		ScreenWidth = Screen.width;
	
		//获取正交视图大小
		float orthographicSize = GetComponent<Camera> ().orthographicSize;

		//计算宽高比
		AspectRatio = ScreenWidth / ScreenHeight;

		//计算摄像机 高度- 摄像机Size＊2
		CameraHeight = orthographicSize*2;
		//计算摄像机 宽度- 摄像机Size＊2*宽高比（摄像机高度＊宽高比）
		CameraWidth = orthographicSize * 2 * AspectRatio;

			
		if (CameraWidth < PreSetWidth) {
			orthographicSize = PreSetWidth / (2 * AspectRatio);
			GetComponent<Camera> ().orthographicSize = orthographicSize;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
