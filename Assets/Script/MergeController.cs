using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using hit;

public class MergeController : MonoSingleton<MergeController>
{
    //Char 0,2  1,2   2,2   3,2
    //Cube 0,6  1,6   2,6
    [SerializeField] Transform player;
    [SerializeField] GameObject destroyedCube;
    [SerializeField] GameObject destroyedEnemyCube;
    [SerializeField] List<Transform> playerCubes;
    public List<Transform> PlayerCubes { get => playerCubes;  }
    public Transform HitObject { get; set; }
    public Transform HitEnemy { get; set; }
    public bool CheckHitCube { get; set; }
    public bool CheckHitStair { get; set; }
    public bool CheckHitFinish { get; set; }
    public bool CheckHitEnemy { get; set; }
    public bool IsPass { get; set; }

    private void Awake()
    {
        player= FindObjectOfType<Movement>().transform;
        
    }
    private void FixedUpdate()
    {
        checkHit();
    }

    void checkHit()
    {
       
        if (CheckHitCube)
        {
           
            CheckHitCube = false;
            player.GetComponent<Merge>().HitCubeMethod(player,PlayerCubes,HitObject);
            

        }
        else if (CheckHitStair)
        {
            
            CheckHitStair = false;
            player.GetComponent<HitStair>().HitStairMethod(player, PlayerCubes,CheckHitFinish);
            
        }
        else if (CheckHitEnemy)
        {
            CheckHitEnemy = false;
            player.GetComponent<HitEnemy>().PassCube( PlayerCubes);
           

            
        }
        if (IsPass)
        {
            IsPass = false;

            player.GetComponent<HitEnemy>().HitEnemyMethod(player, PlayerCubes, destroyedCube, destroyedEnemyCube);



        }

    }
}

