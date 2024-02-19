using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class MessageBox : MonoBehaviour
{
    public static MessageBox instance;
    [SerializeField] public RectTransform box;
    [SerializeField] public Button ReStartButton;
    [SerializeField] public Button ReturnButton;
    [SerializeField] public Button MainButton;
    public float StartY;
    public bool IsShow;
    // Start is called before the first frame update
    private void Awake()
    {
       if(instance==null)
        {
            instance = this;
        }
       else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        HideMessageBox();
    }
    private void ShowMessageBox()
    {
        box.gameObject.SetActive(true);
        ReStartButton.gameObject.SetActive(true);
        ReturnButton.gameObject.SetActive(true);
        MainButton.gameObject.SetActive(true);
    }
    public void HideMessageBox()
    {
        box.gameObject.SetActive(false);
        ReStartButton.gameObject.SetActive(false);
        ReturnButton.gameObject.SetActive(false);
        MainButton.gameObject.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            ShowMessageBox();
        }
    }
}
