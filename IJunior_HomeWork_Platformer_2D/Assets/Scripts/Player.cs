using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _coins;
    [SerializeField] private Transform _spawnPoint;

    public Vector3 Die()
    {
        return _spawnPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent<Coin>(out Coin coin))
        {
            _coins++;
            collider.gameObject.SetActive(false);
        }
    }
}
