using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : MonoBehaviour
{
    public float moveSpeed = 3f;   // 이동 속도
    private Transform player;     // 플레이어 위치
    public float rotationSpeed = 5f; // 회전 속도
    public GameObject gameOverText;

    private void Start()
    {
        // Player 태그를 가진 오브젝트 찾기
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // 플레이어를 향해 이동
        if (player != null)
        {
            // 플레이어를 향한 방향 계산
            Vector3 direction = (player.position - transform.position).normalized;

            // 플레이어를 향해 회전
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // 플레이어를 향해 이동
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어와 충돌하면 게임 종료 처리
        if (collision.gameObject.CompareTag("Player"))
        {
            // Game Over 텍스트 활성화
            if (gameOverText != null)
            {
                gameOverText.SetActive(true);
            }

            // 플레이어 제거
            Destroy(collision.gameObject);
        }
    }
}
