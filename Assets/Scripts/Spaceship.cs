using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Spaceship : MonoBehaviour
{
    /// <summary>移動スピード</summary>
    public float speed;

    /// <summary>弾を撃つ間隔</summary>
    public float shotDelay;

    /// <summary>弾のPrefab</summary>
    public GameObject bullet;

    /// <summary>弾を撃つかどうか</summary>
    public bool canShot;

    /// <summary>爆発のPrefab</summary>
    public GameObject explosion;

    /// <summary>AnimatorComponent</summary>
    private Animator animator;

    void Start()
    {
        // アニメーターコンポーネントを取得
        animator = GetComponent<Animator>();
    }

    // 爆発の作成
    public void Explosion()
    {
        Instantiate(explosion, transform.position, transform.rotation);
    }

    // 弾の作成
    public void Shot(Transform origin)
    {
        Instantiate(bullet, origin.position, origin.rotation);
    }

    // アニメーターコンポーネントの取得
    public Animator GetAnimator()
    {
        return animator;
    }
}