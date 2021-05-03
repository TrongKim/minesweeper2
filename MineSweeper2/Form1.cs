using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper2
{
    public partial class Form1 : Form
    {

        private static MakeButton[,] setButton = new MakeButton[100, 100];

        private static int[,] ValueThisLocationArray = new int[100, 100];

        public static Save save = new Save();

        public static int number1 = 9;

        public static int number2 = 9;

        public Form1()
        {
            InitializeComponent();

            CreateArrayValue0();

            CreateButton();

            CreateBoom();

            PushNewValueIntoArray();

        }



        public static void Process(object sender, MouseEventArgs e)
        {

            Process2(number1, number2);

        }

        private static void Process2(int SizeX = 9, int SizeY = 9)
        {

            for (int i = 0; i < SizeX; i++)
            {

                for (int j = 0; j < SizeY; j++)
                {

                    if (setButton[i, j].isOpen == 5 && setButton[i, j].BoomAround == 0)
                    {


                        DeQuy(i, j);


                    }
                    else if (setButton[i, j].isOpen == 5 && setButton[i, j].isBoom == true)
                    {

                        HienBOOM(number1, number2);


                    }

                }

            }

        }

        public static void DeQuy(int LocationXclicked, int LocationYclicked)
        {

            for (int ToaDoX = LocationXclicked - 1; ToaDoX <= LocationXclicked + 1; ToaDoX++)
            {

                for (int ToaDoY = LocationYclicked - 1; ToaDoY <= LocationYclicked + 1; ToaDoY++)
                {

                    if ((ToaDoX < number1 & ToaDoY < number2) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == LocationXclicked && ToaDoY == LocationYclicked))
                    {

                        if(setButton[ToaDoX, ToaDoY].isOpen == 0)
                        {

                            setButton[ToaDoX, ToaDoY].Open();

                            setButton[ToaDoX, ToaDoY].isOpen = 4;

                            Xulilannua(number1, number2);

                        }



                    }

                }


            }


        }


        public static void Xulilannua(int SizeX = 9, int SizeY = 9)
        {

            for(int i = 0; i < SizeX; i++)
            {

                for(int j = 0; j < SizeY; j++)
                {

                    if(setButton[i, j].isOpen == 4 && setButton[i, j].BoomAround == 0)
                    {

                        for (int ToaDoX = i - 1; ToaDoX <= i + 1; ToaDoX++)
                        {

                            for (int ToaDoY = j - 1; ToaDoY <= j + 1; ToaDoY++)
                            {
                                //Kiem tra cac toa do xung quanh
                                if ((ToaDoX < SizeX & ToaDoY < SizeY) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == i & ToaDoY == j))
                                {


                                    if(setButton[ToaDoX, ToaDoY].BoomAround != 0 && setButton[ToaDoX, ToaDoY].isOpen == 0)
                                    {

                                        setButton[ToaDoX, ToaDoY].isOpen = 4;

                                        setButton[ToaDoX, ToaDoY].Open();

                                    }
                                    else
                                    {

                                        setButton[ToaDoX, ToaDoY].Open();

                                        setButton[ToaDoX, ToaDoY].isOpen = 4;

                                        Xulilannua2(number1, number2);


                                    }

                                    


                                }

                            }


                        }

                    }

                }

            }

        }

        public static void Xulilannua2(int SizeX = 9, int SizeY = 9)
        {

            for (int i = 0; i < SizeX; i++)
            {

                for (int j = 0; j < SizeY; j++)
                {

                    if (setButton[i, j].isOpen == 4 && setButton[i, j].BoomAround == 0)
                    {

                        for (int ToaDoX = i - 1; ToaDoX <= i + 1; ToaDoX++)
                        {

                            for (int ToaDoY = j - 1; ToaDoY <= j + 1; ToaDoY++)
                            {
                                //Kiem tra cac toa do xung quanh
                                if ((ToaDoX < SizeX & ToaDoY < SizeY) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == i & ToaDoY == j))
                                {


                                    if (setButton[ToaDoX, ToaDoY].BoomAround != 0 && setButton[ToaDoX, ToaDoY].isOpen == 0)
                                    {

                                        setButton[ToaDoX, ToaDoY].isOpen = 4;

                                        setButton[ToaDoX, ToaDoY].Open();

                                    }
                                    else
                                    {

                                        setButton[ToaDoX, ToaDoY].Open();

                                        setButton[ToaDoX, ToaDoY].isOpen = 4;


                                    }




                                }

                            }


                        }

                    }

                }

            }

        }



        public static void HienBOOM(int SizeX = 9, int SizeY = 9)
        {

            for (int i = 0; i < SizeX; i++)
            {

                for (int j = 0; j < SizeY; j++)
                {

                    if (setButton[i, j].isBoom && setButton[i, j].isOpen == 0)
                    {

                        setButton[i, j].Open();

                    }

                    setButton[i, j].Opening = false;

                }

            }

            MessageBox.Show("Bạn đã thua");


        }
   

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)//che do kho
        {

            panel1.Controls.Clear();

            CreateButton(25, 25);//giữ && không gọi các hàm khác

            CreateArrayValue0(25, 25);//giữ không gọi các hàm khác

            CreateBoom(25, 25, 100);//giữ không gọi các hàm khác

            PushNewValueIntoArray(25, 25);//giữ không gọi các hàm khác

            number1 = 25;

            number2 = 25;

        }

        private void button3_Click(object sender, EventArgs e)// che do binh thuong
        {

            panel1.Controls.Clear();

            CreateButton(18, 18);//giữ && không gọi các hàm khác

            CreateArrayValue0(18, 18);//giữ không gọi các hàm khác

            CreateBoom(18, 18, 50);//giữ không gọi các hàm khác

            PushNewValueIntoArray(18, 18);//giữ không gọi các hàm khác

            number1 = 18;

            number2 = 18;

        }

        private void button4_Click(object sender, EventArgs e)// che do de
        {

            panel1.Controls.Clear();

            MessageBox.Show("ơ ai lại chơi chọn chế độ dễ");

            CreateButton();

            CreateArrayValue0();

            CreateBoom();

            PushNewValueIntoArray();

            number1 = 9;

            number2 = 9;

        }

        private void CreateArrayValue0(int SizeX = 9, int SizeY = 9)
        {

            for (int i = 0; i < SizeX; i++)
            {

                for (int j = 0; j < SizeY; j++)
                {

                    ValueThisLocationArray[i, j] = 0;

                }

            }

        }

        private void CreateButton(int SizeX = 9, int SizeY = 9)
        {

            for (int LocationX = 0; LocationX < SizeX; LocationX++)
            {

                for (int LocationY = 0; LocationY < SizeY; LocationY++)
                {

                    setButton[LocationX, LocationY] = new MakeButton();

                    setButton[LocationX, LocationY].Location = new System.Drawing.Point(LocationX * 30, LocationY * 30);

                    setButton[LocationX, LocationY].Size = new System.Drawing.Size(30, 30);

                    setButton[LocationX, LocationY].isOpen = 0;

                    setButton[LocationX, LocationY].Opening = true;



                    panel1.Controls.Add(setButton[LocationX, LocationY]);


                }

            }

        }

        private void CreateBoom(int SizeX = 9, int SizeY = 9, int NumberBoom = 5)
        {

            int IncreBoomInForm = 0;
            //Limit Boom in Window Form 12
            //And Random X, Y in Location Button
            while (IncreBoomInForm < NumberBoom)
            {

                int RandomLocation = new Random().Next(SizeX * SizeY);
                int r = RandomLocation / SizeX;
                int c = RandomLocation % SizeY;
                if (!setButton[r, c].isBoom)
                {

                    setButton[r, c].isBoom = true;
                    IncreBoomInForm++;

                    ValueThisLocationArray[r, c] = 9;

                    for (int ToaDoX = r - 1; ToaDoX <= r + 1; ToaDoX++)
                    {

                        for (int ToaDoY = c - 1; ToaDoY <= c + 1; ToaDoY++)
                        {
                            //Kiem tra cac toa do xung quanh
                            if ((ToaDoX < SizeX & ToaDoY < SizeY) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == r & ToaDoY == c))
                            {


                                ValueThisLocationArray[ToaDoX, ToaDoY]++;


                            }

                        }


                    }




                }


            }

        }

        private void PushNewValueIntoArray(int SizeX = 9, int SizeY = 9)
        {

            for (int i = 0; i < SizeX; i++)
            {


                for (int j = 0; j < SizeY; j++)
                {


                    setButton[i, j].BoomAround = ValueThisLocationArray[i, j];


                }



            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            

        }




        //partial class



    }




}
