using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform _respawnLocation;

    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    // Quand le joueur entre dans la zone de mort on le t�l�porte au point de r�apparition
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur traverse le collider
        if (collision.CompareTag("Player"))
        {
            // On d�place le RespawnPoint � la position du checkpoint
            _respawnLocation.position = _transform.position;
        }
    }
}
