using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreater : MonoBehaviour {

    float timer;
    float PotionTimer;
    float SpeedPotionTimer;
    float JumpTimer;

    public float CreatTime;
    public float PotionDelay;
    public float SpeedPotionDelay;
    public Transform Coin;
    public Transform Potion;
    public Transform SpeedPotion;

    float random;
    Rigidbody2D rigidbody;

    void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CoinTimer();
        Jump();
    }

    void CoinTimer()
    {
        if (GameManager.instance.startBattle == false)
        {
            timer += Time.deltaTime * (GameManager.instance.ScrollSpeed / GameManager.instance.NomalSpeed); //시간을 누적시킴
            PotionTimer += Time.deltaTime;
            SpeedPotionTimer += Time.deltaTime;
            JumpTimer += Time.deltaTime;
        }
        //일정시간이 지나면...
        if (timer > CreatTime)
        {
            //코인 생성
            CreateCoin();

            //누적시간 초기화

            timer = 0;
        }
    }

    void CreateCoin()
    {
        if (PotionTimer >= PotionDelay)
        {   // 일정 시간마다 포션
            Instantiate(Potion, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
            PotionTimer = 0;
            SpeedPotionTimer -= 5;
        }
        else if (SpeedPotionTimer >= SpeedPotionDelay)
        {   // 일정 시간마다 스피드포션
            Instantiate(SpeedPotion, transform.position + new Vector3(0,0.4f,0), Quaternion.identity);
            SpeedPotionTimer = 0;
            PotionTimer -= 5;
        }
        else// 그 외 경우 코인
            Instantiate(Coin, transform.position, Quaternion.identity);
    }

    void Jump()
    {
        if (JumpTimer >= 5)
        {
            random = Random.Range(5, 12);
            Vector2 jumpVelocity = new Vector2(0, random);
            rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
            JumpTimer = 0;
        }
    }
}
