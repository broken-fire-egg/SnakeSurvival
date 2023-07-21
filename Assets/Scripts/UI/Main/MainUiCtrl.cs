using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUiCtrl : MonoBehaviour
{
    public GameObject Singleton;
    public GameObject Option;
    public void a()
    {
        Singleton.GetComponent<test>().i++;
        SceneManager.LoadScene("ValueSettingScene");
    }

    public void OptionButton()
    {
        Option.SetActive(true);
    }

    public void WorldButton()
    {

    }

    public void CharacterButton()
    {

    }

    public void ShopButton()
    {

    }

    public void FriendsButton()
    {

    }
    
}
