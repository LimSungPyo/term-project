using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnActor : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적 프리팹
    public float spawnInterval = 2f; // 생성 간격
    public Vector3 spawnArea = new Vector3(10, 0, 10); // 생성 영역 크기

    private void Start()
    {
        // 일정 시간 간격으로 적 생성
        InvokeRepeating("SpawnEnemy", 3f, spawnInterval);
    }

    private void SpawnEnemy()
    {
        // EnemySpawnActor의 위치를 기준으로 랜덤 위치 계산
        Vector3 spawnCenter = transform.position;
        Vector3 randomPosition = new Vector3(
            spawnCenter.x + Random.Range(-spawnArea.x / 2, spawnArea.x / 2),
            spawnCenter.y + 1f, // 적이 바닥 위에 생성되도록 y 값 설정
            spawnCenter.z + Random.Range(-spawnArea.z / 2, spawnArea.z / 2)
        );

        // 적 생성
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        // Debug 메시지로 생성 확인
        if (newEnemy != null)
        {
            Debug.Log($"Enemy spawned at {randomPosition}");
        }
        else
        {
            Debug.LogError("Failed to spawn enemy!");
        }
    }

}
