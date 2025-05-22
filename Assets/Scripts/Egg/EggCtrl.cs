using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class EggCtrl : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] TextMeshProUGUI eggVelocityText;

    
    Rigidbody rigid; 
    private float eggVelocity;
    public float speed = 5f;
    public float horizontalSpeed = 30f;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Move();
        VelocityUpdate(); 

    }
    private void VelocityUpdate()
    {
        Debug.Log(rigid.velocity.magnitude);
        eggVelocityText.text = eggVelocity.ToString();
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.Rotate(new Vector3(0, 0, horizontalSpeed) * Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.Rotate(new Vector3(0, 0, -horizontalSpeed) * Time.deltaTime);
        }
    }

}
