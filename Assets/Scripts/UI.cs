using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void LoadNight()
    {
        SceneManager.LoadScene("Night");
    }

    public void LoadCastle()
    {
        SceneManager.LoadScene("Castle");
    }

    public void LoadBoss()
    {
        SceneManager.LoadScene("BossFight");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
