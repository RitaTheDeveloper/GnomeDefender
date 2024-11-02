using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownController : MonoBehaviour
{
    [SerializeField] private Transform[] turretHolders;
    [SerializeField] private GameObject[] turretPrefabs;

    public List<TurretController> Turrets { get; private set; } = new List<TurretController>();

    private void Start()
    {
       // Init();
    }

    public void Init()
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
            TurretController turretController = turret.GetComponent<TurretController>();
            Turrets.Add(turretController);
            turretController.Init(GetComponent<UnitParameters>());
        }
    }

    public void ActivateTurrets()
    {
        foreach (var turret in Turrets)
        {
            turret.Init(GetComponent<UnitParameters>());
        }
    }

}
