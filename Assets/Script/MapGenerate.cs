using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerate : MonoSingleton<MapGenerate>
{
    //x+-4.1  z 8--80 94 164 4 12
    [SerializeField] GameObject GeneCube;
    [SerializeField] GameObject GeneEnemyCube;
    [SerializeField] GameObject FinalStair;
    [SerializeField] GameObject PlaneWithStair;
    [SerializeField] List<Vector3> GeneCubesList;
    [SerializeField] List<Vector3> GeneEnemyCubesList;
    public int StairNumber = 0;


    public void GenerateCubePos(int num1,int num2,int a,int b, float c,int stair)
    {
        for (int j = 0; j < stair; j++)
        {
            int RandNum = Random.Range(num1, num2);

            Debug.Log(RandNum + "GenerateCubePos ");
            while (GeneCubesList.Count != RandNum)
            {

                int flag = 0;
                float Randx = Random.Range(-4.1f, 4.1f);
                float Randz = Random.Range(a, b);
                Vector3 RandVec = new Vector3(Randx, c, Randz);


                if (GeneCubesList.Count < 1)
                {
                    GeneCubesList.Add(RandVec);
                }
                else
                {

                    for (int i = 0; i < GeneCubesList.Count; i++)
                    {
                        if (Dist(RandVec, GeneCubesList[i]))
                        {
                            flag++;
                        }
                        else
                        {
                            flag = 0;
                            break;
                        }
                    }
                    if (flag == GeneCubesList.Count)
                    {
                        GeneCubesList.Add(RandVec);
                    }
                }

            }
            GenerateCube();
            if (j >= 1)
            {
                GenerateStair(0.65f * j + ((j-1) * 0.4f), 85 * j);
            }
            if (j==stair-1)
            {
                GenerateFinal(0.65f * j + ((j - 1) * 0.4f) + 1, (85 * j) + 105);
            }
            

            num1 += 2;
            num2 += 2;
            a = b + 14;
            b += 84;
            c += 1.05f;
        }
       

    }
   

    public void GenerateCube()
    {
        for (int i = 0; i < GeneCubesList.Count; i++)
        {
            int a = Random.Range(0, 3);
            Debug.Log(a);
            if (a>=1)
            {
                Instantiate(GeneCube, GeneCubesList[i], Quaternion.identity);
            }
            else
            {
                Instantiate(GeneEnemyCube, GeneCubesList[i], Quaternion.identity);

            }

        }
        GeneCubesList.Clear();
    }
    public void GenerateStair(float a,float b)
    {
        //++065 85 0,95 +105
        Vector3 stairpos = new Vector3(0, a, b);
        Instantiate(PlaneWithStair, stairpos, Quaternion.identity);

    }
    public void GenerateFinal(float a, float b)
    {
        Vector3 finalpos = new Vector3(0, a, b);
        Instantiate(FinalStair, finalpos, Quaternion.identity);

    }

    public bool Dist(Vector3 rand1,Vector3 rand2)
    {
        float x = rand1.x - rand2.x;
        float z = rand1.z - rand2.z;

        if (UnityEngine.Mathf.Sqrt((x*x)+(z*z))>1.5f)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void StairNumber2()
    {
        StairNumber = 2;
        GameManager.Instance.Bonus = StairNumber;
    }
    public void StairNumber3()
    {
        StairNumber = 3;
        GameManager.Instance.Bonus = StairNumber;
    }
    public void StairNumber4()
    {
        StairNumber = 4;
        GameManager.Instance.Bonus = StairNumber;
    }
    public void StairNumber5()
    {
        StairNumber = 5;
        GameManager.Instance.Bonus = StairNumber;
    }
}
