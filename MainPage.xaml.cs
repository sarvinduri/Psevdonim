namespace Psevdonim;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnSetStonesBtn(object sender, EventArgs e)
    {
        count = Int32.Parse(stonesEntry.Text);
        lblStonesCount.Text = count.ToString();
        if (!GetStonesBtn.IsEnabled)
        {
            GetStonesBtn.IsEnabled = true;
        }
    }


    private void OnGetStonesBtn(object sender, EventArgs e)
    {
        int quantite = 0;
        quantite = Int32.Parse(getStonesEntry.Text);
        if (quantite > 0 && quantite <= 3 && quantite <= count)
        {
            logEditor.Text += "Игрок взял: " + quantite.ToString() + " шт. \n";
            count -= quantite;
            if (count == 0)
            {
                logEditor.Text += "ИИ выиграл.";
                getStonesEntry.Text = "";
                GetStonesBtn.IsEnabled = false;
                lblStonesCount.Text = count.ToString();
                return;
            }
            if (count % 4 != 1)
            {
                if (count % 4 == 2)
                {
                    quantite = 1;
                }
                else if (count % 4 == 3)
                {
                    quantite = 2;
                }
                else if (count % 4 == 0)
                {
                    quantite = 3;
                }
            }
            else
            {
                Random rnd = new Random();
                quantite = rnd.Next(1, 4);
                while (count - quantite < 0)
                {
                    quantite = rnd.Next(1, 4);
                }
            }
            logEditor.Text += "ИИ взял: " + quantite.ToString() + " шт. \n";
            logEditor.Text += "----------------- \n";
            count -= quantite;
            if (count == 0)
            {
                logEditor.Text += "Игрок выиграл.";
                getStonesEntry.Text = "";
                GetStonesBtn.IsEnabled = false;
            }
        }
        lblStonesCount.Text = count.ToString();
    }
}
