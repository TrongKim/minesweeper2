using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var setButton = new MakeButton[9, 9];

            int[,] ValueThisLocationArray = new int[9, 9];

            Save save = new Save();



            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {

                    ValueThisLocationArray[i, j] = 0;

                }

            }

            for (int LocationX = 0; LocationX < 9; LocationX++)
            {

                for (int LocationY = 0; LocationY < 9; LocationY++)
                {

                    setButton[LocationX, LocationY] = new MakeButton();

                    setButton[LocationX, LocationY].Location = new System.Drawing.Point(LocationX * 30, LocationY * 30);

                    setButton[LocationX, LocationY].Size = new System.Drawing.Size(30, 30);

                    setButton[LocationX, LocationY].isOpen = true;



                    this.Controls.Add(setButton[LocationX, LocationY]);


                }

            }

            int IncreBoomInForm = 0;
            //Limit Boom in Window Form 12
            //And Random X, Y in Location Button
            while (IncreBoomInForm < 5)
            {

                int RandomLocation = new Random().Next(9 * 9);
                int r = RandomLocation / 9;
                int c = RandomLocation % 9;
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
                            if ((ToaDoX < 9 & ToaDoY < 9) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == r & ToaDoY == c))
                            {


                                ValueThisLocationArray[ToaDoX, ToaDoY]++;


                            }

                        }


                    }




                }


            }

            #region gán giá trị cho từng nút theo tọa độ
            for (int i = 0; i < 9; i++)
            {


                for (int j = 0; j < 9; j++)
                {


                    setButton[i, j].BoomAround = ValueThisLocationArray[i, j];


                }



            }
            #endregion

            for(int i = 0; i < 9; i++)
            {

                for(int j = 0; j < 9; j++)
                {

                    setButton[i, j].Click += Process;

                    save.X = i;

                    save.Y = j;


                }

            }

            
            void Process(object sender, EventArgs e)
            {

                setButton[save.X, save.Y].isOpen = false;

                for (int i = 0; i < 9; i++)
                {

                    for (int j = 0; j < 9; j++)
                    {



                    }

                }

            }
            

            void DeQuy(int LocationXclicked, int LocationYclicked)
            {

                for (int ToaDoX = LocationXclicked - 1; ToaDoX <= LocationXclicked + 1; ToaDoX++)
                {

                    for (int ToaDoY = LocationYclicked - 1; ToaDoY <= LocationYclicked + 1; ToaDoY++)
                    {
                        
                        if ((ToaDoX < 9 & ToaDoY < 9) & (ToaDoX >= 0 & ToaDoY >= 0) & !(ToaDoX == LocationXclicked && ToaDoY == LocationYclicked))
                        {


                            setButton[ToaDoX, ToaDoY].Open();

                            if(setButton[ToaDoX, ToaDoY].BoomAround == 0)
                            {

                                /*DeQuy(ToaDoX, ToaDoY);*/

                            }
                            


                        }

                    }


                }

            }

        }

    }
}
