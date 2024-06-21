using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vtuber2d.storing_Pictures
{
    public class Pictures
    {
        private static Pictures? _pictureInstance;

        private OpenFileDialog? _openFileDialog;


        //filter 
        public string openDialogFilter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*";

        private string notTalkingPicture { get; set; } = "no value set N";
        private string talkingPicture { get; set; } = "no value set T";
         

        //creating a singleton to make the variable accesable to all files
        //rather then passing the same variable over and over again
        public static Pictures Instance
        {
            get
            {
                if(_pictureInstance == null)
                {
                    _pictureInstance = new Pictures();
                }
                return _pictureInstance;
            }
        }


        public void setImageT()
        {
            _openFileDialog = new OpenFileDialog();
            _openFileDialog.Filter = openDialogFilter;

            if (_openFileDialog.ShowDialog() == true)
            {
                //set property
                talkingPicture = _openFileDialog.FileName;

                Debug.WriteLine(talkingPicture);
                // TalkingImage.Source = new BitmapImage(new Uri(_picturesInstance.talkingPicture));
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
               // notTalkingImage.Source = new BitmapImage(new Uri(_picturesInstance.notTalkingPicture));
            }
        }

        public  string getImageT()
        {

            return talkingPicture;
        }

        public   string getimageN()
        {
            return notTalkingPicture;
        }
    }
}
