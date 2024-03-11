using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hit
{
    public class CheckHit : MonoBehaviour
    {
        [SerializeField] Transform[] passSpot;
        [SerializeField] Transform[] mergeSpot;
        [SerializeField] float maxDistance = 0.15f;
        internal bool CheckAboveEnemy = false;
        Ray[] raypass = new Ray[5];
        Ray[] raymerge = new Ray[3];
        bool isHit = false;
        bool _isPass = false;

        private void Awake()
        {

        }
        private void FixedUpdate()
        {

            checkPass();
            check();


        }

        private void check()
        {

            raymerge[0] = new Ray(mergeSpot[0].position, mergeSpot[0].forward * maxDistance);
            Debug.DrawRay(mergeSpot[0].position, mergeSpot[0].forward * maxDistance, Color.red);

            raymerge[1] = new Ray(mergeSpot[1].position, mergeSpot[1].forward * maxDistance);
            Debug.DrawRay(mergeSpot[1].position, mergeSpot[1].forward * maxDistance, Color.red);

            raymerge[2] = new Ray(mergeSpot[2].position, mergeSpot[2].forward * maxDistance);
            Debug.DrawRay(mergeSpot[2].position, mergeSpot[2].forward * maxDistance, Color.red);



            if (Physics.Raycast(raymerge[0], out RaycastHit hit, maxDistance))
            {
                isHit = true;
            }
            else if (Physics.Raycast(raymerge[1], out RaycastHit hit1, maxDistance))
            {
                isHit = true;
                hit = hit1;
            }
            else if (Physics.Raycast(raymerge[2], out RaycastHit hit2, maxDistance))
            {
                isHit = true;
                hit = hit2;
            }

            if (isHit)
            {
                MergeController.Instance.HitObject = hit.transform;


                if (hit.collider.CompareTag("Cube"))
                {
                    AudioManager.Instance.MergeSound();
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

                isHit = false;
            }

        }
        private void checkPass()
        {
            int layerMask = 1 << 7;

            raypass[0] = new Ray(passSpot[0].position, passSpot[0].up * -maxDistance);
            Debug.DrawRay(passSpot[0].position, passSpot[0].up * -maxDistance * 2.5f, Color.blue);

            raypass[1] = new Ray(passSpot[1].position, passSpot[1].up * -maxDistance);
            Debug.DrawRay(passSpot[1].position, passSpot[1].up * -maxDistance * 2.5f, Color.blue);

            raypass[2] = new Ray(passSpot[2].position, passSpot[2].up * -maxDistance);
            Debug.DrawRay(passSpot[2].position, passSpot[2].up * -maxDistance * 2.5f, Color.blue);

            raypass[3] = new Ray(passSpot[3].position, passSpot[3].up * -maxDistance);
            Debug.DrawRay(passSpot[3].position, passSpot[3].up * -maxDistance * 2.5f, Color.blue);

            raypass[4] = new Ray(passSpot[4].position, passSpot[4].up * -maxDistance);
            Debug.DrawRay(passSpot[4].position, passSpot[4].up * -maxDistance * 2.5f, Color.blue);




            if (Physics.Raycast(raypass[0], out RaycastHit hit3, maxDistance * 2.5f, layerMask))
            {
                _isPass = true;
            }
            else if (Physics.Raycast(raypass[1], out RaycastHit hit4, maxDistance * 2.5f, layerMask))
            {
                _isPass = true;
                hit3 = hit4;
            }
            else if (Physics.Raycast(raypass[2], out RaycastHit hit5, maxDistance * 2.5f, layerMask))
            {
                _isPass = true;
                hit3 = hit5;
            }
            else if (Physics.Raycast(raypass[3], out RaycastHit hit6, maxDistance * 2.5f, layerMask))
            {
                _isPass = true;
                hit3 = hit6;
            }
            else if (Physics.Raycast(raypass[4], out RaycastHit hit7, maxDistance * 2.5f, layerMask))
            {
                _isPass = true;
                hit3 = hit7;
            }






            if (_isPass)
            {


                if (hit3.collider.tag == "HitEnemy")
                {
                    MergeController.Instance.HitEnemy = hit3.collider.transform;
                    MergeController.Instance.IsPass = true;

                }

                _isPass = false;
            }


        }
    }
}