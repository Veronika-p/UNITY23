
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;


public class objects : MonoBehaviour
{
    Rigidbody body;
    public Text scoreText;
    public string objTag;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
    }

/*    public void doIt()
    {
        body.useGravity = true;
        body.isKinematic = false;
    }*/

    public void push(float time)
    {
        body.AddForce(transform.forward * time / 2, ForceMode.VelocityChange);
        body.AddRelativeTorque(new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f))*0.005f, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            scoreText.text = (int.Parse(scoreText.text) -5).ToString();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == objTag)
        {
            scoreText.text = (int.Parse(scoreText.text)+1).ToString();
            Debug.Log("popal " + objTag);
            Destroy(this.gameObject);
        }

    }

}