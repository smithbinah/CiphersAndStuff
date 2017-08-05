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
        public int RowIndex { get; set; }
        public int IndexMax { get; set; }

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
           
            string placeHolder = "";
            foreach (char item in EncryptedInput.ToCharArray())
            {
                if (RowIndex >= IndexMax)
                {
                    placeHolder += "\n";
                    RowIndex++;
                    RowIndex = 0;
                }
                else
                {
                    placeHolder += "\t"+item;
                    RowIndex++;
                }

            }
            Groups = placeHolder;
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
