using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Units are entered in meters.\n" +
            "Enter the object points (minimum 4):\n");

        Vector3D scaleVector = new Vector3D();
        List<Vector3D> objectList = new List<Vector3D>();
        bool exitLoop = false;
        do
        {
            Console.WriteLine("Point: " + (objectList.Count + 1) + "\n");

            Vector3D tempPoint = GetPoint();
            objectList.Add(tempPoint);
            if (objectList.Count >= 4)
            {
                Console.Write("Add another point? (Y or N): ");
                string answer = Console.ReadLine();
                if (answer.ToUpper()[0] != 'Y')
                    exitLoop = true;
            }
            Console.Clear();
        } while (!exitLoop);

        List<Vector3D> newList;
        bool transformLoop = true;

        do
        {
            Console.Clear();
            Console.WriteLine("1: Translation.");
            Console.WriteLine("2: Raw Scaling.");
            Console.WriteLine("3: Center Scaling.");
            Console.Write("Please Enter Transformation Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            string choiceMade;

            newList = new List<Vector3D>();
            switch (choice)
            {
                case 1:
                    choiceMade = "Translation";
                    Console.WriteLine("Choice: " + choiceMade);
                    scaleVector = GetPoint();
                    newList = Vector3D.Translation(objectList, scaleVector);
                    break;
                case 2:
                    choiceMade = "Raw Scaling";
                    Console.WriteLine("Choice: " + choiceMade);
                    scaleVector = GetScaleVector();
                    newList = Vector3D.RawScaling(objectList, scaleVector);
                    break;
                case 3:
                    choiceMade = "Center Scaling";
                    Console.WriteLine("Choice: " + choiceMade);
                    scaleVector = GetScaleVector();
                    newList = Vector3D.CenterScaling(objectList, scaleVector);
                    break;
                default:
                    choiceMade = "error.";
                    break;
            }
            if (choice == 1 || choice == 2 || choice == 3)
            {
                Console.WriteLine("Choice: " + choiceMade);
                Console.WriteLine("vector given: <" + scaleVector.XValue + ", " +
                    scaleVector.YValue + ", " + scaleVector.ZValue + ">.\n");
                int count = 1;
                foreach (Vector3D item in newList)
                {
                    Console.WriteLine("Point " + count + ": <" + item.XValue + ", "
                        + item.YValue + ", " + item.ZValue + ">.");
                    count++;
                }
            }
            Console.Write("Enter new transformation? (Y or N): ");
            string check = Console.ReadLine();
            if (check.ToUpper()[0] != 'Y')
                transformLoop = false;
            else
                objectList = newList;
        } while (transformLoop);
    }


    static Vector3D GetScaleVector()
    {
        double getX, getY, getZ;
        getX = getY = getZ = 0;
        Vector3D scaleVector = new Vector3D();

        Console.Write("Please Enter X scale factor: ");
        getX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Y scale factor: ");
        getY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Z scale factor: ");
        getZ = Convert.ToDouble(Console.ReadLine());

        scaleVector.SetRectGivenRect(getX, getY, getZ);
        return scaleVector;
    }
    static Vector3D GetPoint()
    {
        double getX, getY, getZ;
        getX = getY = getZ = 0;
        Vector3D pointVector = new Vector3D();

        Console.Write("Please Enter X for point: ");
        getX = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Y for point: ");
        getY = Convert.ToDouble(Console.ReadLine());
        Console.Write("Please Enter Z for point: ");
        getZ = Convert.ToDouble(Console.ReadLine());

        pointVector.SetRectGivenRect(getX, getY, getZ);
        return pointVector;
    }
}
