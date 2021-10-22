using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_8
{
    public class Table
    {
        public string[,] Matrix;
        public int f;
        public int h;
        public int g;

        public Table()
        {

        }
        public Table(string[,] newMatrix, int newF, int newH, int newG)
        {
            this.Matrix = newMatrix;
            this.f = newF;
            this.h = newH;
            this.g = newG;
        }

        public void CheckPosition()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (this.Matrix[i, j] != Convert.ToString(i * 3 + j + 1))
                    {
                        this.h++;
                    }
                }
            }
            this.f = this.h + this.g;
        }

        public void TransformMatrix(int x1, int y1, int x2, int y2)
        {
            string temp = this.Matrix[x1, y1];
            this.Matrix[x1, y1] = this.Matrix[x2, y2];
            this.Matrix[x2, y2] = temp;
        }

        public void OutputMatrix()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(this.Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
    class Program
    {
        static Table minTable = new Table();
        static void OutputMatrix(string[,] Matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void FindMinH(List<Table> tables)
        {
            int minH = tables[0].h;
            minTable = tables[0];
            for (int i = 1; i < tables.Count; i++)
            {
                if (minH > tables[i].h)
                {
                    minH = tables[i].h;
                    minTable = tables[i];
                }
            }
        }
        static void Main(string[] args)
        {
            string[,] Matrix = new string[3, 3] { { "2", "*", "1"}, { "5", "4", "3"}, { "6", "7", "8"} };

            Table tableInitial = new Table(Matrix, 0, 0, 0);
            tableInitial.CheckPosition();
            OutputMatrix(Matrix);

            Console.WriteLine();

            Console.WriteLine("f = " + tableInitial.f);

            List<Table> tables = new List<Table>();

            List<Table> ClosedList = new List<Table>();

            while (tableInitial.h != 1)
            {
                foreach (var item in tableInitial.Matrix)
                {
                    if (tableInitial.Matrix[1, 1] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(1, 1, 0, 1);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(1, 1, 1, 0);
                        table2.CheckPosition();

                        string[,] tempMatrix3 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix3[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table3 = new Table(tempMatrix3, 0, 0, tableInitial.g++);
                        table3.TransformMatrix(1, 1, 1, 2);
                        table3.CheckPosition();

                        string[,] tempMatrix4 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix4[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table4 = new Table(tempMatrix4, 0, 0, tableInitial.g++);
                        table4.TransformMatrix(1, 1, 2, 1);
                        table4.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2, table3, table4 });
                        FindMinH(tables);

                        foreach (var table in ClosedList)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; i < 3; i++)
                                {
                                    if(table.Matrix[i, j] == minTable.Matrix[i, j])
                                    {
                                        goto label2;
                                    }
                                    else
                                    {
                                        goto label1;
                                    }
                                }
                            }
                            label1:;
                        }


                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        label2:;
                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[0, 1] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(0, 1, 0, 0);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(0, 1, 1, 1);
                        table2.CheckPosition();

                        string[,] tempMatrix3 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix3[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table3 = new Table(tempMatrix3, 0, 0, tableInitial.g++);
                        table3.TransformMatrix(0, 1, 0, 2);
                        table3.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2, table3 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[1, 0] == "*")
                    {

                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }
                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(1, 0, 0, 0);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(1, 0, 2, 0);
                        table2.CheckPosition();

                        string[,] tempMatrix3 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix3[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table3 = new Table(tempMatrix3, 0, 0, tableInitial.g++);
                        table3.TransformMatrix(1, 0, 1, 1);
                        table3.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2, table3 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[2, 1] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(2, 1, 2, 0);
                        table1.CheckPosition();

                        Console.WriteLine(table1.h);

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(2, 1, 2, 2);
                        table2.CheckPosition();

                        string[,] tempMatrix3 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix3[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table3 = new Table(tempMatrix3, 0, 0, tableInitial.g++);
                        table3.TransformMatrix(2, 1, 1, 1);
                        table3.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2, table3 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[1, 2] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g + 1);
                        table1.TransformMatrix(1, 2, 0, 2);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g + 1);
                        table2.TransformMatrix(1, 2, 2, 2);
                        table2.CheckPosition();

                        string[,] tempMatrix3 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix3[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table3 = new Table(tempMatrix3, 0, 0, tableInitial.g + 1);
                        table3.TransformMatrix(1, 2, 1, 1);
                        table3.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2, table3 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[0, 0] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }
                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(0, 0, 0, 1);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(0, 0, 1, 0);
                        table2.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[0, 2] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }
                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(0, 2, 0, 1);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(0, 2, 1, 2);
                        table2.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[2, 0] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }
                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(2, 0, 1, 0);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(2, 0, 2, 1);
                        table2.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                    else if (tableInitial.Matrix[2, 2] == "*")
                    {
                        string[,] tempMatrix1 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix1[i, j] = tableInitial.Matrix[i, j];
                            }
                        }
                        Table table1 = new Table(tempMatrix1, 0, 0, tableInitial.g++);
                        table1.TransformMatrix(2, 2, 1, 2);
                        table1.CheckPosition();

                        string[,] tempMatrix2 = new string[3, 3];
                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                tempMatrix2[i, j] = tableInitial.Matrix[i, j];
                            }
                        }

                        Table table2 = new Table(tempMatrix2, 0, 0, tableInitial.g++);
                        table2.TransformMatrix(2, 2, 2, 1);
                        table2.CheckPosition();

                        tables.AddRange(new Table[] { table1, table2 });
                        FindMinH(tables);

                        Console.WriteLine("MIN");
                        Console.WriteLine();
                        minTable.OutputMatrix();

                        tableInitial = minTable;

                        ClosedList.Add(minTable);

                        tables.Clear();

                        break;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
