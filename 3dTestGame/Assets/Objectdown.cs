using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectdown : MonoBehaviour
{
    //時間
    public float fadeTime = 4f;

    private float currentRemainTime;
    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        currentRemainTime = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 残り時間を更新
        currentRemainTime -= Time.deltaTime;

        //時間になったら下に移動
        if (currentRemainTime <= 3f)
        {
            transform.Translate(0,-0.01f,0);
        }

            if (currentRemainTime <= 0f)
        {
            // 残り時間が無くなったら自分自身を消滅
            GameObject.Destroy(gameObject);
            return;
        }
    }
}

