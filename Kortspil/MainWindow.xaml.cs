using System;
using System.Diagnostics.Eventing.Reader;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new (url, UriKind.Relative);
            BitmapImage image = new(uri);

            Billede.Source = image;

        }

        private string FindBillede(int kortnummer)
        {
        //løsning

            //Hvis der bliver givet en værdi udenfor intervallet [1,52] retuner null
            if (kortnummer < 1 || kortnummer > 52)
                return null;

            //Billedkort vælges med switch betingelse, hvor værdien af kortnummer vurderes i en række case blokke
            switch (kortnummer)
            {
                case 1:  return "Es-Spar.jpg";
                case 11: return "Knægt-Spar.jpg";
                case 12: return "Dame-Spar.jpg";
                case 13: return "Konge-Spar.jpg";
                case 14: return "Es-Ruder.jpg";
                case 24: return "Knægt-Ruder.jpg";
                case 25: return "Dame-Ruder.jpg";
                case 26: return "Konge-Ruder.jpg";
                case 27: return "Es-Klør.jpg";
                case 37: return "Knægt-Klør.jpg";
                case 38: return "Dame-Klør.jpg";
                case 39: return "Konge-Klør.jpg";
                case 40: return "Es-Hjerter.jpg";
                case 50: return "Knægt-Hjerter.jpg";
                case 51: return "Dame-Hjerter.jpg";
                case 52: return "Konge-Hjerter.jpg";
                default:

                    /* såfremt værdien af kortnummer ikke er et billedkort vælges disse med en if betingelse. 
                    Jeg definerer to variabler "kulør", og "tal" der hver især indeholder hver deres komponent i filnavnet til billederne $"{tal}-{kulør}.jpg */

                    string kulør;
                    int tal;

                    if (kortnummer <= 10) // kortnummer 2-10 "Spar 2-10"
                    {
                        kulør = "Spar";
                        tal = kortnummer;
                    }
                    else if (kortnummer <= 23) // kortnummer 15-23 "Ruder 2-10"
                    {
                        kulør = "Ruder";
                        tal = kortnummer - 13;
                    }
                    else if (kortnummer <= 36) // kortnummer 28-36 "Klør 2-10"
                    {
                        kulør = "Klør";
                        tal = kortnummer - 26;
                    }
                    else // kortnummer 41-49, "Hjerter"
                    {
                        kulør = "Hjerter";
                        tal = kortnummer - 39;
                    }
                    return $"{tal}-{kulør}.jpg"; // Indsæt variablerne "tal" og "kulør" i "filnavn og retuner denne"
            }
        }
    }
}