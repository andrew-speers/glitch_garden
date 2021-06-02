using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;

    DefenderSpawner spawner;

    private void Start()
    {
        spawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        foreach (DefenderButton db in FindObjectsOfType<DefenderButton>())
            db.GetComponent<SpriteRenderer>().color = new Color32(113, 113, 113, 255);

        GetComponent<SpriteRenderer>().color = Color.white;
        spawner.SetDefender(defenderPrefab);
    }
}
