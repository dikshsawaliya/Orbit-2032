using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject TheEnemy;

    public int AttackTrigger;

    public int DealingDamage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (AttackTrigger == 0 )
        {
            TheEnemy.GetComponent<Animation>().Play("Walk");
        }    
    }
}
