using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper2
{
    class MakeButton : Button
    {

        public bool isBoom = false;
        public int BoomAround = 0;
        public bool isOpen;

        public MakeButton()
        {

            this.MouseDown += new MouseEventHandler(ButtonClicked);

        }

        public void ButtonClicked(object sender, MouseEventArgs e)
        {

            Open();

            MakeButton btn = sender as MakeButton;
            btn.isOpen = false;

        }


        public void Open()
        {
            
            if (isBoom)
            {

                BOOM();

            }
            else
            {

                switch (BoomAround)
                {

                    case 0:
                        isBoomAround0();
                        break;

                    case 1:
                        isBoomAround1();
                        break;

                    case 2:
                        isBoomAround2();
                        break;

                    case 3:
                        isBoomAround3();
                        break;

                    case 4:
                        isBoomAround4();
                        break;

                    case 5:
                        isBoomAround5();
                        break;

                    case 6:
                        isBoomAround6();
                        break;

                    case 7:
                        isBoomAround7();
                        break;

                    case 8:
                        isBoomAround8();
                        break;




                }

                isOpen = false;


            }



        }




        #region set up Boom
        private void BOOM()
        {

            this.BackColor = Color.Red;
            this.Text = "@";

        }

        private void isBoomAround0()
        {

            this.BackColor = Color.Gray;
            this.Text = "";

        }

        private void isBoomAround1()
        {

            this.BackColor = Color.Blue;
            this.Text = "1";

        }

        private void isBoomAround2()
        {

            this.BackColor = Color.Green;
            this.Text = "2";

        }

        private void isBoomAround3()
        {

            this.BackColor = Color.Purple;
            this.Text = "3";

        }

        private void isBoomAround4()
        {

            this.BackColor = Color.Orange;
            this.Text = "4";

        }

        private void isBoomAround5()
        {

            this.BackColor = Color.OrangeRed;
            this.Text = "5";

        }

        private void isBoomAround6()
        {

            this.BackColor = Color.OrangeRed;
            this.Text = "6";

        }

        private void isBoomAround7()
        {

            this.BackColor = Color.OrangeRed;
            this.Text = "7";

        }

        private void isBoomAround8()
        {

            this.BackColor = Color.OrangeRed;
            this.Text = "8";

        }

        #endregion




    }


}

