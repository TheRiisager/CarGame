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

        private string _path;
        public int numberOfRows = 10; //evt kombinér med topX metoden i Scoreboard

        private string SetPath(string _fileName) => _path = Application.dataPath + ("\\Resources\\"+_fileName+".txt");

        public ScoreList sl;

        private void Start()
        {
            row.gameObject.SetActive(false);
            Debug.Log(Application.persistentDataPath);
        }

        public void makeTable(string _trackName)
        {
            
            clearTable();
            sl = new ScoreList(SetPath(_trackName));
            
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

                rowTransform.Find("Time").GetComponent<Text>().text = sl.scores[i].time.Minutes + ":" + sl.scores[i].time.Seconds.ToString("00") + ":" + sl.scores[i].time.Milliseconds +"";
                rowTransform.Find("Name").GetComponent<Text>().text = sl.scores[i].name;

                if(sl.scores.Count <=  i+1){break;}
            }
        }

        public void clearTable()
        {
            foreach(Transform row in table.transform)
            {
                if(row.gameObject.name.Contains("Clone"))
                GameObject.Destroy(row.gameObject);
            }

        }

        public void button_Grand()
        {
            makeTable("GrandTrack");
        }

        public void button_Alpha()
        {
            makeTable("File_AlphaTrack");
        }

        public void button_Bravo()
        {
            makeTable("File_BravoTrack");
        }

        public void button_Charlie()
        {
            makeTable("CharlieTrack");
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