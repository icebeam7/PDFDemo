using Foundation;
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace PDFDemo.iOS.Classes
{
    public class ImageSourceiOS : ImageSource
    {
		protected override IImageSource FromBinaryImpl(string name, Func<byte[]> imageSource, int? quality = 75)
		{
			return new IosImageSourceImpl(name, () => { return new MemoryStream(imageSource.Invoke()); }, (int)quality);
		}

		protected override IImageSource FromFileImpl(string path, int? quality = 75)
		{
			return new IosImageSourceImpl(path, () => { return File.OpenRead(path); }, (int)quality);
		}

		protected override IImageSource FromStreamImpl(string name, Func<Stream> imageStream, int? quality = 75)
		{
			return new IosImageSourceImpl(name, imageStream, (int)quality);
		}

		private class IosImageSourceImpl : IImageSource
		{
			internal UIKit.UIImage image;

			private Orientation Orientation { get; }

			private readonly Func<Stream> _streamSource;
			private readonly int _quality;

			public int Width { get; }
			public int Height { get; }
			public string Name { get; }

			bool IImageSource.Transparent => false;

            public IosImageSourceImpl(string name, Func<Stream> streamSource, int quality)
			{
				Name = name;
				_streamSource = streamSource;
				_quality = quality;
				using (var stream = streamSource.Invoke())
				{
					image = UIKit.UIImage.LoadFromData(NSData.FromStream(stream));
					var size = image?.Size ?? new CoreGraphics.CGSize(0, 0);

					Width = (int)size.Width;
					Height = (int)size.Height;
					Orientation = Orientation.Normal;
				}
			}

			public void SaveAsJpeg(MemoryStream ms)
			{
				var jpg = image.AsJPEG();
				ms.Write(jpg.ToArray(), 0, (int)jpg.Length);
				ms.Seek(0, SeekOrigin.Begin);
			}

            void IImageSource.SaveAsPdfBitmap(MemoryStream ms)
            {
                throw new NotImplementedException();
            }
        }
	}

	internal enum Orientation
	{
		Normal = 1,
		Rotate90 = 6,
		Rotate180 = 3,
		Rotate270 = 8
	}
}