using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public Rigidbody plane;
    public int speed = 5;
    public BulletManager bulletManager;
    public GameObject baseCanvas;
    public GameObject gameoverCanvas;
    private float lastShoot;
    private float planeHealth;
    public float maxHealth = 13f;
    public Slider healthSlider;
    public AnimationClip anim;
    private bool inGame;
    Animation anim2;
    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animation>();
        planeHealth = maxHealth;
        inGame = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (inGame == true)
        {
            Vector3 movement = new((Input.GetAxis("Horizontal")) * speed, 0, (Input.GetAxis("Vertical")) * speed);

            plane.velocity = movement;

            if (Input.GetButton("Jump"))
            {
                if (Time.time - lastShoot > 0.1f)
                {
                    lastShoot = Time.time;
                    bulletManager.Shoot();
                }

            }
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            DamagePlane(1);
            anim2.clip = anim2.GetClip("Explode");
            anim2.Play();
        }
    }

    public void DamagePlane(float damage)
    {

        planeHealth -= damage;

        Debug.Log(planeHealth);

        if (planeHealth == 0)
        {
            Destroy(gameObject);
            gameOver();

        }

        healthSlider.value = planeHealth / maxHealth;
    }
    private void gameOver()
    {
        baseCanvas.SetActive(false);
        gameoverCanvas.SetActive(true);
        inGame = false;
    }
}
