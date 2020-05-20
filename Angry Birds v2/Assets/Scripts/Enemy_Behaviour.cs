using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Behaviour : MonoBehaviour
{
    [SerializeField]
    private float _minCollisionPower = 10f;

    
    [SerializeField]
    private GameObject _cloudParticlePrefab;

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.relativeVelocity.magnitude);
        if(other.relativeVelocity.magnitude > _minCollisionPower){
            Die();
        }
    }

    private void Die(){
        Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
