using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class fireBall : MonoBehaviour
{
    public GameObject fireball;    //火球的VFX Gameobject
    public Transform firePos;       //發射位置
    public Transform target;         //瞄準目標位置

    GameObject fireBallObj;         //產生的火球
    Animator fireBallAnimator;      //人物動畫控制器
    bool isFiring = false;                //是否已產生火球

    VisualEffect effect;                    //VFX
    // Start is called before the first frame update
    void Start()
    {
        fireBallAnimator = GetComponent<Animator>();    //取得動畫控制器
        this.transform.LookAt(target);                                 //將人物面向目標
        effect = GameObject.Find("/VFX_Electric").GetComponent<VisualEffect>();
    }

    void Update()
    {
        this.transform.LookAt(target);                                  //將人物面向目標
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {                //如果滑鼠右鍵按了一下
            fireBallAnimator.SetTrigger("fire");                      //告訴動畫控制器 fire (trigger)已啟動，播放動畫

            this.transform.position = new Vector3(0, 0, 0);   //將人物位置歸零(因為動畫會使角色位置偏移)
            this.transform.rotation = Quaternion.Euler(0, 0, 0); //將人物角度歸零(因為動畫會使角色位置偏移)
        }
        if (isFiring)
        {                                                             //如果已產生火球
            if (fireBallObj != null)
            {                                          //如果火球還沒消失
                fireBallObj.transform.position = firePos.transform.position;  //火球的位置要在發射位置(就是手的附近)
            }
        }
    }
    public void firing()
    {      //這是動畫裡的Animation Event (火球移動)
        
        if (effect != null) {
            effect.SendEvent("OnStart");
            Invoke("stopVFX", 1f);
        }
        isFiring = false;        //火球還沒發射

        fireBallObj.GetComponent<Rigidbody>().AddForce(transform.forward * 165f);  //火球的移動推力
        Destroy(fireBallObj, 3f);   //3秒後刪除
    }
    public void ballStaring()
    {      //這是動畫裡的Animation Event (火球產生)
        fireBallObj = Instantiate(fireball, firePos.position, Quaternion.identity);     //產生火球
        fireBallObj.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);  //設定火球的角度要與人物一致，發射方向才會一致。
        isFiring = true;  //已產生火球，所以不要控制火球的位置了。

        VisualEffect effect = GameObject.Find("/VFX_Electric").GetComponent<VisualEffect>();
        if (effect != null)
        {
            effect.SendEvent("OnStop");
        }
    }
    void stopVFX() {
        effect.SendEvent("OnStop");
    }
}