using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using Newtonsoft.Json;

public class Jsontest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonConvert.SerializeObject(jTest1);
        //Debug.Log(jsonData);

        //JsonTestClass jTest2 = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);
        //jTest2.Print();

        //GameObject obj = new GameObject();
        //obj.AddComponent<TestMono>();
        //Debug.Log(JsonConvert.SerializeObject(obj.GetComponent<TestMono>()));

        JsonVector jVector = new JsonVector();
        JsonSerializerSettings setting = new JsonSerializerSettings();
        setting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        Debug.Log(JsonConvert.SerializeObject(jVector, setting));
    }

    // Update is called once per frame
    void Update()
    {

    }

    
}

public class JsonVector
{
    public Vector3 vector3 = new Vector3(3, 3, 3);
}
public class JsonTestClass
{
    public int Money;
    public int Level;

    public CharacterJson CatJson;
    public CharacterJson BirdJson;
    public CharacterJson CowJson;
    public CharacterJson FoxJson;
    public CharacterJson LizardJson;

    public ColleagueClass Colleague;

    public EnforceJson Enforce;

    public StageInfoJson Stage1;
    public StageInfoJson Stage2;
    public StageInfoJson Stage3;

    public UIJson UI;


    //public int i;
    //public float f;
    //public bool b;
    //public string str;
    //public int[] iArray;
    //public List<int> iList = new List<int>();
    //public Dictionary<string, float> fDictionary = new Dictionary<string, float>();
    //public IntVector2 iVector;

    //public JsonTestClass()
    //{
    //    i = 10;
    //    f = 99.9f;
    //    b = true;
    //    str = "JSON Test String";
    //    iArray = new int[] { 1, 1, 2, 3, 5, 8, 12, 21, 34, 55 };
    //
    //    for (int idx = 0; idx < 5; idx++)
    //    {
    //        iList.Add(2 * idx);
    //    }
    //
    //    fDictionary.Add("PIE", Mathf.PI);
    //    fDictionary.Add("Epsilon", Mathf.Epsilon);
    //    fDictionary.Add("Sqrt(2)", Mathf.Sqrt(2));
    //
    //    iVector = new IntVector2(3, 2);
    //}

    public void Print()
    {
        Debug.Log(Money);
        Debug.Log(Level);

        Debug.Log(CatJson.Unlock);
        Debug.Log(CatJson.Level);
        for (int i = 0; i < 3; i++)
            Debug.Log(CatJson.Attack[i]);
        for (int i = 0; i < 3; i++)
            Debug.Log(CatJson.Skill[i]);
        Debug.Log(CatJson.Clan);


        Debug.Log(BirdJson);
        Debug.Log(CowJson);
        Debug.Log(FoxJson);
        Debug.Log(LizardJson);


        Debug.Log(Enforce);

        Debug.Log(Stage1);
        Debug.Log(Stage2);
        Debug.Log(Stage3);
    }

    [System.Serializable]

    public class CharacterJson
    {
        public bool Unlock;
        public bool Level;
        public bool[] Attack;
        public bool[] Skill;
        public int Clan;
    }


    public class ColleagueClass
    {
        public bool Crow;
        public bool Beaver;
        public bool Mole;
        public bool Ferret;
        public bool Crane;
        public bool Otter;
        public bool Elepahnt;
        public bool Squirrel;
        public bool RattleSnake;
        public bool Rhino;
    }

    public class EnforceJson
    {
        public int Health;
        public int Speed;
        public int CritacalRate;
        public int CollectionRange;
        public int Exp;
        public int CriticalDamage;
        public int SkillCoolTime;
    }

    public class StageInfoJson
    {
        public int Progress;
        public bool Clear;
        public bool Unlock;
    }

    public class UIJson
    {
        public bool HowSkill;
        public int CharQual;
        public int BakcQual;
        public int Bgm;
        public int Efm;
        public string Account;
    }
}