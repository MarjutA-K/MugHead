using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health = 50;
    public int baseHelath = 750;
    public int EnemyBulletDamage = 1;
    
    public int baseScore = 50;
    public GameObject Vines;
    public GameObject GroundVine;
    public GameObject Vine1;
    public GameObject Vine2;
    public GameObject Vine3;
    public GameObject Vine4;
    public GameObject Vine5;
    public GameObject Vine6;

    float shootCooldown;
    float nextShoot;

    public GameObject Bullet;
    public Transform BulletSpawn;

    public Animator anim;

    public GameObject Player;

    public bool Phase1 = true;
    public bool Phase2 = false;
    public bool Phase3 = false;

    public int bossKills;
    public float difficultyIncrement = 1.1f;

    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        shootCooldown = 2.5f;
        nextShoot = Time.time;

        GroundVine.SetActive(false);
        Vine1.SetActive(false);
        Vine2.SetActive(false);
        Vine3.SetActive(false);
        Vine4.SetActive(false);
        Vine5.SetActive(false);
        Vine6.SetActive(false);
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < 501)
        {
            Phase1 = false;
            Phase2 = true;
        }
    
        if (Health < 251)
        {
            Phase2 = false;
            Phase3 = true;
        }

        if (Phase1 && Player.activeInHierarchy)
        {
            anim.SetBool("Phase3", false);
            anim.SetBool("Phase1", true);
            BossShoot();
        }
        else if(Phase2)
        {
            anim.SetBool("Phase1", false);
            anim.SetBool("Phase2", true);
            Vines.GetComponent<GroundVineBehavior>().enabled = true;
        }
        
        if(Phase3)
        {
            anim.SetBool("Phase2", false);
            anim.SetBool("Phase3", true);

            Vines.GetComponent<GroundVineBehavior>().enabled = false;
            GameObject[] vines = GameObject.FindGameObjectsWithTag("Vines");

            for(int i = 0; i  < vines.Length; i++)
            {
                vines[i].SetActive(false);
            }
        }
    }

    public void EnemyDamage(int damage)
    {
        Health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(ColourChange());

        if (Health <= 0)
        {
            /*Destroy(gameObject);*/
            /*gameObject.SetActive(false);*/
            bossKills++;
            Health = Mathf.RoundToInt(baseHelath * difficultyIncrement);
            gameController.score += Mathf.RoundToInt(baseScore * difficultyIncrement);
            gameController.bossIsDead = true;

            Phase1 = true;
            Phase2 = false;
            Phase3 = false;

            GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.SetActive(false);
        }
    }

    void BossShoot()
    {
        if (Time.time > nextShoot)
        {
            Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
            nextShoot = Time.time + shootCooldown;
        }
    }

    IEnumerator ColourChange()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
