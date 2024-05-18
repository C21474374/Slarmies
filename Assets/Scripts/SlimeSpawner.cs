using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{

    public GameObject[] slimes;
    public Transform[] spawnPoints;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    GameObject current_slime;
    public int area = 1;
    public bool can_spawn = true;
    private int max_slimes;
   
    // Start is called before the first frame update
    void Start()
    {
        max_slimes = spawnPoints.Length;
        current_slime = slimes[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(can_spawn)
        {
            for(int i = Random.Range(0, max_slimes);i < spawnPoints.Length;i++)
            {
            Instantiate(current_slime, spawnPoints[i].position, spawnPoints[i].rotation);
                
            }
            can_spawn = false;
        }
    }
}
