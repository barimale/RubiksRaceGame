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

        private void button1_DragEnter(object sender, DragEventArgs e)
        {
            button1.BackColor = Color.AliceBlue;
        }

        private void button1_DragLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Green;
        }

        private void button1_DragOver(object sender, DragEventArgs e)
        {
            button1.BackColor = Color.Red;
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            button1.BackColor = (sender as Button).BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.AllowDrop = true;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
