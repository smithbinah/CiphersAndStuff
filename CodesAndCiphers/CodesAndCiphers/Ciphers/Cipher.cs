using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesAndCiphers.Ciphers
{
    public class Cipher : INotifyPropertyChanged
    {
        private string answer;
        public int RowIndex { get; set; } = 0;
        private int indexMax = 4;

        public int IndexMax
        {
            get { return indexMax; }
            set {
                indexMax = value;
                OnPropertyChanged("IndexMax");
            }
        }


        public string Answer
        {
            get { return answer; }
            set
            {
                answer = value;
                OnPropertyChanged("Answer");
            }
        }
        private string encryptedInput;

        public event PropertyChangedEventHandler PropertyChanged;

        public string EncryptedInput
        {
            get { return encryptedInput; }
            set
            {
                encryptedInput = value;
                reverseInput();
                groupInput();
                OnPropertyChanged("EncryptedInput");
            }
        }
        
        private void groupInput()
        {
            if (EncryptedInput.ToCharArray().Length >= 2)
            {
                string placeHolder = "";
                string formattedSTR = EncryptedInput.Replace(" ", String.Empty);
                foreach (char item in formattedSTR.ToCharArray())
                {
                    if (RowIndex >= indexMax)
                    {
                        placeHolder += "\n" + item;
                        RowIndex++;
                        RowIndex = 0;
                    }
                    else
                    {
                        placeHolder += "\t" + item;
                        RowIndex++;
                    }

                }
                Groups = placeHolder.Replace(" ",String.Empty);
            }

        }

        private string groups;

        public string Groups
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged("Groups");
            }
        }


        public void reverseInput()
        {

            char[] chars = EncryptedInput.ToCharArray();
            Array.Reverse(chars);
            string str = new string(chars);
            Answer = str.Replace(" ", String.Empty);



        }


        private void OnPropertyChanged(string info)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }




    }
}
