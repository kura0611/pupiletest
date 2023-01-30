using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
public class pupiltestA : MonoBehaviour
{
                //⓪取得呼び出し-----------------------------
                //呼び出したデータ格納用の関数
                EyeData eye;
                //-------------------------------------------
                //Excelファイル作成
                public string filename ="Eye";
                StreamWriter sw;
                //④瞳孔の直径-------------------------------
                //呼び出したデータ格納用の関数
                float LeftPupiltDiameter;
                float RightPupiltDiameter;
                //-------------------------------------------
                int RightGetValidity;
                int LeftGetValidity;
                float limit = 3.0f;
                float elapsedTime;
                void Start()
                {
                    //Excelファイル作成
                    sw = new StreamWriter(@"" + filename + ".csv", false);
                    string[] s1 = {"time","left_x","left_y","left_z","right_x","right_y","right_z","position_x","position_y","position_z","rotation_x","rotation_y","rotation_z","pullleft","pullright"};
                    string s2 = string.Join(",", s1);
                    sw.WriteLine(s2);
/*             StartCoroutine("QuitGame"); */
                 Invoke("Destroy", 40);
              }

              void Destroy()
      　　  {
           UnityEditor.EditorApplication.isPlaying = false;
              UnityEngine.Application.Quit();
  　　　　　　 }

                void Update()
                {
                    //取得呼び出し-----------------------------
                    SRanipal_Eye_API.GetEyeData(ref eye);
                    LeftPupiltDiameter = eye.verbose_data.left.pupil_diameter_mm;
                    RightPupiltDiameter = eye.verbose_data.right.pupil_diameter_mm;
                    //④瞳孔の直径-------------------------------
                    //左目の瞳孔の直径が妥当ならば取得　目をつぶるとFalse 判定精度はまあまあ
                    if (eye.verbose_data.left.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_DIAMETER_VALIDITY))
                    {
                      LeftGetValidity = 1 ;
                  /*     Debug.Log(1); */
                    }else{
                        LeftGetValidity = 0;
                      /*   Debug.Log(0); */
                    }
                    ////右目の瞳孔の直径が妥当ならば取得　目をつぶるとFalse　判定精度はまあまあ
                    if (eye.verbose_data.right.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_PUPIL_DIAMETER_VALIDITY))
                    {
                      RightGetValidity = 1 ;
                    /*   Debug.Log(1); */
                    }else{
                        RightGetValidity = 0;
                     /*    Debug.Log(0); */
                    }
                    string[]str = {""+ time, ""+left_x, ""+left_y, ""+left_z, ""+right_x, ""+right_y, ""+right_z, ""+position_x, ""+position_y,""+position_z,""+rotation_x,""+rotation_y,""+rotation_z,""+pullleft,""+pullright,""+pullright,""+RightGetValidity,""+LeftGetValidity,""+RightPupiltDiameter,""+LeftPupiltDiameter
    };
                    string str2 = string.Join(",",str);
                    sw.WriteLine(str2);
                    sw.Flush();


/* #if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif */

            /* private IEnumerator QuitGame()
             {
                Debug.Log(11111111);
               yield return new WaitForSeconds(limit);
                 //終了処理
                 #if UNITY_EDITOR
                     UnityEditor.EditorApplication.isPlaying = false;
                 #elif UNITY_STANDALONE
                     UnityEngine.Application.Quit();
                 #endif
             } */
}
}
}
}
}
