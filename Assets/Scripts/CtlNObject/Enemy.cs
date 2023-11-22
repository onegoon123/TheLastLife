using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int MaxHp;
    public int Hp;

    bool battlestart;
    public float timer = 0;

    Animator animator;
    PlayerCtl player;
    SpriteRenderer sprite;

    void Start () {
        Hp = MaxHp;
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
	void Update () {
        StartCoroutine(Battle());
        Come();
        Timer();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (GameManager.instance.ScrollSpeed > GameManager.instance.NomalSpeed)
                Destroy(gameObject);
            else
                battlestart = true;
        }
        if (collision.transform.CompareTag("Floor"))
        {
            Destroy(gameObject);
        }
    }
    
    IEnumerator Battle()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || GameManager.instance.TouchOn == true)&& GameManager.instance.startBattle == true && battlestart == true && GameManager.instance.PlayerHp >= 0 && Time.timeScale == 1.0f)
        { // 1. 전투상황 2. 공격버튼 3. 지상
            Hp--;
            StartCoroutine(HitAnim());
            yield return null; //new WaitForSeconds(0.1f);
        }
        if (Hp <= 0)
        {
            GameManager.instance.startBattle = false;
            Hp = MaxHp;
            Destroy(gameObject);
        }
    }

    void Timer()
    {
        if (GameManager.instance.startBattle == true)
        {
            animator.SetBool("Attack", false);
            //시간을 누적시킴
            timer += Time.deltaTime;
        }
        //2초가 지나면...
        if (timer > 1.8f)
        {
            animator.SetBool("Attack", true);
            GameObject.Find("Bat").GetComponent<AudioSource>().Play();
        }
        if (timer > 2.0f)
        {
            animator.SetBool("Attack", false);
            GameManager.instance.PlayerHp -= 20;
            GameManager.instance.Hit = true;
            timer = 0;
        }
    }

    void Come()
    {
        if (GameManager.instance.startBattle == false)
        {
            Vector2 vector = new Vector2(-1, 0);
            transform.Translate(vector * GameManager.instance.ScrollSpeed * Time.deltaTime);
        }
    }

    IEnumerator HitAnim()
    {
        float t = 0;
        while (t <= 1)
        {
            t += Time.deltaTime * 10;
            sprite.color = Color.Lerp(Color.red, Color.white, t);
            yield return null;
        }
    }

}
