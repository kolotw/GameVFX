using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class fireBall : MonoBehaviour
{
    public GameObject fireball;    //���y��VFX Gameobject
    public Transform firePos;       //�o�g��m
    public Transform target;         //�˷ǥؼЦ�m

    GameObject fireBallObj;         //���ͪ����y
    Animator fireBallAnimator;      //�H���ʵe���
    bool isFiring = false;                //�O�_�w���ͤ��y

    VisualEffect effect;                    //VFX
    // Start is called before the first frame update
    void Start()
    {
        fireBallAnimator = GetComponent<Animator>();    //���o�ʵe���
        this.transform.LookAt(target);                                 //�N�H�����V�ؼ�
        effect = GameObject.Find("/VFX_Electric").GetComponent<VisualEffect>();
    }

    void Update()
    {
        this.transform.LookAt(target);                                  //�N�H�����V�ؼ�
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {                //�p�G�ƹ��k����F�@�U
            fireBallAnimator.SetTrigger("fire");                      //�i�D�ʵe��� fire (trigger)�w�ҰʡA����ʵe

            this.transform.position = new Vector3(0, 0, 0);   //�N�H����m�k�s(�]���ʵe�|�Ϩ����m����)
            this.transform.rotation = Quaternion.Euler(0, 0, 0); //�N�H�������k�s(�]���ʵe�|�Ϩ����m����)
        }
        if (isFiring)
        {                                                             //�p�G�w���ͤ��y
            if (fireBallObj != null)
            {                                          //�p�G���y�٨S����
                fireBallObj.transform.position = firePos.transform.position;  //���y����m�n�b�o�g��m(�N�O�⪺����)
            }
        }
    }
    public void firing()
    {      //�o�O�ʵe�̪�Animation Event (���y����)
        
        if (effect != null) {
            effect.SendEvent("OnStart");
            Invoke("stopVFX", 1f);
        }
        isFiring = false;        //���y�٨S�o�g

        fireBallObj.GetComponent<Rigidbody>().AddForce(transform.forward * 165f);  //���y�����ʱ��O
        Destroy(fireBallObj, 3f);   //3���R��
    }
    public void ballStaring()
    {      //�o�O�ʵe�̪�Animation Event (���y����)
        fireBallObj = Instantiate(fireball, firePos.position, Quaternion.identity);     //���ͤ��y
        fireBallObj.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.eulerAngles.z);  //�]�w���y�����׭n�P�H���@�P�A�o�g��V�~�|�@�P�C
        isFiring = true;  //�w���ͤ��y�A�ҥH���n������y����m�F�C

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