using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private SpawnManagerX _spawnManager;
    private int _waveNumber;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player");
        _spawnManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        _waveNumber = _spawnManager.waveCount;
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        float modSpeed = speed * _waveNumber;
        enemyRb.AddForce(lookDirection * modSpeed * Time.deltaTime);
        

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
