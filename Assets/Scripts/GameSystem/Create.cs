using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour
{

    //프리팹을 넣어줄 공개변수들
    public Transform Human1;
    public Transform Human2;
    public Transform Human3;
    public Transform Human4;
    public Transform Human5;

    public Transform Trap1;
    public Transform Trap2;
    public Transform Trap3;
    public Transform Trap4;
    public Transform Trap5;
    public Transform Trap6;



    public float EnemyCreateTime;
    public float TrapCreateTime;

    float timer = 0;
    float PotionTimer = 0;
    float SpeedPotionTimer = 0;
    float JumpTimer = 0;
    float EnemyTimer = 0;
    float TrapTimer = 0;

    public float CreatTime;
    public float PotionDelay;
    public float SpeedPotionDelay;
    public Transform Coin;
    public Transform Potion;
    public Transform SpeedPotion;

    float random;
    Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Jump();
    }

    void Timer()
    {
        if (GameManager.instance.startBattle == false)
        {
            timer += Time.deltaTime * (GameManager.instance.ScrollSpeed / GameManager.instance.StartSpeed); //시간을 누적시킴
            PotionTimer += Time.deltaTime;
            SpeedPotionTimer += Time.deltaTime;
            JumpTimer += Time.deltaTime;
            EnemyTimer += Time.deltaTime * (GameManager.instance.ScrollSpeed / GameManager.instance.StartSpeed); //시간을 누적시킴
            TrapTimer += Time.deltaTime * (GameManager.instance.ScrollSpeed / GameManager.instance.StartSpeed); //시간을 누적시킴.
        }

        if (EnemyTimer > EnemyCreateTime)
        {
            transform.position = new Vector3(12, -2.5f, 0);
            rigidbody.velocity = Vector2.zero;
            //적 생성
            CreateEnemy();
            //누적시간 초기화
            EnemyTimer = 0;
            TrapTimer -= 3;
            PotionTimer -= 0.5f;
            SpeedPotionTimer -= 1;
        }

        if (TrapTimer > TrapCreateTime)
        {
            transform.position = new Vector3(12, -2.5f, 0);
            rigidbody.velocity = Vector2.zero;
            //적 생성
            CreateTrap();

            //누적시간 초기화
            TrapTimer = 0;
            EnemyTimer -= 3f;
            PotionTimer -= 1.5f;
            SpeedPotionTimer -= 1.5f;
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
            SpeedPotionTimer -= 2;
            //GameManager.instance.ScrollSpeed = GameManager.instance.NomalSpeed += 1;
        }
        else if (SpeedPotionTimer >= SpeedPotionDelay)
        {   // 일정 시간마다 스피드포션
            Instantiate(SpeedPotion, transform.position + new Vector3(0, 0.4f, 0), Quaternion.identity);
            SpeedPotionTimer = 0;
            PotionTimer -= 2;
        }
        else// 그 외 경우 코인
            Instantiate(Coin, transform.position + new Vector3(0, -0.4f, 0), Quaternion.identity);
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
    //////////////
    /// 적 생성 ///
    //////////////
    void CreateEnemy()
    {
        //랜덤하게 생성하기위해 랜덤값을 받습니다.
        int birdNum = Random.Range(1, 6);

        //랜덤값에 따라 다른 적을 생성합니다.
        switch (birdNum)
        {
            case 1:
                Instantiate(Human1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Human2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Human3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Human4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Human5, transform.position, Quaternion.identity);
                break;
        }
    }

    void CreateTrap()
    {
        //랜덤하게 생성하기위해 랜덤값을 받습니다.
        int birdNum = Random.Range(1, 7);

        //랜덤값에 따라 다른 적을 생성합니다.
        switch (birdNum)
        {
            case 1:
                Instantiate(Trap1);
                break;
            case 2:
                Instantiate(Trap2);
                break;
            case 3:
                Instantiate(Trap3);
                break;
            case 4:
                Instantiate(Trap4);
                break;
            case 5:
                Instantiate(Trap5);
                break;
            case 6:
                Instantiate(Trap6);
                break;
        }
    }
}