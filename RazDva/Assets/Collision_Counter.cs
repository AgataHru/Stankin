using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionCounter : MonoBehaviour
{

    public Text CounterText;
    private int counter = 10;
    // Start is called before the first frame update
    void Start()
    {
        CounterText.text = "—чЄтчик столкновений: " + counter.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        counter--;
        CounterText.text = "—чЄтчик столкновений: " + counter.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
