using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartManager : MonoBehaviour
{
    public void Moral()
    {
        SceneManager.LoadScene("FirstGround");
    }
    public void BuffChoose()
    {
        SceneManager.LoadScene("ChooseBuff");
    }
    public void challenge()
    {
        SceneManager.LoadScene("SecondGround");
    }
    public void Rule()
    {
        SceneManager.LoadScene("Rule");
    }
    public void Set()
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
    public void Return()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Exit();
        }
    }
    public void Main()
    {
        SceneManager.LoadScene("Start Lancher");
    }
      
    public void Update()
    {
       
    }
        

    








}
