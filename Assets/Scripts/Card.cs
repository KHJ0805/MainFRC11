using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;
    public SpriteRenderer frontimage;
    public GameObject front;
    public GameObject back;
    public Animator anim;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        frontimage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }
    public void OpenCard()
    {
        audioSource.PlayOneShot(clip);
        anim.SetBool("IsOpen", true);
        front.SetActive(true);
        back.SetActive(false);


        // firstcard 가 비었다면
        if(GameManager.instance.firstcard == null)
        {
            // firstcard 에 내 정보를 넘겨준
            GameManager.instance.firstcard = this;

        }


        // firstcard 가 비어있지 않다면
        else
        {
            // secondcard 로 넘겨준다

            GameManager.instance.secondcard = this;
            // matched 함수 호출한다.

            GameManager.instance.matched();
        }

    }

    public void Destroycard()
    {
        Invoke("DestroyCardInvoke", 0.1f);
    }
    void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }



    public void Closecard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }
    void CloseCardInvoke()
    {
        anim.SetBool("IsOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }


    

}
