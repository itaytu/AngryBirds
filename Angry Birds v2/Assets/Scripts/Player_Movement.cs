using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{

    public Rigidbody2D rb;
    public Rigidbody2D hook;
    private bool isPressed = false;
    private bool isLanded = false;

    private Vector3 _initialPos;

    public float releaseTime = .15f;
    public float timeBtwSpawn = 4f;
    public float maxDragDistance = 2.5f;

    private static int _numOfLives;
    public Text _health;


    
    private void Awake() {
        _numOfLives = 4;
        _initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        _health.text = "Health: " + _numOfLives;
        checkPosition();

        if(isPressed) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(Vector3.Distance(mousePosition, hook.position) > maxDragDistance){
                rb.position = hook.position + (mousePosition - hook.position).normalized * maxDragDistance;
            }
            else
                rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(isLanded && rb.velocity.magnitude <= 0.01){
            ResetPosition();
        }

        if(_numOfLives == 0)
            SceneManager.LoadScene(0);
    }


    private void OnMouseDown() {
        isPressed = true;
        rb.isKinematic = true;
    }

    private void OnMouseUp() {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release(){
        Audio_Manager.isON = true;

        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        isLanded = true;        
    }

    private void ResetPosition() {
        //Debug.Log(_numOfLives);
        _numOfLives--;
        this.enabled = true;
        isLanded = false;
        transform.position = _initialPos;
        GetComponent<SpringJoint2D>().enabled = true;
        rb.velocity = Vector3.zero;
    }

    private void checkPosition() {
        if(transform.position.x > 45 ||
            transform.position.x < -15.5 ||
            transform.position.y > 9.2 ||
            transform.position.y < -5.6)
            ResetPosition();
    }
}
