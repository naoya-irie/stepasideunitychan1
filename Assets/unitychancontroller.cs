using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitychancontroller : MonoBehaviour {

    private Animator myAnimator;
    private Rigidbody myRigidbody;
    private float forwardForce = 800.0f;
    private float turnForce = 500.0f;
    private float movableRange = 3.4f;
    private float upForce = 500.0f;
    private float coefficient = 0.95f;
    private bool isEnd = false;
    private GameObject statetext;
    private GameObject scoretext;
    private int score = 0;
    private bool isLButtonDown = false;
    private bool isRButtonDown = false;


    void Start() {
        this.myAnimator = GetComponent<Animator>();
        this.myAnimator.SetFloat("Speed", 1);
        this.myRigidbody = GetComponent<Rigidbody>();
        this.statetext = GameObject.Find("gameresulttext");
        this.scoretext = GameObject.Find("scoretext");
    }

    void Update() {
        this.myRigidbody.AddForce(this.transform.forward * this.forwardForce);
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        { this.myRigidbody.AddForce(-this.turnForce, 0, 0); }

        else if ((Input.GetKey(KeyCode.RightArrow ) || this.isRButtonDown) && this.movableRange > this.transform.position.x)
        { this.myRigidbody.AddForce(this.turnForce, 0, 0); }

        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        { this.myAnimator.SetBool("Jump", false); }

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce); }
        if (this.isEnd)
        {
            this.forwardForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }
        }
            void OnTriggerEnter (Collider other) 
                { if (other.gameObject.tag == "cartag" || other.gameObject.tag == "trafficconetag")
        {
            this.isEnd = true;
            this.statetext.GetComponent<Text>().text = "GameOver";
        }
        if (other.gameObject.tag == "goaltag")
        {
            this.isEnd = true;
            this.statetext.GetComponent<Text>().text = "Clear!";
        }
        if (other.gameObject.tag == "cointag")
        {
            this.score += 10;
            this.scoretext.GetComponent<Text>().text = "Score" + this.score + "pt";
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
        }
            }

    public void GetMyJumpButtonDown ()
    {
        if (transform.position.y < 0.5f) {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }
    public void GetMyLButtonDown()
    {
        this.isLButtonDown = true;
    }
    public void GetMyLButtonUp()
    {
        this.isLButtonDown = false;
    }
    public void GetMyRButtonDown()
    {
        this.isRButtonDown = true;
    }
    public void GetMyRButtonUp()
    {
        this.isLButtonDown = false;
    }
}
    

