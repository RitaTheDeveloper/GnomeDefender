using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownGenerator : MonoBehaviour
{
    [SerializeField] private TownController[] _townPrefabList;
    [SerializeField] private int _numberOfTownProposed = 3;
    [SerializeField] private Transform _container;

    public List<TownController> GetListTownProposed()
    {
        List<TownController> list = new List<TownController>();

        for (int i = 0; i < _numberOfTownProposed; i++)
        {
            int randIndex = Random.Range(0, _townPrefabList.Length-1);
            var town = Instantiate(_townPrefabList[randIndex], _container);
            list.Add(town);
            town.Init();
        }

        return list;
    }
    
}
