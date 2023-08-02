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

    public void Start()
    {   
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            BackgroundMoveGame.transform.position = new Vector2(720, 1600);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            BackgroundMoveGame.transform.position = new Vector2(0, 0);
        }
        time += Time.deltaTime;
        //BackgroundMoveGame.transform.position = new Vector2(BackgroundMoveGame.transform.position.x + 5, BackgroundMoveGame.transform.position.y + 8.55f);
        BackgroundMoveGame.transform.Translate(Vector2.up * 855f * Time.deltaTime);
        BackgroundMoveGame.transform.Translate(Vector2.right * 500 * Time.deltaTime);
        if (time >= 4.5f)
        {
            BackgroundMoveGame.transform.position = new Vector2(720, 1600);
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
