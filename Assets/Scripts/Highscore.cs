using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEditor;

namespace Scoreboard
{
    public class Highscore : MonoBehaviour
    {

        public Transform row;
        public Transform table;

        //private string file = "Assets/Resources/ScoreFile.txt";
        private string file = "C:\\Users\\Alex Wagner\\Documents\\4semester\\Unity\\gamedev_handin4\\Assets\\Resources\\ScoreFile.txt";
        public ScoreList sl;

        private void Start()
        {
            makeTable();
        }

        public void makeTable()
        {
            row.gameObject.SetActive(false);

            sl = new ScoreList(file);
            int numberOfRows = 10; //evt kombinér med topX metoden i Scoreboard
            float spaceBetweenRows = 50f;

            for (int i = 0; i < numberOfRows; i++)
            {
                Transform rowTransform = Instantiate(row, table);
                RectTransform rowRectTransform = rowTransform.GetComponent<RectTransform>();
                rowRectTransform.anchoredPosition = new Vector2(0, -spaceBetweenRows * i);
                rowTransform.gameObject.SetActive(true);

                if (i == 0) { rowTransform.Find("Rank").GetComponent<Text>().text = "1st"; }
                else
                if (i == 1) { rowTransform.Find("Rank").GetComponent<Text>().text = "2nd"; }
                else
                if (i == 2) { rowTransform.Find("Rank").GetComponent<Text>().text = "3rd"; }
                else
                { rowTransform.Find("Rank").GetComponent<Text>().text = (i + 1) + "th"; }

                rowTransform.Find("Time").GetComponent<Text>().text = sl.scores[i].time + "";
                rowTransform.Find("Name").GetComponent<Text>().text = sl.scores[i].name;
            }
        }

        public void button_Test()
        {
            //Debug.Log(sl.scores[1].name);
            sl.unityPrintAllScores();

            //string path = "Assets/Resources/ScoreFile.txt";
            //Read the text from directly from the test.txt file
            //StreamReader reader = new StreamReader(path);
            //Debug.Log(reader.ReadToEnd());
            //Debug.Log(reader.ReadLine());

            //reader.Close();
        }

        public void button_Back()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}