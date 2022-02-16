using System;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;


using System.Text.RegularExpressions;
using System.Threading;


namespace Lab_V2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //Lägga till i game
            //List<double> shapeScoreh = new List<double>();
            //List<double> shapeScorem = new List<double>();



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

            //string[] listVariables = Regex.Split(substringVariables, @";|,");
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

            int dotX = 0;
            int dotY = 0;

            List<Circle> hitCircle = new List<Circle>();
            List<Circle> missCircle = new List<Circle>();

            foreach (Circle c in shapeCircle)
            {
                if (c.Hit(dotX, dotY))
                {
                    hitCircle.Add(c);
                }
                else
                {
                    missCircle.Add(c);
                }
            }

            //if (Hit(circleX, circleY, rad, dotX, dotY))
            //{
            //    Console.WriteLine("Inuti cirkel");
            //    var eqCircleH = Circle.getShapeType * indexPoints / AreaCircle;
            //    shapeScoreh.Add(eqCircleH);
            //}
            //else
            //{
            //    Console.WriteLine("Utanför cirkel");
            //    var eqCircleM = inputShapeTypeCircle * instancePointsCircle / AreaCircle;
            //    shapeScorem.Add(eqCircleM);
            //}



            /*
            if (listShape1.Equals("CIRCLE"))
            {
                listOfShapes.Add(new Circle(listShape1[1], listShape1[2], listShape1[3], listShape1[4]));
            }

            if (listShape1.Equals("CIRCLE"))
            {
                listOfShapes.Add(new Circle(listShape1[1], newList.indexY, Shapes.indexLength, Shapes.indexPoints));
            }
            else if (Shapes.Equals("SQUARE"))
            {
                listOfShapes.Add(new Square(Shapes.indexX, Shapes.indexY, Shapes.indexLength, Shapes.indexPoints));
            }
           
            */




        }




        //int returnShape(List<string> listShape1)
        //{

        //loopen slutar när den läser circle


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


        public Square(int indexX, int indexY, int indexLength, int indexPoints)
        {
            this.x = indexX;
            this.y = indexY;
            this.length = indexLength;
            this.points = indexPoints;
        }

        bool Hit(int x1, int y1, int x2,
    int y2, int SquareX, int SquareY)
        {
            if (SquareX > x1 && SquareX < x2 &&
                SquareY > y1 && SquareY < y2)
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
