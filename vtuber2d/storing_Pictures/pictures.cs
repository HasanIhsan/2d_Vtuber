using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtuber2d.storing_Pictures
{
    public class pictures
    {

        private OpenFileDialog _openFileDialog;


        public string openDialogFilter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

        public string notTalkingPicture { get; set; } = "no value set N";
        public string talkingPicture { get; set; } = "no value set T";
         


        public void setImageT()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = openDialogFilter;

            if (_openFileDialog.ShowDialog() == true)
            {
                //set property
                talkingPicture = _openFileDialog.FileName;

                Debug.WriteLine(talkingPicture);
                // TalkingImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(_picturesInstance.talkingPicture));
            }
        }

        public void setimageN()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = openDialogFilter;

            if (_openFileDialog.ShowDialog() == true)
            {
                //set the property;
                notTalkingPicture = _openFileDialog.FileName;

                //set image source:
               // notTalkingImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(_picturesInstance.notTalkingPicture));
            }
        }

        public string getImageT()
        {

            return talkingPicture;
        }

        public string getimageN()
        {
            return notTalkingPicture;
        }
    }
}
