using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WIN : MonoBehaviour
{
    Animator anim; //動畫控制器
    public VisualEffect winVFX;  //Unity VFX graph (LEVEL UP)
    public VisualEffect slashVFX;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();        
        //winVFX.GetComponent<VisualEffect>().enabled = false;
        slashVFX.GetComponent<VisualEffect>().enabled = false;
        //InvokeRepeating("run", 3f, 10f);
    }
    void run()
    {
        winVFX.GetComponent<VisualEffect>().enabled = true;
        anim.SetTrigger("LevelUp");
        winVFX.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            //anim.SetTrigger("LevelUp");
            //winVFX.GetComponent<VisualEffect>().enabled = true;
            
            
            anim.SetTrigger("Attack");


            //Invoke("playLevelUp", 0.5f);
        }
    }
    void AttackAnim() {
        slashVFX.GetComponent<VisualEffect>().enabled = true;
        slashVFX.Play();
    }
    void playLevelUp() 
    {        
        winVFX.Play();
    }
    void LevelUpEvent() {
        winVFX.SendEvent("OnStart");
    }

}