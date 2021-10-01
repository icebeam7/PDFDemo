using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Stream = System.IO.Stream;

using Android.App;
using Android.Media;
using Android.Graphics;
using Android.Graphics.Drawables;
using static Android.Graphics.Bitmap;
using static Android.Graphics.BitmapFactory;

using Xamarin.Essentials;
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

namespace PDFDemo.Droid.Classes
{
    public class AndroidImageSource : ImageSource
    {
        protected override IImageSource FromBinaryImpl(string name, Func<byte[]> imageSource, int? quality = 75)
        {
            return new AndroidImageSourceImpl(name, () => { return new MemoryStream(imageSource.Invoke()); }, (int)quality);
        }

        protected override IImageSource FromFileImpl(string path, int? quality = 75)
        {
            if (path.Contains("."))
            {
                string[] tokens = path.Split('.');
                tokens = tokens.Take(tokens.Length - 1).ToArray();
                path = String.Join(".", tokens);
            }

            var res = Application.Context.Resources;
            var resId = res.GetIdentifier(path, "drawable", AppInfo.PackageName);

			Stream stream = new MemoryStream();
            BitmapDrawable drawable = null;
            if (resId > 0)
            {
                drawable = res.GetDrawable(resId) as BitmapDrawable;
                if (drawable != null)
                    drawable.Bitmap.Compress(CompressFormat.Jpeg, quality ?? 75, stream);
            }

            var x = new AndroidImageSourceImpl(path, () => stream, quality ?? 75) { Bitmap = drawable?.Bitmap };
			return x;
        }

        protected override IImageSource FromStreamImpl(string name, Func<Stream> imageStream, int? quality = 75)
        {
            return new AndroidImageSourceImpl(name, imageStream, (int)quality);
        }

		internal class AndroidImageSourceImpl : IImageSource
		{
			internal Bitmap Bitmap { get; set; }
			internal Stream Stream { get; set; }
			private Orientation Orientation { get; }

			private readonly Func<Stream> _streamSource;
			private readonly int _quality;

			public int Width { get; }
			public int Height { get; }
			public string Name { get; }

            public AndroidImageSourceImpl(string name, Func<Stream> streamSource, int quality)
			{
				Name = name;
				_streamSource = streamSource;
				_quality = quality;
				using (var stream = streamSource.Invoke())
				{
					Orientation = Orientation.Normal;
					stream.Seek(0, SeekOrigin.Begin);
					var options = new Options { InJustDecodeBounds = true };
#pragma warning disable CS0642 // Possible mistaken empty statement
					using (DecodeStream(stream, null, options))
						;
#pragma warning restore CS0642 // Possible mistaken empty statement
					Width = Orientation == Orientation.Normal || Orientation == Orientation.Rotate180 ? options.OutWidth : options.OutHeight;
					Height = Orientation == Orientation.Normal || Orientation == Orientation.Rotate180 ? options.OutHeight : options.OutWidth;
				}
			}

			public void SaveAsJpeg(MemoryStream ms)
			{
				var ct = new CancellationToken();
				TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
				ct.Register(() => {
					tcs.TrySetCanceled();
				});
				var task = Task.Run(() => {
					Matrix mx = new Matrix();
					ct.ThrowIfCancellationRequested();
					//using (var bitmap = this.Bitmap; DecodeStream(_streamSource.Invoke()))
					//{
					switch (Orientation)
					{
						case Orientation.Rotate90:
							mx.PostRotate(90);
							break;
						case Orientation.Rotate180:
							mx.PostRotate(180);
							break;
						case Orientation.Rotate270:
							mx.PostRotate(270);
							break;
						default:
							ct.ThrowIfCancellationRequested();
							Bitmap.Compress(CompressFormat.Jpeg, _quality, ms);
							ct.ThrowIfCancellationRequested();
							return;
					}
					ct.ThrowIfCancellationRequested();
					using (var flip = Android.Graphics.Bitmap.CreateBitmap(Bitmap, 0, 0, Bitmap.Width, Bitmap.Height, mx, true))
					{
						flip.Compress(CompressFormat.Jpeg, _quality, ms);
					}
					ct.ThrowIfCancellationRequested();
					//}
				});
				Task.WaitAny(task, tcs.Task);
				tcs.TrySetCanceled();
				ct.ThrowIfCancellationRequested();
				if (task.IsFaulted)
					throw task.Exception;
			}

			bool IImageSource.Transparent => false;

			void IImageSource.SaveAsPdfBitmap(MemoryStream ms)
            {

            }
        }
	}
}