using System.Net;
using System.Security.Policy;
using Zadaca.Items;
using Zadaca.Items.Consumables.Desserts;
using Zadaca.Items.Consumables.Drinks;

namespace Zadaca
{
    public partial class Form1 : Form
    {
        private Receipt receipt;

        private readonly IProduct[] _allProducts =
{
            new Beverage("Coca Cola", 2m, 3.25),
            new Beverage("Fanta",     2.5m, 3.33),
            new Beverage("Sprite",    2m, 2.5),
            new Coffee("Espresso",      1.5m, 1.5),
            new Coffee("Cappuccino",    2.2m, 3),
            new Coffee("Latte",         1.7m, 2),
            new Cake("Kolač", 2.50m),
            new IceCream(),
            new Coupon(10m, 10),
            new Coupon(100m, 100)
        };

        public Form1()
        {
            InitializeComponent();
            visuals();
            receipt = new Receipt();

            Render_Products(groupBox1);
            Render_Products(groupBox2);
            Render_Products(groupBox3);
            Render_Products(groupBox4);
        }

        private void Render_Products(GroupBox box)
        {
            box.Controls.Clear();
            int x = 20;

            foreach (var product in _allProducts)
            {
                if(product.Category.ToLower() == box.Text.ToString().ToLower())
                {

                    var button = new Button
                    {
                        Text = $"{product.Name}",
                        Tag = product,
                        AutoSize = true,
                        Margin = new Padding(5),
                        Height =100,
                        Width=200,
                        Left = x,
                        Top = 50,
                    };
                    x += 250;
                    button.Click += ProductButton_Click;
                    box.Controls.Add(button);
                }
            }
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            IProduct product = (IProduct)button.Tag;
            receipt.AddItem(product);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                this.ClientRectangle,
                Color.FromArgb(180, 130, 0),
                Color.FromArgb(70, 20, 150),
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal
            );
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void visuals()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.groupBox1.BackColor = Color.Transparent;
            this.groupBox2.BackColor = Color.Transparent;
            this.groupBox3.BackColor = Color.Transparent;
            this.groupBox4.BackColor = Color.Transparent;
            this.lblSumTxt.BackColor = Color.Transparent;
            this.lblSum.BackColor = Color.Transparent;
            this.lblHeader.BackColor = Color.Transparent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.receipt = new Receipt();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (receipt.sum != 0)
            {
                MessageBox.Show(
                    $"Naplata računa: \n{receipt.sum}€",
                    "Naplata!",
                    MessageBoxButtons.OK);
                this.receipt = new Receipt();
            }
        }

        private void btnEspresso_Click(object sender, EventArgs e)
        {

        }
    }
}
