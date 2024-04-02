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

            button1.AllowDrop = true;
            button2.AllowDrop = true;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            button1.BackColor = (sender as Button).BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {

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
            btn.BackColor = Color.Transparent;
            btn.AllowDrop = true;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            var result = new Randomizer().Execute();

            foreach(var item in result)
            {
                Button btn = (Button)this.Controls["button" + (26+item.Index).ToString()];
                btn.BackColor = Randomizer.ColorMapper[item.ColorCode];

            }
        }
    }
}
