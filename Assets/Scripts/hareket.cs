using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public OyunKontrol oyunK;
    public Animator animator;
    public Rigidbody2D rb2d;
    public AudioSource sesler;
    public AudioClip yürüme;
    public AudioClip zýplama;
    
    public float jump = 1f;
    public float hiz = 1f;
    public float horizontal;
    public float NormalHýz;
    public float YuksekHýz;
    public bool yüzSol;
    public bool isMoving;
    public bool charyerde;
    
    public float timer;
    public float timeBetwwenSteps;
 


    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sesler = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (oyunK.oyunAktif)
        {   
            //Hýzlandýrma
            if (Input.GetKey(KeyCode.LeftShift))
            {
                
                hiz = YuksekHýz;
                animator.SetBool("Koþma",true);
                

            }
            else
            {
                hiz = NormalHýz;
                animator.SetBool("Koþma", false);
                
                

            }
            //KARAKTERÝ ZIPLATMAK
            if ((Input.GetKeyDown(KeyCode.W)||(Input.GetKeyDown(KeyCode.UpArrow))) && (charyerde==true))
            {
                 rb2d.AddForce(new Vector2(0,jump));
                 sesler.PlayOneShot(zýplama);
                 charyerde = false;
            }

            if (horizontal !=0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }
            if (isMoving)
            {
                timer -= Time.deltaTime;
                if (timer <=0)
                {
                    timer = timeBetwwenSteps;
                    sesler.Play();
                }
                
            }
            
        }
       
    }
    //KARAKTERÝ YÜRÜTMEK
    void FixedUpdate()
    {
        if (oyunK.oyunAktif)
        {
                horizontal = Input.GetAxisRaw("Horizontal");
                 animator.SetFloat("Speed", Mathf.Abs(horizontal));
                rb2d.velocity = new Vector2(horizontal * Time.deltaTime * hiz, rb2d.velocity.y);
            if (yüzSol==true &&(Input.GetAxisRaw("Horizontal"))==-1)
            {
                Yonlendirme();
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else if (yüzSol==false &&(Input.GetAxisRaw("Horizontal"))==1)
            {
                Yonlendirme();
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }
            
    
    
    //ENGELE ÇARPMAK
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Engel"))
        {
            oyunK.oyunAktif = false;
        }
        if (collision.gameObject.tag == "yer") 
        {
            charyerde = true;
        }
    }
    //YÜZ ÇEVÝRME
    
    public void Yonlendirme()
    {
        yüzSol = !yüzSol;
        Vector2 scaler = transform.localScale;
        scaler.x *= 1;
        transform.localScale = scaler;
        
    }
}