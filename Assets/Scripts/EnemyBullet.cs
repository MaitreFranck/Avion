using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float BulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * BulletSpeed * Time.deltaTime);
        if (transform.position.z == -4)
        {
            Destroy(gameObject);
        }
    }
}
