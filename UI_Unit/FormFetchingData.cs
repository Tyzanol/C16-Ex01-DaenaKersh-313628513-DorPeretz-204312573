using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_Unit
{
    public partial class FormFetchingData : Form
    {
        public FormFetchingData()
        {
            InitializeComponent();
            progressBarFetchingData.Increment(30);
            progressBarFetchingData.Update();
        }
    }
}
