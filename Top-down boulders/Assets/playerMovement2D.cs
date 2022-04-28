using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement2D : MonoBehaviour
{
    public static playerMovement2D instance;
    public float speed = 5f;
    public Rigidbody2D rb2;
    public Animator animations;
    Vector2 inputMovement;
    public float latency;
    List<InputDelay> inputs = new List<InputDelay>();

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        latency = 0f;
    }

    public void killPlayer()
    {
        Destroy(this.gameObject);
    }
    IEnumerator walkingDelay()
    {
        yield return new WaitForSeconds(latency);
    }

    void Update()
    {
        inputMovement.x = Input.GetAxisRaw("Horizontal");
        inputMovement.y = Input.GetAxisRaw("Vertical");
        animations.SetFloat("Horizontal", inputMovement.x);
        animations.SetFloat("Vertical", inputMovement.y);
        animations.SetFloat("MovementSpeed", inputMovement.sqrMagnitude);
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        Vector2 axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        inputs.Add(new InputDelay(axis, Time.realtimeSinceStartup));
        int inputsInputted = 0;

        foreach (InputDelay id in inputs)
        {
            if (id.time + latency <= Time.realtimeSinceStartup)
            {
                transform.Translate(id.deltaPos * Time.deltaTime * speed);
                inputsInputted++;
            }
            else
            {
                break;
            }
        }
        rb2.velocity = Vector2.zero;
        inputs.RemoveRange(0, inputsInputted);
    }

    struct InputDelay
    {
        public Vector2 deltaPos { get; private set; }
        public float time { get; private set; }
        public InputDelay(Vector2 deltaPos, float time)
        {
            this.deltaPos = deltaPos;
            this.time = time;
        }
}
}
