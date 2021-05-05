using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEditor;

namespace Scoreboard2
{/*
    public class ScoreList
    {
        public List<Score> scores;
        private string file;


        public ScoreList(string file)
        {
            this.file = file;
            this.scores = loadScores();
            sortScores();
        }


        public List<Score> loadScores()
        {
            List<string> lines = test(file);
            //List<string> lines = new List<string>();
            //lines = File.ReadAllLines(file).ToList();
            //string path = "Assets/Resources/ScoreFile.txt";
            //StreamReader reader = new StreamReader(file);
            //while (reader.Peek() >= 0) { lines.Add(reader.ReadLine()); }
            
            List<Score> scores = new List<Score>();
            foreach (string l in lines)
            {
                string[] i = l.Split(null);
                scores.Add(new Score(i[0], int.Parse(i[1])));
            }

            return scores;
        }
        
        [MenuItem("Tools/Read file")]
        private static List<string> test(string file)
        {
            List<string> lines = new List<string>();
            //lines = File.ReadAllLines(file).ToList();
            //string path = "Assets/Resources/ScoreFile.txt";
            StreamReader reader = new StreamReader(file);
            while (reader.Peek() >= 0) { lines.Add(reader.ReadLine()); }
            return lines;
        }

        
        public void saveScores()
        {

            List<string> lines = new List<string>();
            foreach (var s in scores)
            {
                lines.Add(s.name + " " + s.seconds);
            }

            File.WriteAllLines(file, lines);
        }

        public void newScore(string name, int time)
        {
            scores.Add(new Score(name, time));
            sortScores();
        }

        void sortScores()
        {
            scores = scores.OrderBy(x => x.time).ToList();
        }

        public void printTopX(int topX)
        {
            int i = 0;
            sortScores();
            Console.WriteLine();
            foreach (var s in scores)
            {
                i++;
                Console.WriteLine(s.PrintScore());

                if (i == topX)
                {
                    break;
                }
            }
            Console.WriteLine();
        }

        public void printAllScores()
        {
            Console.WriteLine();
            foreach (var s in scores)
            {
                Console.WriteLine(s.PrintScore());
            }
            Console.WriteLine();
        }

        public void unityPrintAllScores()
        {
            foreach (var s in scores)
            {
                Debug.Log(s.PrintScore());
            }
        }

        [MenuItem("Tools/Read file")]
        public static void ReadString()
        {
            string path = "Assets/Resources/ScoreFile.txt";

            //Read the text from directly from the test.txt file
            StreamReader reader = new StreamReader(path);
            Debug.Log(reader.ReadToEnd());
            reader.Close();
        }

    }
    public class Score
    {
        public string name;
        public TimeSpan time;
        public int seconds;
        public Score(string name, int seconds)
        {
            this.name = name;
            this.seconds = seconds;
            this.time = new TimeSpan(0, 0, 0, seconds, 0);
        }

        public string PrintScore()
        {
            return name + " " + time;
        }



    }*/
}