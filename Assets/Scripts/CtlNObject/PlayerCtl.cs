using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtl : MonoBehaviour {
    
    private BoxCollider2D _collider;
    private SpriteRenderer sprite;
    public Text Score;
    public Text HighScore;
    public Slider Hpbar;

    public int jumpForce;       // 점프력
    public Animator animator;

    public ParticleSystem RunParticle;
    public ParticleSystem SlidParticle;
    public ParticleSystem JumpParticle;
    public ParticleSystem DoubleParticle;
    public GameObject speede;
    new Rigidbody2D rigidbody2D;
    Transform transform;

    public int MaxJump = 2;
    public int JumpCount = 0;

    public bool Slid = false;
    bool Die = false;
    bool Run = false;
    public bool GodTime = false;

    Touch touch;
    float touchPos;
    bool touchOn;

    void Start () {
        GameManager.instance.PlayerHp = GameManager.instance.MaxHp;
        //transform = GetComponent<Transform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //CoinText = GameObject.FindObjectOfType<Text>();
        _collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        //RunParticle = GetComponent<ParticleSystem>();
        //SlidParticle = GetComponent<ParticleSystem>();

        GameManager.instance.ScrollSpeed = GameManager.instance.NomalSpeed = GameManager.instance.StartSpeed;
        GameManager.instance.PlayerHp = GameManager.instance.MaxHp;
        GameManager.instance.startBattle = false;
        GameManager.instance.GetCoin = 0;
        HighScore.text = "" + GameManager.instance.HighScore;
    }
	
	void Update () {
        HpSystem();
        TouchEvent();
        StartCoroutine("Jump");
        StartCoroutine("Attack");
        Sliding();
    }

    void Sound(string snd)
    {
        GameObject.Find(snd).GetComponent<AudioSource>().Play();
    }

    void TouchEvent()
    {
        touchOn = false;
        GameManager.instance.TouchOn = false;
        if (Input.touchCount > 0)
        {
            for(int i=0; i<Input.touchCount; i++)
            {
                touch = Input.GetTouch(i);
                if (touch.phase == TouchPhase.Began)
                {
                    touchPos = Camera.main.ScreenToWorldPoint(touch.position).x;
                    touchOn = true;
                    GameManager.instance.TouchOn = true;
                    break;
                }
            }
        }
    }
    IEnumerator Jump()
    {

        if ((Input.GetKeyDown(KeyCode.UpArrow) || touchOn == true) && JumpCount < MaxJump && GameManager.instance.startBattle == false && Die == false && Time.timeScale == 1.0f)
        {   // 1. 점프버튼을 누름 2. 점프한 횟수가 최대 점프 횟수보다 적을때 3. 전투상황이 아닐때
            if (Input.GetKeyDown(KeyCode.UpArrow) || touchPos < 0)
            {
                Sound("Jump");
                Slid = false;
                animator.SetBool("Slid", false);
                JumpCount++;
                animator.SetInteger("Jump", JumpCount);

                

                rigidbody2D.velocity = Vector2.zero;
                Vector2 jumpVelocity = new Vector2(0, jumpForce);
                rigidbody2D.AddForce(jumpVelocity, ForceMode2D.Impulse);


                if (Run == true)
                {
                    if (JumpCount == 1)
                    {
                        RunParticle.Stop();
                        JumpParticle.Play();
                        DoubleParticle.Stop();
                        SlidParticle.Stop();
                    }
                    if (JumpCount == 2)
                    {
                        RunParticle.Stop();
                        JumpParticle.Stop();
                        DoubleParticle.Play();
                        SlidParticle.Stop();
                    }
                }
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    void Sliding()
    {
        if ((Input.GetKey(KeyCode.DownArrow) || (Input.GetTouch(0).phase == TouchPhase.Stationary && touchPos >= 0)) && JumpCount == 0 && GameManager.instance.startBattle == false && Die == false && Run == false)
        {   // 1. 슬라이딩버튼을 누름 2. 점프를  않는 상태 3. 전투상황이 아닐때
            Slid = true;
            animator.SetBool("Slid", true);
            if (Run == true)
            {
                RunParticle.Stop();
                SlidParticle.Play();
            }
        }
        if ((Input.GetKeyDown(KeyCode.DownArrow) || (Input.GetTouch(0).phase == TouchPhase.Began && touchPos >= 0)) && JumpCount == 0 && JumpCount == 0 && GameManager.instance.startBattle == false && Die == false)
        {   // 1. 슬라이딩버튼을 누름 2. 점프를  않는 상태 3. 전투상황이 아닐때
            Slid = true;
            animator.SetBool("Slid", true);
            if (Run == true)
            {
                RunParticle.Stop();
                SlidParticle.Play();
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetTouch(0).phase == TouchPhase.Ended)
        {   // 1. 슬라이딩버튼을 땜
            
            Slid = false;
            animator.SetBool("Slid", false);
            if (Run == true)
            {
                RunParticle.Play();
                SlidParticle.Stop();
            }
        }
    }

    IEnumerator Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || touchOn == true) && JumpCount == 0 && GameManager.instance.startBattle == true && Die == false && Time.timeScale == 1.0f)
        {   // 1. 공격버튼을 누름 2. 지상에 있을 때 3. 전투 상황
            Sound("attack");
            animator.SetBool("Attack", true);
            yield return new WaitForSeconds(0.1f);
            animator.SetBool("Attack", false);
        }
        if (GameManager.instance.Hit == true)
        {
            StopCoroutine("PlayerHitAnim");
            StartCoroutine("PlayerHitAnim");
        }
        if (GameManager.instance.startBattle == false)
        {
            animator.SetBool("Battle", false);
        }
    }

    IEnumerator PlayerHitAnim()
    {
        GameManager.instance.Hit = false;
        float t = 0;
        GodTime = true;
        while (t <= 1)
        {
            t += Time.deltaTime * 0.75f;
            sprite.color = Color.Lerp(Color.red, Color.white, t);
            yield return null;
        }
        GodTime = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {   // 충돌한 물체의 태그가 Floor 일때
            //rigidbody2D.velocity = Vector2.zero;
            animator.SetInteger("Jump", 0);
            if(Run == true)
            {
                JumpParticle.Stop();
                DoubleParticle.Stop();
                RunParticle.Play();
            }
            //StartCoroutine(JumpDelay());
            JumpCount = 0;
            animator.SetInteger("Jump", 0);
        }

        if (collision.transform.CompareTag("Enemy"))
        {   // 1.충돌한 물체의 태그가 Enemy 일때
            if (Run == true)
                return;
            rigidbody2D.velocity = new Vector3(0, -10f);
            JumpCount = 0;
            animator.SetInteger("Jump", 0);

            animator.SetBool("Battle", true);
            GameManager.instance.startBattle = true;
        }
    }

        private void OnTriggerEnter2D(Collider2D collider)
        {
        if (collider.transform.CompareTag("Coin"))
        {   // 1. 충돌한 트리거의 태그가 Coin 일때
            Sound("coin");
            GameManager.instance.GetCoin += 5;
            Score.text = "" + GameManager.instance.GetCoin;
            if (GameManager.instance.HighScore < GameManager.instance.GetCoin)
            {
                GameManager.instance.HighScore = GameManager.instance.GetCoin;
                HighScore.text = "" + GameManager.instance.HighScore;
            }
        }

        if(collider.transform.CompareTag("Potion"))
        {   // 1. 충돌한 트리거의 태그가 Potion 일때
            GameManager.instance.PlayerHp += GameManager.instance.MaxHp / 100 * 25; // 최대체력의 25% 회복
            if (GameManager.instance.PlayerHp >= GameManager.instance.MaxHp)
                GameManager.instance.PlayerHp = GameManager.instance.MaxHp;
        }

        if(collider.transform.CompareTag("SpeedPotion"))
        {   // 1. 충돌한 트리거의 태그가 SpeedPotion 일때
            RunParticle.Play();
            StartCoroutine("SpeedUp");
            GameObject.Find("speed").GetComponent<AudioSource>().volume = GameManager.instance.SE;
            Sound("speed");
            Run = true;
            Instantiate(speede);
        }

        if (collider.transform.CompareTag("Trap"))
        {   // 1. 충돌한 트리거의 태그가 Trap 일때
            if (Run == false)
            {
                if (GodTime == false)
                {
                    Sound("trap");
                    GameManager.instance.PlayerHp -= 20;
                    StopCoroutine("PlayerHitAnim");
                    StartCoroutine("PlayerHitAnim");
                }
            }
        }
        
        if (collider.transform.CompareTag("SlidTrap"))
        {
            if (Run == false && Slid == false && GodTime == false)
            {
                Sound("trap");
                GameManager.instance.PlayerHp -= 20;
                StopCoroutine("PlayerHitAnim");
                StartCoroutine("PlayerHitAnim");
            }
        }
    }

    IEnumerator SpeedUp()
    {
        float t = 0;
        while(t <= 1)
        {
            t += Time.deltaTime * 0.25f;
            GameManager.instance.ScrollSpeed = GameManager.instance.NomalSpeed + t * 30;
            yield return null;
        }

        while (t >= 0)
        {
            t -= Time.deltaTime;
            GameObject.Find("speed").GetComponent<AudioSource>().volume -= Time.deltaTime;
            GameManager.instance.ScrollSpeed = GameManager.instance.NomalSpeed + t * 30;
            yield return null;
        }
        RunParticle.Stop();
        JumpParticle.Stop();
        DoubleParticle.Stop();
        SlidParticle.Stop();
        Run = false;
        GameManager.instance.ScrollSpeed = GameManager.instance.NomalSpeed;
    }
    void HpSystem()
    {
        GameManager.instance.PlayerHp -= 1 * Time.deltaTime;
        Hpbar.value = GameManager.instance.PlayerHp / GameManager.instance.MaxHp;
        if(GameManager.instance.PlayerHp <= 0)
        {
            Die = true;
            Run = false;
            GameManager.instance.ScrollSpeed = 0;
            animator.SetBool("Die", true);
            animator.SetBool("Battle", false);
            animator.SetBool("Slid", false);
            animator.SetBool("Attack", false);
            StartCoroutine("End");
        }
    }

    IEnumerator End()
    {
        PlayerPrefs.SetInt("HighScore", GameManager.instance.HighScore);
        float t = 0;
        while (t <= 3)
        {
            t += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(3);
    }

}
