using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField]
    private IntVariable _score;     // Le scriptable object contenant le score actuel
    [SerializeField]
    private int _value;             // La valeur a rajouter au score lorsque l'item est ramass�e par le joueur

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si le joueur traverse le collider
        if (collision.CompareTag("Player"))
        {
            // On augmente le score
            _score.Value += _value;
            // Et on d�truit l'item
            Destroy(gameObject);
        }
    }
}
