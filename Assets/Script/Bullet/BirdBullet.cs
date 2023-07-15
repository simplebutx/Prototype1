using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBullet : MonoBehaviour
{
    public Vector2 direction;
    private Rigidbody2D rigidbody;
    public float speed;
    public float power;
    public GameObject babyBirdPrefab;
    public GameObject babyBirdCopy;
    public GameObject babyBirdCopy2;
    public List<GameObject> monsters = new List<GameObject>();

    private void Start()//인스턴스화 하면 캐논에서 받아온 direction으로 발사된다.
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction.normalized * speed;
        babyBirdPrefab = Resources.Load("BirdBabyBullet") as GameObject;
        
        monsters.AddRange(GameObject.FindGameObjectsWithTag("Monster"));
        monsters.Sort(compareHp);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Monster"))
        {
            InstantiateBaby();
            Destroy(gameObject);
        }
    }
    private void InstantiateBaby()
    {
        float initX = Random.Range(-1f, 1f);
        float initY = Random.Range(-1f, 1f);

        Vector2 startDir = new Vector2(initX, initY);
        Vector3 startDir2 = Quaternion.AngleAxis(120, Vector3.forward) * startDir;
        Vector3 startDir3 = Quaternion.AngleAxis(240, Vector3.forward) * startDir;

        babyBirdCopy = Instantiate(babyBirdPrefab, transform.position, Quaternion.identity);
        babyBirdCopy.GetComponent<BirdBabyBullet>().target = monsters[0];
        babyBirdCopy.GetComponent<BirdBabyBullet>().startDir = startDir.normalized;
        babyBirdCopy = Instantiate(babyBirdPrefab, transform.position, Quaternion.identity);
        babyBirdCopy.GetComponent<BirdBabyBullet>().target = monsters[0];
        babyBirdCopy.GetComponent<BirdBabyBullet>().startDir = startDir2.normalized;
        babyBirdCopy = Instantiate(babyBirdPrefab, transform.position, Quaternion.identity);
        babyBirdCopy.GetComponent<BirdBabyBullet>().target = monsters[0];
        babyBirdCopy.GetComponent<BirdBabyBullet>().startDir = startDir3.normalized;
    }
    private int compareHp(GameObject A, GameObject B)
    {
        float aHp = A.GetComponent<IMonsterStat>().ReturnMonsterStat().hp;
        float bHp = B.GetComponent<IMonsterStat>().ReturnMonsterStat().hp;
        return aHp < bHp ? -1 : 1;
    }
}
