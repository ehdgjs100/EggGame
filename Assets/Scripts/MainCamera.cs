using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject camTargetGO;

    public float camPosX;
    public float camPosY;
    public float camPosZ;


    private void Update()
    {
        CamPosUpdate();
        //this.transform.rotation = Quaternion.Euler(0,0,0);
    }
    private void CamPosUpdate()
    {
        this.transform.position = new Vector3(camTargetGO.transform.position.x + camPosX,
            camTargetGO.transform.position.y + camPosY,
            camTargetGO.transform.position.z + camPosZ);
    }
}
