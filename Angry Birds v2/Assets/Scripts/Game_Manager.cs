using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Enemy_Behaviour[] _enemies;

    private void OnEnable() {
        _enemies = FindObjectsOfType<Enemy_Behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Enemy_Behaviour enemy in _enemies)
        {
            if(enemy != null)
            {
                return;
            }
        }
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index < 3){
            StartCoroutine(LoadScene());
        }
        else
            SceneManager.LoadScene(0);
    }

    IEnumerator LoadScene() {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
