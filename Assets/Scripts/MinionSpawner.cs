using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    public GameObject[] minions;
    public Transform[] points;
    public static Transform[] spawnPoints;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    GameObject current_minion;
    public int area = 1;
    public bool can_spawn = true;
    public static int max_minions;
   
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = points;
        max_minions = spawnPoints.Length;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(can_spawn)
        {
            for(int  i = Random.Range(0, max_minions);i < spawnPoints.Length;i++)
            {
            current_minion = minions[i];
            Instantiate(current_minion, spawnPoints[i].position, spawnPoints[i].rotation);
            
                
            }
            can_spawn = false;
        }
    }
}
