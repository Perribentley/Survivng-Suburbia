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

    [SerializeField] string NewGameScene;

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
        if(collision.gameObject.CompareTag ("Player"))
        {
            Health -= 10;
            SetDamageText();
        }
    }

    void SetDamageText()
    {
        Damage.text = "Health: " + Health.ToString() + "%";
        if (Health == 0)
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(NewGameScene);
    }
}
