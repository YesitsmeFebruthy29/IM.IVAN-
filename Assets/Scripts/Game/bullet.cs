using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 7.85f;

    private Rigidbody _rigidbody;
    private bool _isLaunched = false;
   
    
    private void Start()
    {
      
        Initialize();
    }

    private void Initialize()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(transform.forward * _speed, ForceMode.Impulse);
        Destroy(gameObject, 7.85f / _speed);
    }

    // пока

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamageable damageable) && _isLaunched)
        {
            damageable.TakeDamage(14885269);
            PhotonNetwork.Destroy(gameObject); 
        }

        if(_isLaunched == false)
        {
            _isLaunched = true;
        }

    }
}
