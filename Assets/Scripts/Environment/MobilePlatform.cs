using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    // On déclare nos variables privées sérialisées
    [SerializeField]
    private Transform _platform;
    [SerializeField]
    private Transform _waypointA;
    [SerializeField]
    private Transform _waypointB;
    [SerializeField]
    private float _speed = 2f;
    [SerializeField]
    private float _distanceThreshold = 0.1f;

    // On déclare nos variables privées
    private Transform _target;              // La cible (waypoint) en cours

    private void Awake()
    {
        // On définit la cible de départ
        _target = _waypointB;
    }

    // FIXEDUPDATE alors que déplacement non-physiques pour synchroniser le deplacement des plateformes avec celui du joueur (pour eviter les saccades lorsque celui-ci est en enfant)
    private void FixedUpdate()
    {
        // On calcule la direction du mouvement
        Vector2 direction = _target.position - _platform.position;
        direction.Normalize();
        // On déplace la plateforme d'un pas de mouvement vers la cible
        _platform.Translate(direction * _speed * Time.deltaTime);

        // On calcule la distance actuelle entre la plateforme et la cible (après le mouvement)
        float distance = Vector2.Distance(_platform.position, _target.position);
        // Si celle ci est en dessous du seuil
        if (distance <= _distanceThreshold)
        {
            // On change de cible
            SwitchTarget();
        }
    }

    private void SwitchTarget()
    {
        // Si la cible actuelle est waypointA
        if (_target == _waypointA)
        {
            // On définit la nouvelle cible sur waypointB
            _target = _waypointB;
        }
        // Sinon la cible actuelle est waypointB
        else
        {
            // On définit la nouvelle cible sur waypointA
            _target = _waypointA;
        }
    }
}
