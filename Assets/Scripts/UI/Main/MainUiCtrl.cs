using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainUiCtrl : MonoBehaviour
{
    public GameObject Singleton;
    public GameObject Option;
    public GameObject BackgroundMoveGame;
    float time;

    Vector2 vector;
    public void Start()
    {
        vector = BackgroundMoveGame.transform.position;
    }
    public void Update()
    {
        time += Time.deltaTime;
        BackgroundMoveGame.transform.Translate(Vector2.up * 500.0f * Time.deltaTime);
        BackgroundMoveGame.transform.Translate(Vector2.right * 500.0f * Time.deltaTime);
        if(time >= 5.0f)
        {
            BackgroundMoveGame.transform.position = vector;
            time = 0;
        }
    }
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
