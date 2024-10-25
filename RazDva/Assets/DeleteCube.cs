using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteCube : MonoBehaviour
{
    public GameObject obj;
    public Button but;

    private bool is_hiden = true;

    // Start is called before the first frame update
    void Start()
    {
        obj.SetActive(true);

        but.onClick.AddListener(ToogleActivity);
    }

    void ToogleActivity()
    {
        is_hiden = !is_hiden;
        obj.SetActive(is_hiden);
    }
}
