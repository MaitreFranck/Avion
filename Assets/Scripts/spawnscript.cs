using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour{
    public GameObject enemy;
    public GameObject spawner;
    public int SpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", SpawnRate, SpawnRate) ;
    }

    // Update is called once per frame

    void Spawn()
    {
        Instantiate(
                          enemy,
                          spawner.transform.position,
                          enemy.transform.rotation);
    }
    void Update()
    {
        
    }
}
