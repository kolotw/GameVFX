using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class spellingAttack : MonoBehaviour
{
    public VisualEffect effect;
    public GameObject fireball;    //���y��VFX Gameobject
    public Transform firePos;       //�o�g��m
    public Transform target;         //�˷ǥؼЦ�m

    GameObject fireBallObj;         //���ͪ����y
    Animator fireBallAnimator;      //�H���ʵe���
    bool isFiring = false;                //�O�_�w���ͤ��y

    // Start is called before the first frame update
    void Start()
    {
        fireBallAnimator = GetComponent<Animator>();    //���o�ʵe���
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)) {
            print("KEYPAD_0");
        }


        //this.transform.LookAt(target);                                  //�N�H�����V�ؼ�
        if (Input.GetKeyUp(KeyCode.Space))
        {                //�p�G ���F�@�U �ť���
            fireBallAnimator.SetTrigger("fire");                      //�i�D�ʵe��� fire (trigger)�w�ҰʡA����ʵe
        }

    }
    public void firing()
    {      //�o�O�ʵe�̪�Animation Event (���y����)
        effect.SendEvent("OnFire");
        isFiring = false;        //���y�٨S�o�g
        fireBallObj = Instantiate(fireball, firePos.position, Quaternion.identity);     //���ͤ��y
        fireBallObj.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);  //�]�w���y�����׭n�P�H���@�P�A�o�g��V�~�|�@�P�C
        fireBallObj.GetComponent<Rigidbody>().AddForce(transform.forward * 165f);  //���y�����ʱ��O        
        Destroy(fireBallObj, 3f);
    }
    public void ballStaring()
    {      //�o�O�ʵe�̪�Animation Event (���y����)
        effect.SendEvent("OnCollect");
        isFiring = true;  //�w���ͤ��y�A�ҥH���n������y����m�F�C
    }
    void clearVFX()
    {
        Destroy(fireBallObj);
    }
}