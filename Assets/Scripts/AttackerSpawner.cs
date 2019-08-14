using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attacker[] attackers;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(!FindObjectOfType<GameTimer>().GetTimerFinished())
        {
            FindObjectOfType<LevelController>().increaseNumberOfAttackers();
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        Attacker attacker = attackers[UnityEngine.Random.Range(0, attackers.Length)];
        Spawn(attacker);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate
            (attacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
