using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class jsonSaveSoader : MonoBehaviour
{
    JsonTestClass JsonData;
    // Start is called before the first frame update
    void Start()
    {
        //FileStream stream = new FileStream(Application.dataPath + "/Scripts/Json/test.json", FileMode.OpenOrCreate);                                                                  //json ¿˙¿Â
        //JsonTestClass jtest1 = new JsonTestClass();
        //string jsonData = JsonConvert.SerializeObject(jtest1);
        //byte[] data = Encoding.UTF8.GetBytes(jsonData);
        //stream.Write(data, 0, data.Length);
        //stream.Close();

        FileStream stream = new FileStream(Application.dataPath + "/Scripts/Json/asdf.json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        JsonData = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);
        JsonData.Print();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            File.Delete("Assets/Scripts/Json/asdf.json");
            FileStream stream = new FileStream(Application.dataPath + "/Scripts/Json/asdf.json", FileMode.OpenOrCreate);
            JsonData.Money = 3;
            string jsonData = JsonConvert.SerializeObject(JsonData);
            byte[] data = Encoding.UTF8.GetBytes(jsonData);
            stream.Write(data, 0, data.Length);
            stream.Close();
            Debug.Log("Save");
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            File.Delete("Assets/Scripts/Json/asdfg.json");
        }
    }

    void a()
    {
        
    }
}
