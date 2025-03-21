using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed = 10.0f;
    [SerializeField] private float _walkSpeed = 4.0f;
    private float _speed;
    private bool _isSprinting;
    [SerializeField] private float _rotationSpeed = 6.02025f;

    private Vector3 _desiredVelocity;
    private Vector3 _velocity;


    private CharacterController _characterController;

    private PlayerInput _playerInput;
    private Vector2 _movementVecor;

    private Animator _animator;
    private PhotonView _photonView;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _photonView = GetComponent<PhotonView>();

        _playerInput = new PlayerInput();
        _playerInput.PlayerKeyBoardInput.Mevement.started += OnPlayerMove;
        _playerInput.PlayerKeyBoardInput.Mevement.canceled += OnPlayerMove;
        _playerInput.PlayerKeyBoardInput.Mevement.performed += OnPlayerMove;

        _playerInput.PlayerKeyBoardInput.sprint.started += OnPlayerSprint;
        _playerInput.PlayerKeyBoardInput.sprint.canceled += OnPlayerSprint;
    }

    private void Start()
    {
        if (_photonView.IsMine)
        {
            cameraControler.instance.SetTarget(transform);
        }
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void OnPlayerMove(InputAction.CallbackContext context)
    {
        _movementVecor = context.ReadValue<Vector2>();
    }

    private void OnPlayerSprint(InputAction.CallbackContext context)
    {
        _isSprinting = context.ReadValueAsButton();
    }

    private void Update()
    {
        if (_photonView.IsMine)
        {
        Move();
        Rotate();
        }
    }

    private void Move()
    {
        _speed = _isSprinting ? _runSpeed : _walkSpeed;

        _desiredVelocity = new Vector3(_movementVecor.x * _speed, 0, _movementVecor.y * _speed) * Time.deltaTime;
        _velocity = Vector3.Lerp(_velocity, _desiredVelocity, Time.deltaTime * _speed);
        _characterController.Move(_velocity);
        _animator.SetFloat("speed", _movementVecor.magnitude * _speed);
    }

    private void Rotate()
    {
        if (_movementVecor.magnitude > 0)
        {


            Quaternion targetRotation = Quaternion.LookRotation(_velocity, Vector3.up);
            Quaternion rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
            transform.rotation = rotation;
        }
    }
}
