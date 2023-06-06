using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour
{
    public float ElapsedTime;
    public List<GameObject> Decorations;
    public List<GameObject> prefabs;
    public Text score;
    public int counter = 0;
    int decIterator=1;
    public int Barrier = 100;
    //transform.position = new Vector3(x, 1 + Mathf.Sqrt(0.5f*0.5f - x* x)*dir() , -8);

    void Start()
    {

        ElapsedTime = 3f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter > Barrier) {
            foreach (GameObject go in Decorations)
            {
                go.SetActive(false);
            }
            Decorations[decIterator].SetActive(true);
            decIterator++;
            if (decIterator == Decorations.Count) decIterator = 0;
            float x = Random.Range(-0.5f, 0.5f);
            float y = 1 + Mathf.Sqrt(0.5f * 0.5f - x * x) * dir();

            int r = Random.Range(0, prefabs.Count);
            //Debug.Log(r); cube sphere pyramide
            var temp = Instantiate(prefabs[r], new Vector3(x, y, -8f), transform.rotation);
   
            if ( r == 0 ) temp.GetComponent<objects>().objTag = "square";
            if ( r == 1 ) temp.GetComponent<objects>().objTag = "circle";
            if ( r == 2 ) temp.GetComponent<objects>().objTag = "triangle";
            //temp.GetComponent<objects>().time = ElapsedTime;
            temp.GetComponent<objects>().scoreText = score;
            temp.GetComponent<objects>().push(ElapsedTime);
            counter = 0;
            ElapsedTime += 0.08f;
        }

        counter++;
    }

    private float dir()
    {
        if (Random.Range(-1, 1) >= 0) return 1f;
        else return -1f;
    }
}
