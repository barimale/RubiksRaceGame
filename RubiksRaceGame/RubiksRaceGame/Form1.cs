using RubiksRaceGame.Services;

namespace RubiksRaceGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.BackColor = Color.Black;
            button2.BackColor = Color.Blue;

            button1.ForeColor = Color.Transparent;
            button2.ForeColor = Color.Transparent;
            button3.ForeColor = Color.Transparent;
            button4.ForeColor = Color.Transparent;
            button5.ForeColor = Color.Transparent;
            button6.ForeColor = Color.Transparent;
            button7.ForeColor = Color.Transparent;
            button8.ForeColor = Color.Transparent;
            button9.ForeColor = Color.Transparent;
            button10.ForeColor = Color.Transparent;
            button11.ForeColor = Color.Transparent;
            button12.ForeColor = Color.Transparent;
            button13.ForeColor = Color.Transparent;
            button14.ForeColor = Color.Transparent;
            button15.ForeColor = Color.Transparent;
            button16.ForeColor = Color.Transparent;
            button17.ForeColor = Color.Transparent;
            button18.ForeColor = Color.Transparent;
            button19.ForeColor = Color.Transparent;
            button20.ForeColor = Color.Transparent;
            button21.ForeColor = Color.Transparent;
            button22.ForeColor = Color.Transparent;
            button23.ForeColor = Color.Transparent;
            button24.ForeColor = Color.Transparent;
            button25.ForeColor = Color.Transparent;

            button26.Text = string.Empty;
            button27.Text = string.Empty;
            button28.Text = string.Empty;
            button29.Text = string.Empty;
            button30.Text = string.Empty;
            button31.Text = string.Empty;
            button32.Text = string.Empty;
            button33.Text = string.Empty;
            button34.Text = string.Empty;

            button1.AllowDrop = true;
            button2.AllowDrop = true;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            var a = e.Data.GetData(DataFormats.Text).ToString();
            Button btn = (Button)this.Controls[a];

            button1.BackColor = btn.BackColor;
            button1.ForeColor = btn.BackColor;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.Transparent;
            btn.AllowDrop = true;
        }

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (button1.BackColor == Color.Transparent)
                return;

            button1.DoDragDrop(button1.Text, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void button2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void button2_DragDrop(object sender, DragEventArgs e)
        {
            var a = e.Data.GetData(DataFormats.Text).ToString();
            Button btn = (Button)this.Controls[a];

            button2.BackColor = btn.BackColor;
            button2.ForeColor = btn.BackColor;
            btn.BackColor = Color.Transparent;
            btn.ForeColor = Color.Transparent;
            btn.AllowDrop = true;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            if (button2.BackColor == Color.Transparent)
                return;

            button2.DoDragDrop(button2.Text, DragDropEffects.Copy |
                DragDropEffects.Move);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var result = new Randomizer().Execute();

            foreach(var item in result)
            {
                Button btn = (Button)this.Controls["button" + (26+item.Index).ToString()];
                btn.BackColor = Randomizer.ColorMapper[item.ColorCode];

            }

            var result2 = new Randomizer().ExecuteForBoard();

            foreach (var item in result2)
            {
                Button btn = (Button)this.Controls["button" + (1 + item.Index).ToString()];
                btn.BackColor = Randomizer.ColorMapper[item.ColorCode];
                btn.ForeColor = btn.BackColor;
            }

            button1.AllowDrop = true;
            button1.BackColor = Color.Transparent;
        }
    }
}
