using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownGenerator : MonoBehaviour
{
    [SerializeField] private TownController[] _townPrefabList;
    [SerializeField] private int _numberOfTownProposed = 3;
    [SerializeField] private Transform[] _townsPlace;
    [SerializeField] private Transform _container;
    public TownController SelectedTown { get; private set; }

    List<TownController> listOfTowns = new List<TownController>();

    private void Start()
    {
        DestroyAllTownsForSelection();
        GetListTownProposed();
    }

    public List<TownController> GetListTownProposed()
    {
        listOfTowns = new List<TownController>();

        for (int i = 0; i < _numberOfTownProposed; i++)
        {
            int randIndex = Random.Range(0, _townPrefabList.Length-1);
            var town = Instantiate(_townPrefabList[randIndex], _townsPlace[i]);
            town.transform.parent = _container;
            listOfTowns.Add(town);
            town.Init();
        }

        return listOfTowns;
    }

    public void SetTown(int index)
    {
        SelectedTown = listOfTowns[index];
    }

    public TownController GetSelectedTown()
    {
        TownController town = SelectedTown;
        
        return town;
    }

    public void DestroyAllTownsForSelection()
    {
        foreach (var go in listOfTowns)
        {
            Destroy(go.gameObject);
        }
    }

}
