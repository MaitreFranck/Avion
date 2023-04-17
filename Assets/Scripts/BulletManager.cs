using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Transform plane;
    public GameObject bullet;
    public void Shoot()
    {
        GameObject currentBalle;
        currentBalle = Instantiate(bullet, plane.position + new Vector3(0, 0, 1.5f), plane.transform.rotation);
        currentBalle.GetComponent<Rigidbody>().AddForce(0, 0, 300);
    }

    public void ShootAlt()
    {
        GameObject currentBalle;
        currentBalle = Instantiate(bullet, plane.position + new Vector3(), plane.transform.rotation);
    }
}
