using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HelloSkiaSharp
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ImageService ImageService;
        private readonly WriteableBitmap WriteableBitmap;

        // Properties
        #region ImageSource
        private ImageSource _ImageSource;
        public ImageSource ImageSource
        {
            get { return _ImageSource; }
            set
            {
                if (_ImageSource != value)
                {
                    _ImageSource = value;
                    OnPropertyChanged(nameof(ImageSource));
                }
            }
        }
        #endregion

        public MainViewModel()
        {
            this.ImageSource = this.WriteableBitmap = new WriteableBitmap(800, 600, 96, 96, PixelFormats.Bgra32, BitmapPalettes.Halftone256Transparent);
            this.ImageService = new ImageService();
            CompositionTarget.Rendering += (o, e) => this.ImageService.UpdateImage(this.WriteableBitmap);
        }

        protected void OnPropertyChanged(string name)
        {
            /*
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
            */
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
