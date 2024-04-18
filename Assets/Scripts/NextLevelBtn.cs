using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class NextLevelBtn : MonoBehaviour
{
    public GameObject card;
    public GameObject board;

    // 버튼 클릭 시 발동, 시간을 정상화 시키고 다음 함수를 0.1프레임 뒤에 발동

    public void NextLevel()
    {
        Invoke("NextLevelInvoke", 0.1f);

        Time.timeScale = 1.0f;
    }


    void NextLevelInvoke()
    {
        gameObject.SetActive(false);
        GameManager.instance.timereset();
    }
}
