using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUiCtrl : MonoBehaviour
{
    public GameObject Singleton;
    public void a()
    {
        Singleton.GetComponent<test>().i++;
        SceneManager.LoadScene("ValueSettingScene");
    }
}
