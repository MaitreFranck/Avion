using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnTriggerEnter(Collider collision)
    {
        Destroy(this.gameObject, 0.5f);
    }
}
