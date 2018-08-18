using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトを上下左右に動かす。
/// </summary>
public class MovingObjectController : MonoBehaviour
{
    /// <summary>振り幅（横）</summary>
    public float m_amplitude_x = 1f;
    /// <summary>振り幅（縦）</summary>
    public float m_amplitude_y = 0f;
    /// <summary>動く速さ</summary>
    public float m_speed = 2.0f;
    private float m_timer;
    private Vector3 m_initialPosition;

    private void Start()
    {
        m_initialPosition = transform.position;
    }

    void Update()
    {
        // オブジェクトを回す
        m_timer += Time.deltaTime;
        float posX = Mathf.Sin(m_timer * m_speed) * m_amplitude_x;  // X 座標を計算する
        float posY = Mathf.Cos(m_timer * m_speed) * m_amplitude_y;  // Y 座標を計算する
        transform.position = m_initialPosition + new Vector3(posX, posY, 0);    // オブジェクトの初期位置を中心に回す
    }
}