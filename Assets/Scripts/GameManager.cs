using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject eggGo;
    [SerializeField] private Transform eggSpawnPos;


    private void Start()
    {
        InitEggPos(eggSpawnPos);
    }
    private void InitEggPos(Transform _spawnPos)
    {
        eggGo.transform.position = _spawnPos.position;
    }
}
