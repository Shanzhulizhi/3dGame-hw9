using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbarIMGUI : MonoBehaviour {
    public Slider slider;
    public float health = 0.0f; //初始血条
    public float curhealth;  //结果血条
    public Rect HealthBar;
    public Rect ButtonUp;
    public Rect ButtonDown;

	// Use this for initialization
	void Start () {
        HealthBar = new Rect(400, 40, 200, 20);  //血条区域
        ButtonUp = new Rect(400, 15, 80, 20);   //加血按钮
        ButtonDown = new Rect(490, 15, 80, 20); //减血按钮
        curhealth = health;
	}

    void OnGUI()
    {
        if (GUI.Button(ButtonUp,"HealthUp"))
        {
            curhealth = curhealth + 0.1f > 1.0f ? 1.0f : curhealth + 0.1f;
        }
        if (GUI.Button(ButtonDown, "HealthDown"))
        {
            curhealth = curhealth - 0.1f < 0.0f ? 0.0f : curhealth - 0.1f;
        }
        //插值计算health值，以实现血条值平滑变化
        health = Mathf.Lerp(health, curhealth, 0.05f);
        slider.value = health;
        GUI.HorizontalScrollbar(HealthBar, 0.0f, health, 0.0f, 1.0f);
    }
}

