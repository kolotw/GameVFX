using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class spellingAttack : MonoBehaviour
{
    public VisualEffect effect;
    public GameObject fireball;    //火球的VFX Gameobject
    public Transform firePos;       //發射位置
    public Transform target;         //瞄準目標位置

    GameObject fireBallObj;         //產生的火球
    Animator fireBallAnimator;      //人物動畫控制器
    bool isFiring = false;                //是否已產生火球

    // Start is called before the first frame update
    void Start()
    {
        fireBallAnimator = GetComponent<Animator>();    //取得動畫控制器
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            print("KEYPAD_0");
        }


        //this.transform.LookAt(target);                                  //將人物面向目標
        if (Input.GetKeyUp(KeyCode.Space))
        {                //如果 按了一下 空白鍵
            fireBallAnimator.SetTrigger("fire");                      //告訴動畫控制器 fire (trigger)已啟動，播放動畫
        }

    }
    public void firing()
    {      //這是動畫裡的Animation Event (火球移動)
        effect.SendEvent("OnFire");
        isFiring = false;        //火球還沒發射
        fireBallObj = Instantiate(fireball, firePos.position, Quaternion.identity);     //產生火球
        fireBallObj.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);  //設定火球的角度要與人物一致，發射方向才會一致。
        fireBallObj.GetComponent<Rigidbody>().AddForce(transform.forward * 165f);  //火球的移動推力        
        Destroy(fireBallObj, 3f);
    }
    public void ballStaring()
    {      //這是動畫裡的Animation Event (火球產生)
        effect.SendEvent("OnCollect");
        isFiring = true;  //已產生火球，所以不要控制火球的位置了。
    }
    void clearVFX()
    {
        Destroy(fireBallObj);
    }
}