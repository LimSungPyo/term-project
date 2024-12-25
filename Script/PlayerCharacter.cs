using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;   // 이동 속도
    public float jumpForce = 5f;  // 점프 힘
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // 수평 및 수직 이동 처리 (W, A, S, D)
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) move += Vector3.forward; // 앞으로 이동
        if (Input.GetKey(KeyCode.S)) move += Vector3.back;    // 뒤로 이동
        if (Input.GetKey(KeyCode.A)) move += Vector3.left;    // 왼쪽 이동
        if (Input.GetKey(KeyCode.D)) move += Vector3.right;   // 오른쪽 이동

        // 이동 속도 적용
        move = move.normalized * moveSpeed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // 플레이어가 바닥에 닿아있는지 확인
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }
}
