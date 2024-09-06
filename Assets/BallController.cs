using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最小値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //スコアの初期値
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のScoreTextオブジェクトを取得
        this.scoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

        //衝突時に呼ばれる関数
        void OnCollisionEnter(Collision other)
        {      
            //SmallStarに衝突した場合
            if(other.gameObject.tag == "SmallStarTag")
            {
                score += 10;
            }

            //LargeStarに衝突した場合
            if (other.gameObject.tag == "LargeStarTag")
            {
                score += 30;
            }

            //SmallCloudに衝突した場合
            if (other.gameObject.tag == "SmallCloudTag")
            {
                score += 20;
            }

            //LargeCloudに衝突した場合
            if (other.gameObject.tag == "LargeCloudTag")
            {
                score += 40;
            }

            this.scoreText.GetComponent<Text>().text = "SCORE: " + score;
    }
}