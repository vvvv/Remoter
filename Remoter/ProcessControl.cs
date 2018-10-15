using System;
using System.Windows.Forms;

namespace VVVV.Nodes
{
    public partial class ProcessControl : UserControl
    {
        public event ProcessChangedHandler OnProcessChanged;
        public event ButtonUpHandler OnXButton;

        public string Process
        {
            get
            {
                return ProcessEdit.Text;
            }
            set
            {
                ProcessEdit.Text = value;
            }
        }

        public string Arguments
        {
            get
            {
                return ArgumentsEdit.Text;
            }
            set
            {
                ArgumentsEdit.Text = value;
            }
        }

        public string ProcessAndArguments
        {
            get
            {
                return ProcessEdit.Text + " " + ArgumentsEdit.Text;
            }
        }

        public ProcessControl()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        void ProcessEditTextChanged(object sender, EventArgs e)
        {
            if (OnProcessChanged != null)
                OnProcessChanged();
        }

        void ArgumentsEditTextChanged(object sender, EventArgs e)
        {
            if (OnProcessChanged != null)
                OnProcessChanged();
        }

        void RemoveButtonClick(object sender, EventArgs e)
        {
            OnXButton(this);
        }

        private void ArgumentsEdit_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Active = false;
            toolTip1.Active = true;
        }
    }

    public delegate void ProcessChangedHandler();
}
