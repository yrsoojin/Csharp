using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcPrj
{
    public partial class Form1 : Form
    {
        
        string[] strTotal;
        string Strtotal;
        Boolean count;
        
        public Form1()
        {
            InitializeComponent();
        }

        //numeric button action
        private void button20_Click(object sender, EventArgs e)
        {
            if (count==true)
            {
                textBox.Text = "";
                textResult.Text = "";
            }
            count = false;
            Button a = (Button)sender;
            string submit = a.Text; //버튼 스트링따오기

            textResult.Text = submit;
            textBox.Text += submit;
            Strtotal = textBox.Text;



        }

        //operation button action
        private void button1_Click(object sender, EventArgs e)
        {
            textResult.Text = "";
            
            Button oops = (Button)sender;
            string ops = oops.Text;
            textBox.Text += ops;
            
            
        }

        //result(=) button action 
        private void button17_Click(object sender, EventArgs e)
        {
            count = true;
            Strtotal = textBox.Text;
            strTotal = Strtotal.Split('+', '-', '*', '/'); //split해서 바로 배열에 넣어주기

            double[] num = new double [strTotal.Length];
            char[] op = new char[strTotal.Length - 1];
            for (int i = 0; i <strTotal.Length; i++ ) {
                
                num[i] = Convert.ToDouble(strTotal[i]); //숫자배열에 넣어줌
                Console.WriteLine(num[i]);
            }

            int k = 0;
            for(int i=0; i < Strtotal.Length; i++) //op배열
            {
                if (Strtotal[i].Equals('+'))  // java에서는 Strtotal.charAt(i) 였다.
                {
                    op[k++] = '+';
                }
                else if(Strtotal[i] == '-')
                {
                    op[k++] = '-';
                }
                else if (Strtotal[i] == '*')
                {
                    op[k++] = '*';
                }
                else if (Strtotal[i] == '/')
                {
                    op[k++] = '/';
                }
            }

            for(int i=0; i<op.Length; i++)
            {
                if (op[i] == '+')
                {
                    num[i+1] = num[i] + num[i + 1];                    
                }
                else if(op[i] == '-')
                {
                    num[i+1] = num[i] - num[i + 1];
                }
                else if (op[i] == '*')
                {
                    num[i+1] = num[i] * num[i + 1];
                }
                else if (op[i] == '/')
                {
                    num[i+1] = num[i] / num[i + 1];
                }
            }
            textResult.Text = Convert.ToString(num[num.Length-1]);
            Console.WriteLine("Answer : "+ textResult.Text);
            
        }

        

        //delete button action
        private void button2_Click(object sender, EventArgs e)
        {
            Button del = (Button)sender;
            string dels = del.Text;
            switch (dels)
            {
                case "delete": //맨뒤의 한글자를 지운다.
                    textBox.Text = textBox.Text.Remove(textBox.Text.Length - 1);
                    break;
                case "CE": //현재 화면의 숫자를 0으로
                    textResult.Text = "0";
                    break;
                case "C": //모든 숫자를 초기화 
                    textBox.Text = "";
                    textResult.Text = "0";
                    Strtotal = "";
                    break;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
           
            textBox.Text = Strtotal + " * " + Strtotal;
            textResult.Text = Convert.ToString(int.Parse(Strtotal) * int.Parse(Strtotal));
            Strtotal = textResult.Text;
        }
    }
}
