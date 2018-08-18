using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    /// <summary>ヒットポイント</summary>
    public int hp = 1;

    /// <summary>Scoreのポイント</summary>
    public int point = 100;

    // Spaceshipコンポーネント
    Spaceship spaceship;

    /// <summary>iTweenAnchor</summary>
    [SerializeField] float m_speed = 0.5f;
 
    IEnumerator Start()
    {

        // Spaceshipコンポーネントを取得
        spaceship = GetComponent<Spaceship>();

        // Enemy5用のVector
        var vec1 = new Vector3(-2f,2f);
        var vec2 = new Vector3(2f, 0f);


        if (this.gameObject.tag != "Enemy5")
        {
            // ローカル座標のY軸のマイナス方向に移動する
            Move(transform.up * -1);
        }
        else
        {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy5");
            for (int i = 0; i < Enemies.Length; i++)
            {
                iTween.MoveTo(Enemies[i], vec1 + vec2 * (i), m_speed);
            }
        }

        // canShotがfalseの場合、ここでコルーチンを終了させる
        if (spaceship.canShot == false)
        {
            yield break;
        }

        while (true)
        {

            // 子要素を全て取得する
            for (int i = 0; i < transform.childCount; i++)
            {

                Transform shotPosition = transform.GetChild(i);

                // ShotPositionの位置/角度で弾を撃つ
                spaceship.Shot(shotPosition);
            }

            // shotDelay秒待つ
            yield return new WaitForSeconds(spaceship.shotDelay);
        }
    }

    // 機体の移動
    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * spaceship.speed;
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得
        string layerName = LayerMask.LayerToName(c.gameObject.layer);

        // レイヤー名がBullet (Player)以外の時は何も行わない
        if (layerName != "Bullet (Player)") return;

        // PlayerBulletのTransformを取得
        Transform playerBulletTransform = c.transform.parent;

        // Bulletコンポーネントを取得
        Bullet bullet = playerBulletTransform.GetComponent<Bullet>();

        // ヒットポイントを減らす
        hp = hp - bullet.power;

        // 弾の削除
        Destroy(c.gameObject);

        // ヒットポイントが0以下であれば
        if (hp <= 0)
        {
            //ScoreComponentを取得してポイントを追加
            FindObjectOfType<Score>().AddPoint(point);

            // 爆発
            spaceship.Explosion();

            // エネミーの削除
            Destroy(gameObject);

        }
        else
        {

            spaceship.GetAnimator().SetTrigger("Damage");

        }
    }
}