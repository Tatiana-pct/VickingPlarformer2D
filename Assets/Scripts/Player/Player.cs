using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // On déclare nos variables privées sérialisées
    [SerializeField]
    private GroundChecker _groundChecker;
    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private float _jumpForce = 7f;
    [SerializeField]
    private int _jumpCountMax = 2;
    [SerializeField]
    private float _fallGravityScale = 3f;

    // On déclare nos composants
    private Rigidbody2D _rigidbody;
    private Transform _transform;
    private Animator _animator;

    // On déclare nos variables privées
    private int _jumpCount;
    private float _movementInput;

    void Awake()
    {
        // On récupère les composants
        _rigidbody = GetComponent<Rigidbody2D>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    // RAPPEL : ON RECUPERE TOUJOURS LES INPUTS EN update (NON EN FixedUpdate)
    void Update()
    {
        // On récupère les inputs horizontales
        GetHorizontalInput();
        // On gère le changement de coté du personnage (gauche / droite)
        TurnCharacter();
        // On gère le saut
        Jump();
        // On améliore la chute
        BetterFalling();
        // On teste si l'on a touché le sol
        CheckGrounded();
        // On envoie les paramètres necessaires à l'Animator
        SetAnimatorParameters();
    }

    private void FixedUpdate()
    {
        // On applique les inputs horizontales
        ApplyHorizontalInput();
    }

    private void GetHorizontalInput()
    {
        // On stocke l'input horizontale dans une variable globale (pour pouvoir appliquer le mouvement en FixedUpdate)
        _movementInput = Input.GetAxisRaw("Horizontal");
    }

    private void Jump()
    {
        // SI l'on pas atteint le nombre de sauts max
        if (_jumpCount < _jumpCountMax && Input.GetButtonDown("Jump"))
        {
            // On fait sauter le personnage
            //_rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);      // Avec AddForce la puissance du saut sera contrecarré par la vitesse de chute
            _rigidbody.velocity = Vector2.up * _jumpForce;                        // Avec velocity la puissance du saut sera toujours la meme

            // On incrémente le nombre de sauts effectués
            _jumpCount++;
        }
    }

    private void TurnCharacter()
    {
        // Selon la direction du personnage on le "retourne"
        if (_movementInput < 0)
        {
            _transform.right = Vector2.left;
        }
        else if (_movementInput > 0)
        {
            _transform.right = Vector2.right;
        }
    }

    private void ApplyHorizontalInput()
    {
        // On applique le mouvement horizontal
        _rigidbody.velocity = new Vector2(_movementInput * _speed, _rigidbody.velocity.y);  // Ne pas oublier de reporter la vitesse verticale actuelle du rigidbody pour éviter l'effet "gravité lunaire"
    }

    private void BetterFalling()
    {
        // On modifie l'echelle de gravité si le personnage est en train de tomber
        _rigidbody.gravityScale = _rigidbody.velocity.y < 0f ? _fallGravityScale : 1f;
    }

    private void CheckGrounded()
    {
        // On vérifie que l'on est bien en train de tomber pour éviter de detecter le sol dès le début du premier saut
        if (_rigidbody.velocity.y < 0f)
        {
            // On vérifie que l'on a touché le sol
            bool isGrounded = _groundChecker.IsGrounded();

            // Si l'on a touché le sol
            if (isGrounded)
            {
                // On réinitialise le nombre de sauts effectués
                _jumpCount = 0;
            }
        }
    }

    private void SetAnimatorParameters()
    {
        // On envoie les paramètres à l'Animator
        _animator.SetFloat("HorizontalSpeed", Mathf.Abs(_movementInput));   // On "retire le signe" de la valeur de notre input horizontal pour obtenir une vitesse horizontale absolue et normalisée (valeur comprise entre 0 et 1)
        _animator.SetFloat("VerticalVelocity", _rigidbody.velocity.y);      // On envoie la vélocité verticale du rigidbody
    }

    // "Parenting" du joueur au contact des plateformes mobiles
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MobilePlatforms"))
        {
            _transform.parent = collision.transform;
        }
    }
    // "Unparenting" du joueur en sortie contact avec des plateformes mobiles
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MobilePlatforms"))
        {
            _transform.parent = null;
        }
    }
}
