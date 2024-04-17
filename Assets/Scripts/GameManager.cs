using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    AudioSource audioSource;
    public AudioClip clip;

    float time = 0.0f;
    public Text Timetxt;
    public GameObject EndTxt;
    public RectTransform levelfront;

    public int CardCount = 0;
    public Card firstcard;
    public Card secondcard;

    public Text Leveltxt;

    int level = 0;
    int score = 0;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Timetxt.text = time.ToString("N2");

        if (time >= 30.0f)
        {
            EndTxt.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }

    public void matched()
    {
        if(firstcard.idx == secondcard.idx)
        {
            //파괴
            audioSource.PlayOneShot(clip);
            firstcard.Destroycard();
            secondcard.Destroycard();
            CardCount -= 2;
            AddScore();

            if(CardCount == 0)
            {

                EndTxt.SetActive(true);
                Time.timeScale = 0.0f;
                // board 스크립트에서 스타트 함수 호출해서 레벨은 그대로, 시간 초기화, 카드 배열 다시 하기
                // 내일 할일, 레벨 마무리, 레벨이 올라가면 주기적으로 레벨에 비례한 확률로 카드 근처에 고양이 생성,
                // 고양이는 클릭 n번으로 행복해지고 나감, 모든 카드를 맞췄을 때 고양이 파괴


            }
        }
        else
        {
            //닫아
            firstcard.Closecard();
            secondcard.Closecard();

        }
        firstcard = null;
        secondcard = null;


    }

    public void AddScore()
    {
        score++;
        level = score / 8;
        Leveltxt.text = level.ToString();
        levelfront.localScale = new Vector3((score-level*8)/ 8.0f , 1f, 1f);
    }


    
        
   
}