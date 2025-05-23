using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class EggCtrl : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI eggVelocityText;
    [SerializeField] Image hpGage;


    //Move
    Rigidbody rigid;
    private float eggVelocity;
    public float speed = 5f;
    public float horizontalSpeed = 30f;

    //Jump
    public float jumpPower = 5f;
    public bool isGround = false;
    private RaycastHit hit;
    public float jumpCheckDistance = 0.1f;
    private float jumpCool = 1f;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        hp = 100;
        HpTextUpdate();
    }
    private void Update()
    {
        Move();
        VelocityUpdate();
        GroundCheck();
    }
    private void VelocityUpdate()
    {
        eggVelocityText.text = (rigid.velocity.magnitude).ToString("0.0");
    }
    private void Move()
    {
        jumpCool -= Time.deltaTime;
        if (isGround)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                transform.Rotate(new Vector3(0, 0, horizontalSpeed) * Time.deltaTime);

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
                transform.Rotate(new Vector3(0, 0, -horizontalSpeed) * Time.deltaTime);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpCool = 1.0f;
                rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
        
    }

    private void Die()
    {

    }
    private void GetDamage(float _damage)
    {
        hp -= _damage;
        if(hp <1.0f)
        {
            Die();
        }
        HpTextUpdate();
    }
    private void HpTextUpdate()
    {
        hpText.text =Mathf.FloorToInt(hp).ToString();
        hpGage.fillAmount = (hp / 100.0f);
    }
    private void GroundCheck()
    {
        Debug.DrawRay(transform.position, new Vector3(0,-1,0) * jumpCheckDistance, Color.red);
        if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, jumpCheckDistance))
        {
            
            //Jumping
            if(hit.transform == null)
            {
                isGround = false;
            }
            else
            {
                isGround = true;
            }
        }
        else
        {
            isGround = false;
        }
    }
    private void OnCollisionEnter(Collision co)
    {
        if (co.impulse.magnitude >= 10)
        {
            GetDamage(co.impulse.magnitude);
        }
    }

}
