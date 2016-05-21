using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace twofish
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonInput_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = inputBox.Text;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                inputBox.Text = openFileDialog1.FileName;
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = outputBox.Text;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                outputBox.Text = saveFileDialog1.FileName;
        }

        private void UpdateCommandBox(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            if (radioButtonSharp.Checked) sb.Append("/C TwofishSharp");
            if (radioButtonCpp.Checked) sb.Append("/C TwofishCpp");

            if (radioButtonEncrypt.Checked) sb.Append(" --encrypt");
            if (radioButtonDecrypt.Checked) sb.Append(" --decrypt");

            if (radioButtonECB.Checked) sb.Append(" --mode ecb");
            if (radioButtonCBC.Checked) sb.Append(" --mode cbc");

            sb.AppendFormat(" --keysize {0}", comboBox1.Text);

            sb.AppendFormat(" --iv {0}", textBoxIV.Text);
            sb.AppendFormat(" --key {0}", textBoxKey.Text);

            sb.AppendFormat(" --buffer {0}", numericUpDown1.Value);

            sb.AppendFormat(" --input \"{0}\"", inputBox.Text);
            sb.AppendFormat(" --output \"{0}\"", outputBox.Text);

            if (radioButtonSharp.Checked) sb.Append(" >> TwofishSharp.log");
            if (radioButtonCpp.Checked) sb.Append(" >> TwofishCpp.log");

            commandBox.Text = sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var tmp = inputBox.Text;
            inputBox.Text = outputBox.Text;
            outputBox.Text = tmp;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            Process process = Process.Start("cmd", commandBox.Text);

            if (process == null) return;
            process.WaitForExit();

            DateTime end = DateTime.Now;
            var dt = end - start;
            MessageBox.Show(string.Format("Time {0} sec.", dt.TotalSeconds));
        }
    }
}