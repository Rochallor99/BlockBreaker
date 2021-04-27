
using UnityEngine;

public class ball : MonoBehaviour
{
    //configuration params.
    [SerializeField] paddle paddle1;
    [SerializeField]bool hasStarted=false;
    [SerializeField] AudioClip[] BallSounds;
    [SerializeField] float RandomFactor =1.5f;
    //state
    Vector2 paddleToBallVector;
    //cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    Vector2 velocityForBall;
   // [SerializeField] Vector2 velocity;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
       // velocityForBall = new Vector2(-5f, 15f);
       // velocityForBall = new Vector2(myRigidbody2D.velocity.x *20, myRigidbody2D.velocity.y * 20);
    }

    // Update is called once per frame
    void Update()  
    {
       // velocity = myRigidbody2D.velocity;
        if (!hasStarted)
        {
            lockBallToPaddle();
            launchOnMouseClick();
        }

        /*if(myRigidbody2D.velocity.x <3f && myRigidbody2D.velocity.y < 3f)
            {
                myRigidbody2D.velocity = velocityForBall;
            }*/
        
    }
    private void launchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(1f, 15f);
        }
    }

    private void lockBallToPaddle()
    {
        
        Vector2 paddlePos1 = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos1 + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
            (Random.Range(-1f, RandomFactor), 
            Random.Range(-1f, RandomFactor));
        if (hasStarted)
        {
            AudioClip clip = BallSounds[UnityEngine.Random.Range(0,BallSounds.Length)];
            myAudioSource.PlayOneShot(clip);

            myRigidbody2D.velocity += velocityTweak;
        }
        
    }
}
