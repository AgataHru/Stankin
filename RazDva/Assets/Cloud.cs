using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class Cloud : MonoBehaviour
{

    public Text nm;
    public Text lvl;
    public Slider dat;
    public Text dat1;
    public Jsonclass jsonData;

    public string jsonURL;


    // Start is called before the first frame update
    void Start()
    {
        dat.interactable = false;
        StartCoroutine(getData());   
    }

    IEnumerator getData()
    {
        Debug.Log("Loading...");
        var uwr = new UnityWebRequest(jsonURL);
        uwr.method = UnityWebRequest.kHttpVerbGET;
        var resultfile = Path.Combine(Application.persistentDataPath, "result.json");
        var dh = new DownloadHandlerFile(resultfile);
        dh.removeFileOnAbort = true;
        uwr.downloadHandler = dh;
        yield return uwr.SendWebRequest();

        if (uwr.result != UnityWebRequest.Result.Success )
        {
            nm.text = "Error!";
        }
        else
        {
            Debug.Log("File saved on the pass - " + resultfile);

            jsonData = JsonUtility.FromJson<Jsonclass>(File.ReadAllText(Application.persistentDataPath + "/result.json"));
            nm.text = jsonData.Name.ToString();
            lvl.text = jsonData.Level.ToString();
            dat.value = jsonData.TestParam;
            dat1.text = jsonData.TestParam.ToString();

            yield return StartCoroutine(getData());
        }
    }

    // Update is called once per frame
    void Update()
    { 
        
    }

    [System.Serializable]
    public class Jsonclass
    {
        public string Name;
        public int Level;
        public int TestParam;
    }
}
