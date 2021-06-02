using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float minSpawnDelay = 1f, maxSpawnDelay = 5f, yOffset = 0.3f;    
    [SerializeField] Attacker[] attackers = null;
    //bool spawn = true;

    GameState state;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        state = FindObjectOfType<GameState>();

        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + yOffset);
        while (state.isSpawning())
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            Attacker attacker = Instantiate(attackers[Random.Range(0, attackers.Length)], spawnPos, Quaternion.identity) as Attacker;
            attacker.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
