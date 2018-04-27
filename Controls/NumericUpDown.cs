using System.Windows.Forms;

namespace TaskBarRenamer
{
    public class NumericUpDownFixed : NumericUpDown
    {
        public bool SetValue(int value)
        {
            if (value < this.Minimum)
            {
                this.Value = this.Minimum;
                return false;
            }
            if (value > this.Maximum)
            {
                this.Value = this.Maximum;
                return false;
            }

            this.Value = value;
            return true;
        }
    }
}