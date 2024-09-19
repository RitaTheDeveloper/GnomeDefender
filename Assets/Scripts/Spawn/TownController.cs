using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    [SerializeField] private Transform[] turretHolders;
    [SerializeField] private GameObject[] turretPrefabs;

    private void Start()
    {
        CreateTurrets();
    }

    private void CreateTurrets()
    {
        foreach (var holder in turretHolders)
        {
            int randIndex = Random.Range(0, turretPrefabs.Length);
            GameObject turret = Instantiate(turretPrefabs[randIndex], holder.position, holder.rotation);
            turret.transform.parent = holder;

        }
    }
}
