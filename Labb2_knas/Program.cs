using System;
using System.Collections.Generic;
using System.Linq;


using System.Text.RegularExpressions;


namespace Lab_V2
{
    internal class Program
    {


        static void Main(string[] args)
        {
            //Lägga till i game

            String input = "shape ,X,Y,LENGTH ,POINTS;CIRCLE ,3,1,13,100; CIRCLE ,1,-1,15,200; square, -1 ,0 ,20 ,300; SQUARE , -3 ,2 ,8 ,400;";

            var stringInput = input.ToUpper();

            //Console.WriteLine("Mata in värdena");

            string inputDot = "(1,0)";



            //var stringInput = Console.ReadLine().ToUpper();

            string trimmed = String.Concat(stringInput.Where(c => !Char.IsWhiteSpace(c)));
            inputDot = String.Concat(inputDot.Where(c => !Char.IsWhiteSpace(c)));

            //Ta bort parentesen


            string[] dotValues = Regex.Split(inputDot, @",");



            //Header
            int startIndexHeader = 0;
            int lengthIndexHeader = 23;

            String substringHeader = trimmed.Substring(startIndexHeader, lengthIndexHeader);

            string[] headerVariables = Regex.Split(substringHeader, @",|;");





            //Variabler
            int startIndexVar = 24;
            int lengthIndexVar = trimmed[trimmed.Length - 1];


            String substringVariables = trimmed;


            string[] listVariables = Regex.Split(substringVariables, @";");



            int indexShape = Array.FindIndex(headerVariables, row => row.Contains("SHAPE"));
            int indexX = Array.FindIndex(headerVariables, row => row.Contains("X"));
            int indexY = Array.FindIndex(headerVariables, row => row.Contains("Y"));
            int indexPoints = Array.FindIndex(headerVariables, row => row.Contains("POINTS"));
            int indexLength = Array.FindIndex(headerVariables, row => row.Contains("LENGTH"));

            string header = listVariables[0];
            List<string[]> values = new List<string[]>();


            for (int i = 1; i <= listVariables.Length - 1; i++)
            {
                string[] seperateValues = Regex.Split(listVariables[i], @",");
                values.Add(seperateValues);
            }

            // Remove last array
            values.RemoveAt(values.Count - 1);

            int counterRow = 0;
            foreach (var item in values)
            {
                int counterCol = 0;
                Console.WriteLine("Row " + counterRow);
                foreach (var i in item)
                {
                    Console.WriteLine("Col " + counterCol + " " + i);
                    counterCol++;
                }
                counterRow++;

            }


            List<Circle> shapeCircle = new List<Circle>();
            List<Square> shapeSquare = new List<Square>();


            foreach (string[] row in values)
            {
                int x = Convert.ToInt32(row[indexX]);
                int y = Convert.ToInt32(row[indexY]);
                int length = Convert.ToInt32(row[indexLength]);
                int points = Convert.ToInt32(row[indexPoints]);
                if (row[indexShape] == "CIRCLE")
                {
                    shapeCircle.Add(new Circle(x, y, length, points));
                }
                else if (row[indexShape] == "SQUARE")
                {
                    shapeSquare.Add(new Square(x, y, length, points));
                }

            }

            int dotX = 1;
            int dotY = 0;

            List<double> hitCircle = new List<double>();
            List<double> missCircle = new List<double>();



            foreach (Circle c in shapeCircle)
            {
                if (c.Hit(dotX, dotY))
                {
                    hitCircle.Add(c.shapeScore());

                }
                else
                {
                    missCircle.Add(c.shapeScore());
                }
            }


            List<double> hitSquare = new List<double>();
            List<double> missSquare = new List<double>();

            Game game = new Game(missCircle, missSquare, hitSquare, hitCircle);


            foreach (Square s in shapeSquare)
            {
                if (s.Hit(dotX, dotY))
                {
                    hitSquare.Add(s.shapeScore());
                }
                else
                {
                    missSquare.Add(s.shapeScore());
                }
            }

            foreach (var item in hitSquare)
            {
                Console.WriteLine("Poäng för träffade fyrkanter: " + item);
            }

            foreach (var item in missSquare)
            {
                Console.WriteLine("Poäng för missade fyrkanter: " + item);
            }

            foreach (var item in hitCircle)
            {
                Console.WriteLine("Poäng för träffade cirklar: " + item);
            }

            foreach (var item in missCircle)
            {
                Console.WriteLine("Poäng för missade cirklar: " + item);
            }



        }



        //var instancePointsCircle = inputPointsCircle;
        //var AreaCircle = 10;
        //var x = 51;
        //var y = 1;
        //var length = inputLCircle;
        //var circleX = 0;
        //var circleY = 1;
        //var rad = (int) (length / (2 * Math.PI));

        //var botX = 10;
        //var botY = 3;
        //var topX = 20;
        //var topY = 25;
        //var L = 4;




        //// bottom-left and top-right
        //// corners of rectangle
        ////int x1 = 0, y1 = 0,
        ////    x2 = 10, y2 = 8;

        ////Avser fyrkant
        //Console.WriteLine("Ange en längd");
        //var inputLengthSquare = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine("Ange poäng för objektet");
        //var inputPointsSquare = Convert.ToInt32(Console.ReadLine());

        //Console.WriteLine("Ange att det är en fyrkant = 1");
        ////var inputShapeTypeSquare = Convert.ToInt32(Console.ReadLine());

        //// given point
        //int SquareX = 1, SquareY = 5;

        //var x1 = botX - inputLengthSquare / 2;
        //var y1 = botY - inputLengthSquare / 2;
        //var x2 = topX + inputLengthSquare / 2;
        //var y2 = topY + inputLengthSquare / 2;


        //var instancePointsSquare = inputPointsSquare;
        //var AreaSquare = 10;

        // function call
        //if (square.HitSquare(x1, y1, x2, y2, SquareX, SquareY))
        //{
        //    Console.Write("Inuti fyrkant");
        //    var eqSquareH = inputShapeTypeSquare * instancePointsSquare / AreaSquare;
        //    shapeScoreh.Add(eqSquareH);
        //}
        //else
        //{
        //    Console.Write("Utanför fyrkant");
        //    var eqSquareM = inputShapeTypeSquare * instancePointsSquare / AreaSquare;
        //    shapeScoreh.Add(eqSquareM);
        //}

        //Console.WriteLine(string.Join(", ", shapeScoreh));
        //Console.WriteLine(string.Join(", ", shapeScorem));
    }



    //public class Shape
    //{
    //    public Shape()
    //    {



    //    }
    //    public int getShapeType()
    //    {
    //        return 0;
    //    }
    //}

    public class Game
    {

        public List<double> shapeScoreHit = new List<double>();
        public List<double> shapeScoreMiss = new List<double>();

        //List<double> hitSquare = new List<double>();
        //List<double> missSquare = new List<double>();

        //List<double> hitCircle = new List<double>();
        //List<double> missCircle = new List<double>();



        public double score;


        public Game(List<double> missCircle, List<double> missSquare, List<double> hitSquare, List<double> hitCircle)
        {
            shapeScoreMiss = missCircle.Concat(missSquare).ToList();
            shapeScoreHit = hitSquare.Concat(hitCircle).ToList();
            score = Math.Round(shapeScoreHit.Sum() - (0.25 * shapeScoreHit.Sum()));
            foreach (var item in shapeScoreHit)
            {
                Console.WriteLine(item + ":_)");
            }
            foreach (var item in shapeScoreMiss)
            {
                Console.WriteLine(item + ":_----------)");
            }
            Console.WriteLine(score);
        }

    }




    public class Circle
    {
        public int x;
        public int y;
        public int length;
        public int points;
        public double rad;
        public double area;



        public Circle(int indexX, int indexY, int indexLength, int indexPoints)
        {
            this.x = indexX;
            this.y = indexY;
            this.length = indexLength;
            this.points = indexPoints;
            this.rad = this.length / (Math.PI * 2);
            this.area = (this.length * this.length) / (Math.PI * 4);


        }
        public bool Hit(int dotX, int dotY)
        {

            if ((dotY - this.x) * (dotX - this.x) +
                (dotY - this.y) * (dotY - this.y) <= this.rad * this.rad)
                return true;

            else
                return false;
        }

        public double shapeScore()
        {

            double equationCircle = this.getShapeType() * this.points / this.area;
            return equationCircle;
        }

        public int getShapeType()
        {
            return 2;
        }
    }

    public class Square
    {
        public int x;
        public int y;
        public int length;
        public int points;
        public int area;
        public int botX;
        public int botY;
        public int topX;
        public int topY;


        public Square(int indexX, int indexY, int indexLength, int indexPoints)
        {
            this.x = indexX;
            this.y = indexY;
            this.length = indexLength;
            this.points = indexPoints;
            this.area = (this.length / 4) * (this.length / 4);
            this.botX = this.x - (this.length / 2);
            this.botY = this.y - (this.length / 2);
            this.topX = this.x + (this.length / 2);
            this.topY = this.y + (this.length / 2);
        }
        //int botX, int botY, int topX, int topY,
        public bool Hit(int dotX, int dotY)
        {
            if (dotX > this.botX && dotX < this.topX &&
                dotY > this.botY && dotY < this.topY)
                return true;

            else

                return false;
        }
        public double shapeScore()
        {
            double equationSquare = this.getShapeType() * this.points / this.area;
            return equationSquare;
        }
        public int getShapeType()
        {
            return 1;
        }
    }
}
