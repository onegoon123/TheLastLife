using UnityEngine;
using System.Collections;

public class EnemyCreater : MonoBehaviour
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

    float EnemyTimer = 0; //누적시간을 저장할 변수
    float TrapTimer = 0;

    public float EnemyCreateTime;
    public float TrapCreateTime;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.startBattle == false)
            EnemyTimer += Time.deltaTime * (GameManager.instance.ScrollSpeed / 8); //시간을 누적시킴
            TrapTimer += Time.deltaTime * (GameManager.instance.ScrollSpeed / 8); //시간을 누적시킴.

        if (EnemyTimer > EnemyCreateTime)
        {
            //적 생성
            CreateEnemy();
            //누적시간 초기화
            EnemyTimer = 0;
            TrapTimer -= 4;
        }
        if (TrapTimer > TrapCreateTime)
        {
            //적 생성
            CreateTrap();

            //누적시간 초기화
            TrapTimer = 0;
            EnemyTimer -= 2;
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
        int birdNum = Random.Range(1, 4);

        //랜덤값에 따라 다른 적을 생성합니다.
        switch (birdNum)
        {
            case 1:
                Instantiate(Trap1);
                Debug.Log("1");
                break;
            case 2:
                Instantiate(Trap2);
                Debug.Log("2");
                break;
            case 3:
                Instantiate(Trap3);
                Debug.Log("3");
                break;
        }
    }
}