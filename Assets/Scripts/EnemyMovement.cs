using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float EnemySpeed;
    public int EnemyHitPoints;
    private int EnemyType;
    public float frequency;
    public float magnitude;
    private Vector3 axis;
    private Vector3 pos;
    public float EnemyShotSpeed;
    public GameObject EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Debug.Log(this.gameObject);
        pos = transform.position;
        axis = transform.right;
        EnemyType = Random.Range(1, 4);
        //if (EnemyType == 2 || EnemyType == 4)
            
        InvokeRepeating("EnemyShot", EnemyShotSpeed, EnemyShotSpeed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyType == 1 || (EnemyType == 4))
        {
            transform.Translate(Vector3.down * EnemySpeed * Time.deltaTime);
        }

        if (EnemyType == 2 || EnemyType == 3)
        {
            pos -= transform.up * Time.deltaTime * EnemySpeed;
            transform.position = pos + axis * Mathf.Sin(Time.time * frequency) * magnitude;
        }

        if (EnemyHitPoints == 0)
        {
            Destroy(gameObject);
        }

        if (transform.position.z == -4)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            EnemyHitPoints -= 1;
        }

    }

    void EnemyShot()
    {
        Instantiate(
                  EnemyBullet,
                  transform.position,
                  EnemyBullet.transform.rotation);
    }

}