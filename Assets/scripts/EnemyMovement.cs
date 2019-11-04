using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float Speed = 20f;

    private Rigidbody Enemyrb;
    private GameObject Player;

    [SerializeField] Text Damage;
    private float Health = 100;

    public string NewGameScene;

    // Start is called before the first frame update
    void Start()
    {
        Enemyrb = GetComponent<Rigidbody>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 FollowDirection = (Player.transform.position - transform.position).normalized;
        Enemyrb.AddForce(FollowDirection * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Health -= 20;
            SetDamageText();
            if(Health == 0)
            {
                NewGame();
            }
        }
    }

    void SetDamageText()
    {
        Damage.text = "Health: " + Health.ToString() + "%";
    }

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }
}
