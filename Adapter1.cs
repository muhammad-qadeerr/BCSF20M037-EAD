using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Setting input for DVI Moniter..!");
            VgaGraphicsCard vga = new VgaGraphicsCard();
            DviMoniter dviMoniter = new DviMoniter();
            VgaGraphicsCardAdapter adapter = new VgaGraphicsCardAdapter( vga );
            dviMoniter.SetInput(adapter.GetDviStream());
            Console.ReadLine();
        }
    }

    class VgaStream
    {
        private byte[] _stream;
        public void SetData(byte[] data)
        {
            _stream = data;
        }

        public byte[] GetData()
        {
            return _stream;
        }
    }

    class DviStream
    {
        private byte[] _stream;
        public void SetData(byte[] data)
        {
            _stream = data;
        }

        public byte[] GetData()
        {
            return _stream;
        }
    }
    class VgaGraphicsCard
    {
        public VgaStream GetVgaStream()
        {
            VgaStream vgaStream = new VgaStream();
            vgaStream.SetData(new byte[] { });
            return vgaStream;
        }

    }

    class DviMoniter
    {
        private byte[] _inputStream;
        public void SetInput(DviStream inputStream)
        {
            _inputStream = inputStream.GetData();
        }

    }

    class VgaGraphicsCardAdapter
    {
        private VgaGraphicsCard _vgaGraphicsCard;

        public VgaGraphicsCardAdapter(VgaGraphicsCard vgaGraphicsCard)
        {
            _vgaGraphicsCard = vgaGraphicsCard;
        }

        public DviStream GetDviStream()
        {
            byte[] data = _vgaGraphicsCard.GetVgaStream().GetData();

            // Process to convert the vga video data to dvi video data

            byte[] dviVideoData = ConvertFromVgiToDvi(data);
            DviStream dviStream = new DviStream();
            dviStream.SetData(dviVideoData);
            return dviStream;
        }


        private byte[] ConvertFromVgiToDvi(byte[] input )
        {
            Console.WriteLine("Converted VGI video to DVI video!");
            return new byte[] { };
        }
    }
}

