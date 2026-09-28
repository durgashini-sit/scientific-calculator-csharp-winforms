using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Media;

namespace Calculator_212017P
{
    public partial class MainForm_212017P : Form
    {

        double value = 0;
        string operation = "";
        bool operation_pressed = false;
        SpeechSynthesizer syn = new SpeechSynthesizer();

        public MainForm_212017P()
        {
            InitializeComponent();
        }

        private void lblID_Click(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0]; 
            Clipboard.SetText(attribute.Value.ToString());
        }

        private void btn_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            { SystemSounds.Hand.Play(); }

            if ((result.Text == "0")||(operation_pressed))
                result.Clear();

            operation_pressed = false;
            Button b = (Button)sender;
            if (b.Text == ".")
            {
                if (!result.Text.Contains("."))
                {
                    result.Text = result.Text + b.Text;
                    equation.Text = equation.Text + b.Text;

                }

            }
            else
            {
                result.Text = result.Text + b.Text;
                equation.Text = equation.Text + b.Text;
            }

        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            result.Text = "0";
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Hand.Play();
            }

            if (value != 0)
            {
                btnequal.PerformClick();
                operation_pressed = true;
                operation = b.Text;
                equation.Text = equation.Text + " " + operation + " ";

            }
            else
            {
                operation = b.Text;
                value = double.Parse(result.Text);
                operation_pressed = true;
                equation.Text = equation.Text + " " + operation + " ";

            }
        }

        private void btnequal_Click(object sender, EventArgs e)
        {


            switch (operation) {

                case "+":
                    result.Text = (value + double.Parse(result.Text)).ToString();
                    break;

                case "−":
                    result.Text = (value - double.Parse(result.Text)).ToString();
                    break;

                case "×":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;

                case "÷":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    break;

                case "*":
                    result.Text = (value * double.Parse(result.Text)).ToString();
                    break;

                case "/":
                    result.Text = (value / double.Parse(result.Text)).ToString();
                    break;

                case "%":
                    result.Text = (value % double.Parse(result.Text)).ToString();
                    break;

                case "√ ":
                    result.Text = Math.Sqrt(value).ToString();
                    break;

                case "x²":
                    result.Text = Math.Pow(value, 2).ToString();
                    break;

                case "1/x":
                    result.Text = Math.Pow(value, -1).ToString();
                    break;

                case "log":
                    result.Text = Math.Log10(value).ToString();
                    break;

                case "ln":
                    result.Text = Math.Log(value).ToString();
                    break;

                case "10ˣ":
                    result.Text = Math.Pow(10, value).ToString();
                    break;

                case "eˣ":
                    result.Text = Math.Exp(value).ToString();
                    break;

                case "sin":
                    result.Text = Math.Sin(value).ToString("N6");
                    break;

                case "cos":
                    result.Text = Math.Cos(value).ToString("N6");
                    break;

                case "tan":
                    result.Text = Math.Tan(value).ToString("N6");
                    break;
                default:
                    break;
            }

            if (labeldeg.Text == "DEG")
            {
                switch(operation)
                {
                    case "sin":
                        result.Text = Math.Sin(value*Math.PI/180).ToString("N6");
                        break;

                    case "cos":
                        result.Text = Math.Cos(value * Math.PI / 180).ToString("N6");
                        break;

                    case "tan":
                        result.Text = Math.Tan(value * Math.PI / 180).ToString("N6");
                        break;
                    default:
                        break;


                }
            }


            value = double.Parse(result.Text);
            operation = "";
            
            if (labelanc.Text == "ANC ON")
            { syn.Speak("" + result.Text); }
            

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            result.Text = "0";
            value = 0;
            equation.Text = "";
        }

        private void MainForm_212017P_Load(object sender, EventArgs e)
        {

        }

        private void equation_Click(object sender, EventArgs e)
        {

        }

        private void btn_plus_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Hand.Play();
            }

            result.Text = (-1 * double.Parse(result.Text)).ToString();
        }

        private void result_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndeg_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            if (btndeg.Text == "DEG")
            {
                labeldeg.Text = "DEG";
                btndeg.Text = "RAD";
                btndeg.ForeColor = Color.FromArgb(5, 100, 204);
                btndeg.BackColor = Color.LightBlue;
            }
            else
            {
                labeldeg.Text = "RAD";
                btndeg.Text = "DEG";
                btndeg.ForeColor = Color.LightBlue;
                btndeg.BackColor = Color.FromArgb(5, 100, 204);
            }
        }

        private void btnstd_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            if (btnstd.Text == "STD")
            {
                lablelstd.Text = "STD";
                btnstd.Text = "SCI";

                btntan.Visible = false;
                btnsin.Visible = false;
                btncos.Visible = false;
                btnlog.Visible = false;
                btnln.Visible = false;
                btn10x.Visible = false;
                btnex.Visible = false;
                btnpercentage.Visible = false;
                btn1slashx.Visible = false;
                btnSqrt.Visible = false;
                btnsq.Visible = false;

                btnstd.ForeColor = Color.LightBlue;
                btnstd.BackColor = Color.FromArgb(5, 100, 204);
            }
            else
            {
                lablelstd.Text = "SCI";
                btnstd.Text = "STD";

                btntan.Visible = true;
                btnsin.Visible = true;
                btncos.Visible = true;
                btnlog.Visible = true;
                btnln.Visible = true;
                btn10x.Visible = true;
                btnex.Visible=true;
                btnpercentage.Visible = true;
                btn1slashx.Visible = true;
                btnSqrt.Visible = true;
                btnsq.Visible = true;

                btnstd.ForeColor = Color.FromArgb(5, 100, 204);
                btnstd.BackColor = Color.LightBlue;
            }
        }

        private void btnbs_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            if (equation.Text.Length > 0)
            {
                equation.Text = equation.Text.Remove(equation.Text.Length - 1, 1);
               
            }
            if (equation.Text.Length == 0)
            {
                result.Text = "0";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnspk_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            if (labelspk.Text == "SPEAKER OFF")
            {
                labelspk.Text = "SPEAKER ON";
                btnspk.ForeColor = Color.FromArgb(5, 100, 204);
                btnspk.BackColor = Color.LightBlue;
            }
            else
            {
                labelspk.Text = "SPEAKER OFF";
                btnspk.ForeColor = Color.LightBlue;
                btnspk.BackColor = Color.FromArgb(5, 100, 204);
            }
        }

        private void btncopy_Click(object sender, EventArgs e)
        {
            if (labelspk.Text == "SPEAKER ON")
            {
                SystemSounds.Exclamation.Play();
            }

            Clipboard.SetText(result.Text);
            MessageBox.Show("Result Copied");

        }

        private void MainForm_212017P_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar.ToString())
            {
                case "0":
                    btn0.PerformClick();
                    break;
                case "1":
                    btn1.PerformClick();
                    break;
                case "2":
                    btn2.PerformClick();
                    break;
                case "3":
                    btn3.PerformClick();
                    break;
                case "4":
                    btn4.PerformClick();
                    break;
                case "5":
                    btn5.PerformClick();
                    break;
                case "6":
                    btn6.PerformClick();
                    break;
                case "7":
                    btn7.PerformClick();
                    break;
                case "8":
                    btn8.PerformClick();
                    break;
                case "9":
                    btn9.PerformClick();
                    break;
                case "+":
                    btnadd.PerformClick();
                    break;
                case "-":
                    btnminus.PerformClick();
                    break;
                case "*":
                    btnastrick.PerformClick();
                    break;
                case "/":
                    btnslash.PerformClick();
                    break;
                case "=":
                    btnequal.PerformClick();
                    break;
                case ".":
                    btnDot.PerformClick();
                    break;
                default: 
                    break;
            }
        }

        private void btnanc_Click(object sender, EventArgs e)
        {
            if (labelanc.Text == "ANC ON")
            {
                SystemSounds.Exclamation.Play();
            }

            if (labelanc.Text == "ANC OFF")
            {
                labelanc.Text = "ANC ON";
                btnanc.ForeColor = Color.FromArgb(5, 100, 204);
                btnanc.BackColor = Color.LightBlue;
            }
            else
            {
                labelanc.Text = "ANC OFF";
                btnanc.ForeColor = Color.LightBlue;
                btnanc.BackColor = Color.FromArgb(5, 100, 204);
            }
        }
    }
}
