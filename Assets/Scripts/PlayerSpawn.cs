using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private CharacterController _controller;

    public void Spawn()
    {
        int randInt = Random.Range(0, _spawnpoints.Count);

        _controller.enabled = false;
        _playerPosition.position = _spawnpoints[randInt].position;
        _controller.enabled = true;
    }
}
