using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float maxSpeed=16f;
    private float minSpeed=12f;
    private float maxTorque=10f;
    private float xRange=4f;
    private float ySpawnPos=-2;
    private GameManager gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;


    // Start is called before the first frame update
    void Start()
    {
        targetRb=GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);

        transform.position= RandomPosition();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minSpeed,maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    Vector3 RandomPosition()
    {
    return new Vector3(Random.Range(-xRange,xRange),ySpawnPos);
    }
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
        Destroy(gameObject);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        gameManager.ScoreUpdate(pointValue);
        }
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
}
