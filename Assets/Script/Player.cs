using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public int stage;    
    public GameObject bullet;    
    public Material origin;
    public Material M1;
    public TextMeshProUGUI hpText; 
    public bool onFloor;
    public bool moveRight;
    public bool hasPowerup;    

    private GameManager gameManager;

    protected string conDataFileName;
    [SerializeField] protected int PlayerNO = 1;
    [SerializeField] protected float playerSpeed = 1.0f;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected int hp;
    
    void Awake()
    {
        conDataFileName = "PlayerData.csv";
    }
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();       
        SetConf();

        hp = PlayerPrefs.GetInt("HP", hp);       
    }
    void SetConf()
    {
        StreamReader input = null;
        string path = "Assets/StreamingAssets";
        try
        {
            input = File.OpenText(Path.Combine(path, conDataFileName));
            string name = input.ReadLine();
            string value = input.ReadLine();
            while (value != null)
            {
                AssignData(value);
                value = input.ReadLine();
            }
            Debug.Log("Good Job!");
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }
        finally
        {
            if (input != null)
            {
                input.Close();
            }
        }
    }
    void AssignData(string value)
    {
        string[] data = value.Split(',');
        if (PlayerNO == int.Parse(data[0]))
        {
            transform.name = data[1];
            playerSpeed = float.Parse(data[2]);
            jumpForce = float.Parse(data[3]);
            hp = int.Parse(data[4]);
        }
    }    
    void Update()
    {
        if (gameManager.isGameActive)
        {
            Move();
            Jump();
            PowerUp();            
        }  
        UpdateHP();
    }
    void UpdateHP()
    {
        hpText.text = "HP: " + hp;
    }    
    void Move()
    {        
        float Hori = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime; //แกน x
        ////float verti = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        transform.position += new Vector3(Hori, 0, 0);
        if (Hori < 0 && moveRight)
        {
            Flip();
        }
        if (Hori > 0 && !moveRight)
        {
            Flip();
        }
        if (transform.position.y < -3)
        {
            print("GameOver");
            gameManager.GameOver();
        }
    }    
    void Flip()
    {
        moveRight = !moveRight;
        transform.Rotate(Vector3.up * 180);
    }

    void Jump()
    {                
        if (Input.GetKeyDown(KeyCode.W) && onFloor == true)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
            //playerRB.AddForce(Vector3.up * jumpForce * Time.deltaTime, ForceMode.Impulse);
            onFloor = false;
        }
    }
    void PowerUp()
    {
        float bulletSpeed = 1;
        if (Input.GetKeyDown(KeyCode.Space) && hasPowerup)
        {            
            GameObject shootBullet = Instantiate(bullet, transform.position, bullet.transform.rotation);
            shootBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            
            //Rigidbody shootBulletRigibody = shootBullet.GetComponent<Rigidbody>();
            //shootBulletRigibody.AddForce(Vector3.forward * bulletSpeed);

            Destroy(shootBullet.gameObject, 1);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            print(hp);
            hp--;            
            PlayerPrefs.SetInt("HP", hp);
            if (hp <= 0)
            {
                gameManager.GameOver();
                PlayerPrefs.DeleteKey("HP");
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "pipe")
        {
            onFloor = true;
        }        
        if (collision.gameObject.tag == "powerup")
        {
            hasPowerup = true;
            GetComponent<Renderer>().material = M1;
            StartCoroutine(PowerupCountDown());
        }
        if(collision.gameObject.tag == "finish")
        {
            stage++;
            gameManager.Finish();
            Invoke("NextLV", 5);            
        }
    }
    IEnumerator PowerupCountDown()
    {
        yield return new WaitForSeconds(10);
        GetComponent<Renderer>().material = origin;
        hasPowerup = false;
    }
    void NextLV()
    {        
        SceneManager.LoadSceneAsync(stage);
    }
}
