using System.Diagnostics.Eventing.Reader;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public static string GlobalExpression = "";//����һ���ַ������ÿ�ΰ������µ�ֵ
        public Form1()
        {
            InitializeComponent();
        }
        //����������ַ�
        public void AppendNumber(string num)
        {
            string vaildStr = ".,0,1,2,3,4,5,6,7,8,9";
            //IndexOf�����ص�ǰ�ַ����ַ����е�λ��
            if (vaildStr.IndexOf(num) > -1)//���ַ�����
            {
                GlobalExpression += num;
            }
            else//˵���Ƿ���
            {
                //���Ĭ��û���������֣��������㰴����������
                if (GlobalExpression != "")
                {
                    string lastStr = GlobalExpression.Substring(GlobalExpression.Length - 1, 1);//��ֵ�ַ����е����һλ
                    if (vaildStr.IndexOf(lastStr) > -1)//������һλ�����֣����֮ǰ��������һ�飬��׷���µļ������
                    {
                        GlobalExpression = Operation(num);
                    }
                    if (num == "^")
                    {
                        string numberString = GlobalExpression.Replace("^", "");
                        int.TryParse(numberString, out int number);
                        GlobalExpression = (number * number).ToString();
                    }
                    if (num == "d")
                    {
                        GlobalExpression = GlobalExpression.Remove(GlobalExpression.Length - 2);
                    }
                    if (num == "r")
                    {
                        GlobalExpression = GlobalExpression.Remove(GlobalExpression.Length - 1);
                        double number = Convert.ToDouble(GlobalExpression);
                        double result = Math.Sqrt(number);
                        GlobalExpression = result.ToString();
                    }
                    if (num == "H")
                    {
                        GlobalExpression = GlobalExpression.Remove(GlobalExpression.Length - 1);
                        double number = Convert.ToDouble(GlobalExpression);
                        GlobalExpression = (1/ number).ToString();
                    }

                }
            }
            //GlobalExpression += num;//�ַ��ۼ�
            Expression.Text = GlobalExpression;//��ʾ���������
        }
        //��������
        public string Operation(string num)//���㷽��
        {
            //Expression.Text = "SS";
            if (GlobalExpression.Contains("+"))
            {
                //ͨ��split�����и��ַ������õ�һ���ַ�������
                string[] temps = GlobalExpression.Split(new char[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
                GlobalExpression = (Convert.ToDecimal(temps[0]) + Convert.ToDecimal(temps[1])).ToString();
            }
            else if (GlobalExpression.Contains("-"))
            {
                string[] temps = GlobalExpression.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                GlobalExpression = (Convert.ToDecimal(temps[0]) - Convert.ToDecimal(temps[1])).ToString();
            }
            else if (GlobalExpression.Contains("*"))
            {
                string[] temps = GlobalExpression.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
                GlobalExpression = (Convert.ToDecimal(temps[0]) * Convert.ToDecimal(temps[1])).ToString();
            }
            else if (GlobalExpression.Contains("/"))
            {
                string[] temps = GlobalExpression.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                GlobalExpression = (Convert.ToDecimal(temps[0]) / Convert.ToDecimal(temps[1])).ToString();
            }
            else if (GlobalExpression.Contains("%"))
            {
                string[] temps = GlobalExpression.Split(new char[] { '%' }, StringSplitOptions.RemoveEmptyEntries);
                GlobalExpression = (Convert.ToDecimal(temps[0]) % Convert.ToDecimal(temps[1])).ToString();
            }
            else if (GlobalExpression.Contains("^"))
            {
                string numberString = GlobalExpression.Replace("^", "");
                int.TryParse(numberString, out int number);
                GlobalExpression = (number * number).ToString();
                //GlobalExpression = "TEST";
                //string[] temps = GlobalExpression.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                //GlobalExpression = (Convert.ToDecimal(temps[0]) * Convert.ToDecimal(temps[0])).ToString();
            }
            //������ǵȺţ�������ʾ������׷���ַ���
            if (num != "=")
            {
                GlobalExpression += num;
                Expression.Text = "SS";
            }
            return GlobalExpression;
        }

        #region ����
        private void button_Click(object sender, EventArgs e)
        {
            AppendNumber("%");
        }

        private void button24_Click(object sender, EventArgs e)
        {
            GlobalExpression = "";
            Expression.Text = "";
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //�������������¼����ı�������ʾ�����
            GlobalExpression = "";
            Expression.Text = "";
        }

        private void button22_Click(object sender, EventArgs e)
        {
            AppendNumber("d");
            //GlobalExpression = GlobalExpression.Remove(GlobalExpression.Length - 1);
        }
        #endregion



        private void button_1_Click(object sender, EventArgs e)
        {
            AppendNumber("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            AppendNumber("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            AppendNumber("3");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            AppendNumber("4");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AppendNumber("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            AppendNumber("6");
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            AppendNumber("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            AppendNumber("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            AppendNumber("9");
        }

        private void button_8_Click_1(object sender, EventArgs e)
        {

        }

        private void button_9_Click_1(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            AppendNumber("0");
        }

        private void button_Equal_Click(object sender, EventArgs e)
        {
            Expression.Text = Operation("=");
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            //AppendNumber("+");
            AppendNumber("CC");
        }

        private void button_add_Click_1(object sender, EventArgs e)
        {
            AppendNumber("+");
        }

        private void Expression1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_MUL_Click(object sender, EventArgs e)
        {
            AppendNumber("*");
        }

        private void button_SUB_Click(object sender, EventArgs e)
        {
            AppendNumber("-");
        }

        private void button_Square_Click(object sender, EventArgs e)
        {
            AppendNumber("^");
        }

        private void button_Root_Click(object sender, EventArgs e)
        {
            AppendNumber("r");
        }

        private void button_DIV_Click(object sender, EventArgs e)
        {
            AppendNumber("/");
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            AppendNumber("H");
        }
    }
}
