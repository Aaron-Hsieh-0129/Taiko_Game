using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnNote : MonoBehaviour
{
    public NoteObj Notes;

    // Song Control
    // position track
    private float songPosition; // 節拍位置
    private float songPosInBeats; // 節拍持續時間
    private float secPerBeat;
    private float dsptimesong; // 歌曲開始時間
    private float beatOfThisNote;
    
    // 判定結束
    private bool isGameEnd = false;
    private bool isGameStart = true;
    
    private float[] notes = {5f, 6f, 6.5f, 7f, 8f, 9f, 10f, 11f, 11.5f,
                            12f, 12.5f, 13f, 14f, 14.5f, 15f, 16f, 17.0f, 18f, 19f, 
                            20f, 21f, 22f, 23f, 23.5f, 24f, 24.5f, 
                            25f, 25.5f, 27f, 28f, 29f, 30f, 30.5f, 31f,
                            32f, 33f, 33.5f, 34f, 35f, 35.5f, 36f, 37f, 
                            37.5f, 38f, 39, 39.5f, 40f, 41f, 42f, 43f, 
                            44.5f, 45f, 45.5f, 46f, 47f, 47.5f, 48f, 49f, 
                            50f, 50.5f, 51f, 51.5f, 53f, 54f, 55f, 
                            56f, 56.5f, 57f, 58f, 59f, 59.5f, 60f, 61f, 
                            62f, 62.5f, 63f, 64f, 65f, 65.5f, 66f, 67f, 
                            67.5f, 68f, 69f, 69.5f, 70f, 72f, 74f, 75f, 
                            75.5f, 77f, 79f, 80f, 81f, 81.5f, 82f, 83f, 
                            84f, 86f, 88f, 90f, 91f, 92f, 92.5f, 93f, 
                            94f, 94.5f, 95f, 97f, 99f, 100f, 101f, 102f, 
                            102.5f, 103f, 105f, 107f, 109f, 110f, 111f, 
                            113f, 116f, 117f, 117.5f, 118f, 119f, 120f, 
                            121f, 122f, 122.5f, 124f, 125f, 126.5f, 127f, 
                            129f, 131f, 132.5f, 133f, 135f, 136.5f, 138f, 
                            139f, 140f, 141f, 141.5f, 142f, 144f, 148f, 149f, 
                            150f, 151f, 152f, 154f, 154.5f, 155f, 157f, 158f, 
                            159f, 161f, 164f, 165f, 165.5f, 168f, 170f, 171.5f, 
                            172f, 173f, 174f, 174.5f, 176f, 178f, 179f, 180f, 
                            181f, 182f, 183f, 184.5f, 186f, 188f, 189f, 191f, 
                            193.5f, 194f, 195f, 196f, 197f, 199f, 201f, 202f, 
                            204f, 206f, 209f, 210f, 211f, 212f, 213f, 214f, 
                            215f, 217f, 219f, 221f, 223f, 223.5f, 225f, 227.5f, 
                            229f, 231f, 232f, 233.5f, 234f, 236f, 238f, 240f, 
                            241f, 242f, 243f, 244f, 245f, 246f, 247f};
    
    private int[] whichNote = {0, 0, 1, 0, 1, 1, 0, 0, 1,
                            0, 1, 1, 0, 1, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1,
                            1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1,
                            1, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1,
                            1, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1,
                            0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1,
                            0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1};
    
    
    // song messages
    private float bpm = 147f;
    private float timeNow;
    private int nextIndex;
    private int BeatsShownInAdvance = 4;
    
    void Awake()
    {
        secPerBeat = 60f / bpm;
        dsptimesong = Time.time;
    }
    
    void Update()
    {
        // 產生音符
        timeNow += Time.deltaTime;
        songPosition = (float) (timeNow - dsptimesong); // 現在的秒數
        songPosInBeats = songPosition / secPerBeat; // 現在的拍數

        // Dong 生成
        if (nextIndex < notes.Length && notes[nextIndex] <= songPosInBeats + BeatsShownInAdvance)
        {
            if (whichNote[nextIndex] == 1) // Dong 生成
            {
                Instantiate(Notes.Dong.transform.gameObject, new Vector3(140.0f, 10.0f, 4f), Notes.Dong.transform.rotation);
            }

            if (whichNote[nextIndex] == 0) // Ka 生成
            {
                Instantiate(Notes.Ka.transform.gameObject, new Vector3(140.0f, 10.0f, 4f), Notes.Ka.transform.rotation);
            }
            nextIndex++;
        }

        StartCoroutine(GameJudge());

        if (isGameEnd == true && isGameStart == false)
        {
            SceneManager.LoadScene(7);
        }

    }

    IEnumerator GameJudge()
    {
        if (notes.Length <= nextIndex)
        {
            isGameEnd = true;
            yield return new WaitForSecondsRealtime(7f);
            isGameStart = false;
        }
    }
}

