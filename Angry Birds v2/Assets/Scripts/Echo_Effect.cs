using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Echo_Effect : MonoBehaviour
{
    public float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public GameObject echo;

    private Player_Movement _player;

    private void Start() {
        _player = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_player.rb.velocity.x > 1f) {
            if (timeBtwSpawn <= 0) {
                GameObject instance = Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 2f);
                timeBtwSpawn = startTimeBtwSpawn;
            }
            else{
                timeBtwSpawn -= Time.deltaTime;
            }
        }
    }
}
