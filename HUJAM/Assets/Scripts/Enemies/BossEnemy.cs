using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{

    [SerializeField] GameObject Arms;
    [SerializeField] float rotateSpeed;
    [SerializeField] int armIndex=0;
    [SerializeField] int checkPoint = 80;
    [SerializeField] RangedEnemy[] enemyList;
    public override void Move()
    {
        Debug.Log("HERE");
        var angle = Mathf.Atan2(Target.position.y - transform.position.y, Target.position.x - transform.position.x) *
                  Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

        transform.position = Vector3.MoveTowards(transform.position, Target.position, moveSpeed);
    }

    public void RotateArms()
    {
        Arms.transform.RotateAround(transform.position,transform.forward,Time.deltaTime*10f  );
    }

    void Start()
    {
        AssignValues();

        foreach (Transform child in Arms.transform)
        {
            if (child.GetComponent<RangedEnemy>() != null)
            {
                child.GetComponent<RangedEnemy>().ResetMoveSpeed(0);
                child.GetComponent<Collider2D>().enabled = false;
                //child.GetComponent<RangedEnemy>().moveSpeed = 0f;

            }

        }
    }
    private void FixedUpdate()
    {
        Move();
        RotateArms();
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
 
    public void HandleDamage()
    {
        Debug.Log(health);
        if(health == checkPoint)
        {
            Debug.Log("ARMMM" + armIndex);
            enemyList[armIndex].ResetMoveSpeed(enemyList[armIndex].valuesSO.moveSpeed);
            enemyList[armIndex].GetComponent<Collider2D>().enabled = true;
            enemyList[armIndex].gameObject.transform.parent = null;

            enemyList[armIndex + 1].ResetMoveSpeed(enemyList[armIndex + 1].valuesSO.moveSpeed);
            enemyList[armIndex+1].GetComponent<Collider2D>().enabled = true;
            enemyList[armIndex+1].transform.parent = null;
            armIndex += 2;
            checkPoint -= 20;
        }
        //switch(health)
        //{
        //    case 80:
        //        enemyList[0].SetActive(false);
        //        enemyList[1].SetActive(false);
        //        break;
        //    case 60:
        //        enemyList[2].SetActive(false);
        //        enemyList[3].SetActive(false);
        //        break;
        //    case 40:
        //        enemyList[4].SetActive(false);
        //        enemyList[5].SetActive(false);
        //        break;
        //    case 20:
        //        enemyList[6].SetActive(false);
        //        enemyList[7].SetActive(false);
        //        break;
        //    case 0:
        //        gameObject.SetActive(false);
        //        break;
        //}
    }
}
