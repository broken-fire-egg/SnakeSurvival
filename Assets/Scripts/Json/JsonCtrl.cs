using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;
public class JsonCtrl : MonoBehaviour
{
    JsonTestClass JsonLoadValue;
    // Start is called before the first frame update
    void Start()
    {
        JsonLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void JsonLoad()
    {
        FileStream stream = new FileStream(Application.dataPath + "/Scripts/Json/asdf.json", FileMode.Open);
        byte[] data = new byte[stream.Length];
        stream.Read(data, 0, data.Length);
        stream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        JsonLoadValue = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);
        JsonLoadValue.Print();
    }
}
