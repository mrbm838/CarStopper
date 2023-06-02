namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        Base bs;
        AA a;
        BB b;


        public Form1()
        {
            InitializeComponent();
            bs = new Base(ShowBase);
            a = new AA(ShowAA);
            a.Add(ref a.address);
            b = new BB(ShowBB);
            b.Add(ref b.address);
        }

        static Form1()
        {

        }

        public void ShowBase()
        {
            if (this.IsHandleCreated)
                textBox1.Invoke(new MethodInvoker(delegate () { textBox1.Text += "base\r\n"; }));
        }

        public void ShowAA()
        {
            if (this.IsHandleCreated)
                textBox2.Invoke(new MethodInvoker(delegate () { textBox2.Text += "aa\r\n"; }));
        }

        public void ShowBB()
        {
            if (this.IsHandleCreated)
                textBox3.Invoke(new MethodInvoker(delegate () { textBox3.Text += "bb\r\n"; }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bs.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b.Stop();
        }
    }
}