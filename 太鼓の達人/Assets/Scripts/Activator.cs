using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class NoteObj
{
    public GameObject Dong, Ka;
}

public class Activator : MonoBehaviour
{
    public NoteObj Notes;
    public SpriteRenderer sr;
    public KeyCode key_Dong1, key_Dong2, key_Ka1, key_Ka2;

    private bool activeDong = false;
    private bool activeKa = false;
    
    // Combo
    public Combo comboText;
    public static int countGood;
    public static int countOk;
    public static int countBad;

    
    public Color old;
    public Score score;
    public GameObject good;
    public GameObject okok;
    public GameObject bad;

    // 判定
    public double range1, range2; // To judge 良、可、不可

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        good.SetActive(false);
        okok.SetActive(false);
        bad.SetActive(false);
    }
    
    void Update()
    {
        // Dong 聲音、顏色
        if (Input.GetKeyDown(key_Dong1) || Input.GetKeyDown(key_Dong2))
        {
            SoundManager.instance.Dong();
            StartCoroutine(Pressed());
        }

        // Ka 聲音、顏色
        if (Input.GetKeyDown(key_Ka1) || Input.GetKeyDown(key_Ka2))
        {
            SoundManager.instance.Ka();
            StartCoroutine(Pressed());
        }
        
        
        // Dong 得分
        if ((Input.GetKeyDown(key_Dong1) || Input.GetKeyDown(key_Dong2)) && 
            (!Input.GetKeyDown(key_Ka1) || !Input.GetKeyDown(key_Ka2)) && activeDong)
        {
            getScore_getCombo_Dong();
            if (Notes.Dong)
            {
                Destroy(Notes.Dong);
            }
            activeDong = false;
        }
        
        // Ka 得分
        if ((Input.GetKeyDown(key_Ka1) || Input.GetKeyDown(key_Ka2)) && 
            (!Input.GetKeyDown(key_Dong1) || !Input.GetKeyDown(key_Dong2)) && activeKa)
        {
            getScore_getCombo_Ka();
            if (Notes.Ka)
            {
                Destroy(Notes.Ka);
            }
            activeKa = false;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            activeDong = true;
            Notes.Dong = col.gameObject;
        }

        if (col.gameObject.tag == "Note2")
        {
            activeKa = true;
            Notes.Ka = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Note")
        {
            activeDong = false;
            Notes.Dong = col.gameObject;
        }

        if (col.gameObject.tag == "Note2")
        {
            activeKa = false;
            Notes.Ka = col.gameObject;
        }
        
    }

    void getScore_getCombo_Dong()
    {
        // 判斷精準度
        if (Math.Abs(Notes.Dong.transform.position.x - sr.transform.position.x) <= range1) // 良
        {
            //得分
            score.AddScore(100 * 2);
            comboText.AddCombo(1);
            StartCoroutine(ShowGood());
            countGood++; // 計算良
        }
        else if (range1 < Math.Abs(Notes.Dong.transform.position.x - sr.transform.position.x) &&
                 Math.Abs(Notes.Dong.transform.position.x - sr.transform.position.x) < range2) // 可
        {
            //得分
            score.AddScore(100);
            comboText.AddCombo(1);
            StartCoroutine(ShowOk());
            countOk++; // 計算可
        }
        
        else
        {
            comboText.combo = 0;
            StartCoroutine(ShowBad());
            countBad++; // 計算不可
        }
    }


    void getScore_getCombo_Ka()
    {
        // 判斷精準度
        if (Math.Abs(Notes.Ka.transform.position.x - sr.transform.position.x) <= range1) // 良
        {
            //得分
            score.AddScore(100 * 2);
            comboText.AddCombo(1);
            StartCoroutine(ShowGood());
            countGood++; // 計算良
        }
        else if (range1 < Math.Abs(Notes.Ka.transform.position.x - sr.transform.position.x) &&
                 Math.Abs(Notes.Ka.transform.position.x - sr.transform.position.x) < range2) // 可
        {
            //得分
            score.AddScore(100);
            comboText.AddCombo(1);
            StartCoroutine(ShowOk());
            countOk++; // 計算可
        }

        else
        {
            comboText.combo = 0;
            StartCoroutine(ShowBad());
            countBad++; // 計算不可
        }
    }


    IEnumerator Pressed()
    {
        Color old = sr.color;
        sr.color = Color.yellow;
        yield return new WaitForSeconds(0.05f);
        if (sr.color == Color.yellow) sr.color = old;
    }
    
    IEnumerator ShowGood()
    {
        good.SetActive(true);
        yield return new WaitForSecondsRealtime(0.15f);
        good.SetActive(false);
    }

    IEnumerator ShowOk()
    {
        okok.SetActive(true);
        yield return new WaitForSecondsRealtime(0.15f);
        okok.SetActive(false);
    }

    IEnumerator ShowBad()
    {
        bad.SetActive(true);
        yield return new WaitForSecondsRealtime(0.15f);
        bad.SetActive(false);
    }
}    