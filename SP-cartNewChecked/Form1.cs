using System;
using System.Linq.Expressions;
using System.Numerics;

namespace ShoppingCart
{
    public partial class Form1 : Form
    {
        Item itemCoffee = new Item();
        GreenTea itemGreentea = new GreenTea();
        Noodle itemNoodle = new Noodle();
        Pizza itemPizza = new Pizza();



        public Form1()
        {
            // add data to object
            InitializeComponent();
            itemCoffee.name = "Coffee";
            itemCoffee.price = 75 ;
            itemCoffee.quantily = 1 ;
            itemCoffee.isCheck = true ;

            // display data
            tbCoffeePrice.Text = itemCoffee.price.ToString();
            tbCoffeeQuantity.Text = itemCoffee.quantily.ToString();
            chbcoffee.Checked =  itemCoffee.isCheck;
                

            itemGreentea.name = "GreenTea";
            itemGreentea.price = 60;
            itemGreentea.quantily = 0;
            itemGreentea.isCheck = true;

            tbGreenTeaPrice.Text = itemGreentea.price.ToString();
            tbGreenTeaQuantity.Text = itemGreentea.quantily.ToString();
            chbGreenTea.Checked = itemGreentea.isCheck;

            itemNoodle.name = "Noodle" ;
            itemNoodle.price = 40 ;
            itemNoodle.quantily = 1 ;
            itemNoodle.isCheck = true;


            tbNoodle.Text = itemNoodle.price.ToString();
            NoodlePrice.Text = itemNoodle.quantily.ToString();
            CheckNoodle.Checked = itemNoodle.isCheck;



            itemPizza.name = "Pizza";
            itemPizza.price = 111;
            itemPizza .quantily = 0;
            itemPizza.isCheck = true;

            tbPizza.Text = itemPizza.price.ToString();
            PizzaPrice.Text = itemPizza.quantily.ToString();
            CheckPizza.Checked = itemPizza.isCheck;

        }

        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbCoffeePrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbGreenTeaPrice_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbGreenTeaQuantity_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbTotal_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }





        private void button1_Click(object sender, EventArgs e)
        {
            
            int sumTotalBeverage = 0, sumTotalFoods = 0;


            // Sum Beverage
            if (chbcoffee.Checked)
            {
                int coffeePrice = string.IsNullOrWhiteSpace(tbCoffeePrice.Text) ? 0 : int.Parse(tbCoffeePrice.Text);
                int coffeeQuantity = string.IsNullOrWhiteSpace(tbCoffeeQuantity.Text) ? 0 : int.Parse(tbCoffeeQuantity.Text);
                sumTotalBeverage += coffeePrice * coffeeQuantity;
            }
            if (chbGreenTea.Checked)
            {
                int greenTeaPrice = string.IsNullOrWhiteSpace(tbGreenTeaPrice.Text) ? 0 : int.Parse(tbGreenTeaPrice.Text);
                int greenTeaQuantity = string.IsNullOrWhiteSpace(tbGreenTeaQuantity.Text) ? 0 : int.Parse(tbGreenTeaQuantity.Text);
                sumTotalBeverage += greenTeaPrice * greenTeaQuantity;
            }

            // Sum Foods
            if (CheckNoodle.Checked)
            {
                int noodlePrice = string.IsNullOrWhiteSpace(NoodlePrice.Text) ? 0 : int.Parse(NoodlePrice.Text);
                int noodleQuantity = string.IsNullOrWhiteSpace(tbNoodle.Text) ? 0 : int.Parse(tbNoodle.Text);
                sumTotalFoods += noodlePrice * noodleQuantity;
            }
            if (CheckPizza.Checked)
            {
                int pizzaPrice = string.IsNullOrWhiteSpace(PizzaPrice.Text) ? 0 : int.Parse(PizzaPrice.Text);
                int pizzaQuantity = string.IsNullOrWhiteSpace(tbPizza.Text) ? 0 : int.Parse(tbPizza.Text);
                sumTotalFoods += pizzaPrice * pizzaQuantity;
            }

            // Sum productPrice
            int totalAmount = sumTotalBeverage + sumTotalFoods;

            // FunctionDiscount
            double ApplyDiscount(double amount, string discountText)
            {

                string strCoffeeQuantily = tbCoffeeQuantity.Text;


                if (double.TryParse(discountText, out double discountRate))
                {
                    return amount - (amount * discountRate / 100);
                }
                return amount;
            }

            // Check and Discount
            if (CheckAll.Checked)
            {
                totalAmount = (int)ApplyDiscount(totalAmount, Disall.Text);
            }
            else

         

            {
                if (CheckBeve.Checked)
                {
                    sumTotalBeverage = (int)ApplyDiscount(sumTotalBeverage, Disbeve.Text);
                }
                if (CheckFoods.Checked)
                {
                    sumTotalFoods = (int)ApplyDiscount(sumTotalFoods, Disfoods.Text);
                }
                totalAmount = sumTotalBeverage + sumTotalFoods;
            }

            // Result
            tbTotal.Text = totalAmount.ToString("F2"); // แสดงผลเป็นทศนิยม 2 ตำแหน่ง
        }





        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void chbcoffee_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Input tbTotal
            double total = string.IsNullOrWhiteSpace(tbTotal.Text) ? 0 : double.Parse(tbTotal.Text);

            // Input Cashmonney from User
            string inputCash = Cashmonney.Text;
            int cash = string.IsNullOrWhiteSpace(inputCash) ? 0 : int.Parse(inputCash);

            // Calculator
            double change = cash - total;

            // CHeckMonny
            if (change < 0)
            {
                MessageBox.Show("เงินสดไม่เพียงพอ! ใส่เงินใหม่อีกครั้งที่ช่อง Cash");
                return;
            }

            // Calculat Bank 
            int banknotes1000 = (int)(change / 1000); //  1000 Bath
            double remainingChange = change % 1000;

            int banknotes500 = (int)(remainingChange / 500); //  500 Bath
            remainingChange %= 500;

            int banknotes100 = (int)(remainingChange / 100); //  100 Bath
            remainingChange %= 100;

            int banknotes50 = (int)(remainingChange / 50); //  50 Bath
            remainingChange %= 50;

            int banknotes20 = (int)(remainingChange / 20); // 20 Bath
            remainingChange %= 20;

            int coins10 = (int)(remainingChange / 10); // 10 Bath
            remainingChange %= 10;

            int coins5 = (int)(remainingChange / 5); //  5 Bath
            remainingChange %= 5;

            int coins1 = (int)(remainingChange / 1); //  1 Bath
            remainingChange %= 1;

            // Print TextBox 
            Changemonney.Text = change.ToString("F2"); 
            Change1000.Text = banknotes1000.ToString();
            Change500.Text = banknotes500.ToString();
            Change100.Text = banknotes100.ToString();
            Change50.Text = banknotes50.ToString();
            Change20.Text = banknotes20.ToString();
            Change10.Text = coins10.ToString();
            Change5.Text = coins5.ToString();
            ChangeBath.Text = coins1.ToString();
        }

        private void lavel_Click(object sender, EventArgs e)
        {

        }

        private void Change1000_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change5_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change10_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change20_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change50_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void Change100_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Changemonney_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            tbCoffeePrice.Clear();
            tbGreenTeaPrice.Clear();
            tbCoffeeQuantity.Clear();
            tbGreenTeaQuantity.Clear();


            tbTotal.Clear();
            Cashmonney.Clear();
            Changemonney.Clear();


            Change1000.Clear();
            Change500.Clear();
            Change100.Clear();
            Change50.Clear();
            Change20.Clear();
            Change10.Clear();
            Change5.Clear();
            ChangeBath.Clear();


            tbNoodle.Clear();
            tbPizza.Clear();
            NoodlePrice.Clear();    
            PizzaPrice.Clear();

            Disall.Clear();
            Disbeve.Clear();
            Disfoods.Clear();   

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox8_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox10_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox7_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
