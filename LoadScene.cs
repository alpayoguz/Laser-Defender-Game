using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScene : MonoBehaviour
{
    int sceneIndex;
   [SerializeField] Mothership mothership;
   [SerializeField] Enemy enemy;
   


    public void SceneLoader()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }

   

    public void QuitGame()
    {
        Application.Quit();

    }

    private void Start()
    {
        
    }


    private void Update()
    {
        StartCoroutine(GetLastScene());
    }


    IEnumerator GetLastScene()
    {
        if(mothership.currentHealth <= 0)
        {
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(2);
            
        }
    }

}
