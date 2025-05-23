using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShereForceTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision co)
    {
        Debug.Log(co.impulse.magnitude);
    }
}
