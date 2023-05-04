using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAM5
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
             textBox2.Visible = false;
            //  chart1.Visible = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.IsStartedFromZero = true;
            chart1.ChartAreas[0].AxisX.IntervalOffset = 0;
            chart1.ChartAreas[0].AxisY.IntervalOffset = 0;

            string code = textBox1.Text;
            string[] SS = new string[50];

            int k = 0;
            int i;
            for (i = 0; i < code.Length - 1; i += 2)
            {
                string S1 = code.Substring(i, 2);
                SS[k++] = S1;
            }

            //for (i = 0; i < SS.Length; i++)
            //{
            //    textBox2.Text += SS[i] + " ";
            //}


            SS = SS.Where(q => q != null).ToArray();


            for (i = 0; i < SS.GetLength(0); i++) // кодирование входного сигнала 
            {

                switch (SS[i])
                {
                    case "00":
                        SS[i] = "-2";
                        break;
                    case "01":
                        SS[i] = "-1";
                        break;
                    case "10":
                        SS[i] = "1";
                        break;
                    case "11":
                        SS[i] = "2";
                        break;
                }
            }

            int[] intArray = new int[SS.Length];

            for (i = 0; i < SS.Length; i++) // конвертирование закодированного сигнала в массив чисел
            {
                if (SS[i] != null)
                    intArray[i] = int.Parse(SS[i]);
            }

            int[] intA = new int[SS.Length * 2];

            int a = 0;
            int j = 0;
            while (a < intArray.Length) // дублирование закодированного массива 
            {
                while (j < intA.Length)
                {

                    intA[j] = intArray[a];
                    j++;
                    intA[j] = intArray[a];
                    a++;
                    j++;
                }

            }

            Array.Resize(ref intA, intA.Length + 1);
            int z = 0;
            z = intA[intA.Length - 2];
            intA[intA.Length - 1] = z;

            int[] x = new int[intA.Length];
            for (i = 1; i < x.Length; i++)
            {
                x[i] = i;
            }

            for (i = 0; i < intA.GetLength(0); i++)
            {
                if (intA[i] != 0)
                    chart1.Series["Series1"].Points.DataBindXY(x, intA);
            }
           // chart1.ChartAreas[0].AxisX.Maximum = x.Length;
            chart1.Series[0].BorderWidth = 3;
            //   chart1.Visible = true;
            chart1.Series[0].Color = Color.Black;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string SS = textBox1.Text;
            string[] W = SS.Split(' ');

            int[] intArray = new int[SS.Length];

            for (int i = 0; i < SS.Length; i++) // конвертирование массива строк в массив чисел 
            {
                intArray[i] = Convert.ToInt32(SS[i].ToString());
            }

            
                Array.Resize(ref intArray, intArray.Length + 1);
                int dob = 0;
                dob = intArray[intArray.Length - 2];
                intArray[intArray.Length - 1] = dob;
            


                for (int i = 0; i < intArray.Length; i++)
                {
                    textBox2.Text += intArray[i] + " ";
                }
                int[] x = new int[intArray.Length];
                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = i;
                }
                chart1.ChartAreas[0].AxisX.Maximum = x.Length - 1;
                chart2.Series["Series1"].Points.DataBindXY(x, intArray);
                chart2.Series[0].BorderWidth = 3;
                chart2.Series[0].Color = Color.Black;
      



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == '0' || e.KeyChar == '1' || e.KeyChar == (char)Keys.Back)

                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }
    }





