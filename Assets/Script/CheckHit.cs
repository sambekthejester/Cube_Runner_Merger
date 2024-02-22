using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hit
{
    public class CheckHit : MonoBehaviour
    {
        [SerializeField] Transform passSpot;
        [SerializeField] Transform mergeSpot;
        [SerializeField] float maxDistance = 0.15f;
        internal bool CheckAboveEnemy=false;

        private void Awake()
        {

        }
        private void FixedUpdate()
        {
            check();
            checkPass();
           
           
        }

        private void check()
        {

            Ray ray = new Ray(mergeSpot.position, mergeSpot.forward * maxDistance);
            

            Debug.DrawRay(mergeSpot.position, mergeSpot.forward * maxDistance, Color.red);
            
            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
            {
                MergeController.Instance.HitObject = hit.transform;
                if (hit.collider.tag == "Cube")
                {
                    
                    MergeController.Instance.CheckHitCube = true;
                   

                }
                else if (hit.collider.tag == "Enemy")
                {
                    
                    MergeController.Instance.CheckHitEnemy = true;
                    hit.collider.tag = "HitEnemy";
                    hit.collider.gameObject.layer = 7;
                }
                else if (hit.collider.tag == "Stair")
                {
                    
                    MergeController.Instance.CheckHitStair = true;
                    MergeController.Instance.CheckHitFinish = false;
                    hit.collider.tag = "HitStair";
                }
                else if (hit.collider.tag == "Finish")
                {

                    MergeController.Instance.CheckHitStair = true;
                    MergeController.Instance.CheckHitFinish = true;
                    GameManager.Instance.StairScore = hit.transform.GetComponent<FinishStair>().StairScore;
                    hit.collider.tag = "HitStair";
                }
            }
        }
        private void checkPass()
        {

            Ray ray = new Ray(passSpot.position, passSpot.up * -maxDistance);
           
            Debug.DrawRay(passSpot.position, passSpot.up * -maxDistance * 2.5f, Color.blue);



            if (Physics.Raycast(ray, out RaycastHit hit, maxDistance * 2.5f))
            {
               

                if (hit.collider.tag == "HitEnemy")
                {
                    MergeController.Instance.HitEnemy = hit.collider.transform;
                    CheckAboveEnemy = true;

                }
                if (CheckAboveEnemy  && hit.collider.tag != "HitEnemy")
                {
                    MergeController.Instance.IsPass = true;
                    CheckAboveEnemy = false;
                }
            }


        }
    }
}