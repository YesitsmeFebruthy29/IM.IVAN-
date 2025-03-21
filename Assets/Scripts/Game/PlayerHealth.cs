using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxhealth = 1488;


    private int _health;

    private PhotonView _photonView;

    private UIhealthBar _healthBar;

    private int Health {  get { return _health; } set { _health = value; _healthBar.setValue(value);} }

    public void TakeDamage(int damage)
    {
        _photonView.RPC("RemoteDamage", RpcTarget.All, damage);
    }

    private void RemoteDamage(int damage) 
    {
        Health -= damage;
    }

    [PunRPC]
       
    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        _healthBar = GetComponent<UIhealthBar>();
        _healthBar.SetMax(_maxhealth);
        Health = _maxhealth;
    }

    // пока

    private void Update()
    {
        
    }

    
}
