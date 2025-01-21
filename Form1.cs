namespace ShopcartCoffee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeDefaultPrices(); 
        }

        private void InitializeDefaultPrices()
        {
        
            tbCoffeePrice.Text = "50";      
            tbGreenTeaPrice.Text = "45";   
            tbNoodlePrice.Text = "80";     
            tbPizzaPrice.Text = "120";    

            
            tbDiscountAll.Text = "0";
            tbDiscountBeverage.Text = "0";
            tbDiscountFood.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize variables
            double coffeePrice = 0, coffeeQuantity = 0, greenTeaPrice = 0, greenTeaQuantity = 0;
            double noodlePrice = 0, noodleQuantity = 0, pizzaPrice = 0, pizzaQuantity = 0;
            double totalBeverage = 0, totalFood = 0, total = 0;
            double cash = 0, change = 0;

            // Parse input values
            if (chbCoffee.Checked)
            {
                double.TryParse(tbCoffeePrice.Text, out coffeePrice);
                double.TryParse(tbCoffeeQuantity.Text, out coffeeQuantity);
                totalBeverage += coffeePrice * coffeeQuantity;
            }

            if (chbGreenTea.Checked)
            {
                double.TryParse(tbGreenTeaPrice.Text, out greenTeaPrice);
                double.TryParse(tbGreenTeaQuantity.Text, out greenTeaQuantity);
                totalBeverage += greenTeaPrice * greenTeaQuantity;
            }

            if (chbNoodle.Checked)
            {
                double.TryParse(tbNoodlePrice.Text, out noodlePrice);
                double.TryParse(tbNoodleQuantity.Text, out noodleQuantity);
                totalFood += noodlePrice * noodleQuantity;
            }

            if (chbPizza.Checked)
            {
                double.TryParse(tbPizzaPrice.Text, out pizzaPrice);
                double.TryParse(tbPizzaQuantity.Text, out pizzaQuantity);
                totalFood += pizzaPrice * pizzaQuantity;
            }

           
            total = totalBeverage + totalFood;

            
            if (chbDiscountAll.Checked)
            {
                if (double.TryParse(tbDiscountAll.Text, out double discountAll))
                {
                    total -= total * (discountAll / 100);
                }
            }
            else
            {
                if (chbDiscountBeverage.Checked)
                {
                    if (double.TryParse(tbDiscountBeverage.Text, out double discountBeverage))
                    {
                        totalBeverage -= totalBeverage * (discountBeverage / 100);
                    }
                }

                if (chbDiscountFood.Checked)
                {
                    if (double.TryParse(tbDiscountFood.Text, out double discountFood))
                    {
                        totalFood -= totalFood * (discountFood / 100);
                    }
                }

                total = totalBeverage + totalFood;
            }

            
            tbTotal.Text = total.ToString("F2");

            
            if (double.TryParse(tbCash.Text, out cash))
            {
                if (cash >= total)
                {
                    change = cash - total;
                    tbChange.Text = change.ToString("F2");

                    
                    int remainingChange = (int)change;
                    tb1000.Text = (remainingChange / 1000).ToString();
                    remainingChange %= 1000;
                    tb500.Text = (remainingChange / 500).ToString();
                    remainingChange %= 500;
                    tb100.Text = (remainingChange / 100).ToString();
                    remainingChange %= 100;
                    tb50.Text = (remainingChange / 50).ToString();
                    remainingChange %= 50;
                    tb20.Text = (remainingChange / 20).ToString();
                    remainingChange %= 20;
                    tb10.Text = (remainingChange / 10).ToString();
                    remainingChange %= 10;
                    tb5.Text = (remainingChange / 5).ToString();
                    remainingChange %= 5;
                    tb1.Text = remainingChange.ToString();
                }
                else
                {
                    MessageBox.Show("เงินสดไม่เพียงพอ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("เงินสดป้อนไม่ถูกต้อง.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
