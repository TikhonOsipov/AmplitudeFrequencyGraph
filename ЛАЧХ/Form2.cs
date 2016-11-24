using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ЛАЧХ
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private List<String> data;

        public void setData(List<String> data)
        {
            this.data = data;
            for (int i = 0; i < data.Count; i++)
            {
                this.listBox1.Items.Add(data[i]);
            }
        }
    }
}
