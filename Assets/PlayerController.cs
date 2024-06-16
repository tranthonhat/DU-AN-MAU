using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f; // Tốc độ di chuyển của nhân vật
    public float jumpForce = 50f; // Lực nhảy của nhân vật
    private Rigidbody2D rb;
    private bool isGrounded = false;

    private bool facingRight = true;

    public Vector3 initialPosition; // Vị trí ban đầu của nhân vật

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Lưu lại vị trí ban đầu của nhân vật
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển ngang
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Nhảy
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        

        // Lấy đầu vào từ phím mũi tên hoặc phím A/D để di chuyển nhân vật
        float move = Input.GetAxis("Horizontal");

        // Nếu nhân vật di chuyển sang phải và không facingRight, hoặc di chuyển sang trái và đang facingRight
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Kiểm tra xem nhân vật có đang ở trên mặt đất không
        if (other.gameObject.CompareTag("matdat"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Kiểm tra xem nhân vật có rời khỏi mặt đất không
        if (other.gameObject.CompareTag("matdat"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            // Kiểm tra xem nhân vật có chạm vào đối tượng "Gai" không
            if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "gai")
            {
                Die();
            }
            Debug.Log("khong duoc");
        
    }

    //void OnTriggerEnter2D(Collider other)
    //{
    //    // Kiểm tra xem nhân vật có chạm vào đối tượng "Gai" không
    //    if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "gai")
    //    {
    //        Die();
    //    }
    //    Debug.Log("khong duoc");
    //}
    //void OnCollisionEnter2D(Collision collision)
    //{
    //    // Kiểm tra va chạm với enemy
    //    if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "gai")
    //    {
    //        Die();
    //    }
    //}
    void Die()
    {
        Debug.Log("Player has died and will respawn.");
        // Đưa nhân vật trở lại vị trí ban đầu
        transform.position = initialPosition;
        // Bạn có thể thêm hiệu ứng chết ở đây, ví dụ như làm nhân vật nhấp nháy hoặc phát âm thanh
      
    }

    void Flip()
    {
        // Đảo hướng của facingRight
        facingRight = !facingRight;
         
        // Nhân tỷ lệ của nhân vật với -1 trên trục x để lật nhân vật
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
/*    void LoadScene()
    {
        // Kiểm tra và thiết lập cấp độ nếu chưa có
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        // Lấy cấp độ hiện tại
        int currentLevel = PlayerPrefs.GetInt("Level");

        // Tải cảnh tương ứng với cấp độ hiện tại
        string sceneName = "Level" + currentLevel.ToString();
        SceneManager.LoadScene(sceneName);
    }*/
}
