using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIThreadExample
{
    public partial class Form1 : Form
    {
        private int count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateMessage(string message)
        {
            resultLabel.Text = String.Format("{0} ({1}) at {2}", message, count++, DateTime.Now);
        }

        private void clickMeButton_Click(object sender, EventArgs e)
        {
            Task task = Task.Factory.StartNew(LongTask);
        }

        private void LongTask()
        {
            System.Threading.Thread.Sleep(1000);
            UpdateMessage("testing");
        }

        private void Finished(IAsyncResult iar)
        {
            Func<string> task = (Func<string>)iar.AsyncState;
            ShowResults(task.EndInvoke(iar));
        }

        private void ShowResults(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(ShowResults), value);
                return;
            }
            UpdateMessage(value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
