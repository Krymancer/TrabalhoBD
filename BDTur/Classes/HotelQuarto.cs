using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDTur.Classes
{
    class HotelQuarto
    {
        private int numQuarto;
        private int hotelIdHotel;
        private int tipoQuarto;
        private float diariaQuarto;

        public HotelQuarto(int numQuarto, int hotelIdHotel, string tipoQuarto, float diariaQuarto)
        {
            NumQuarto = numQuarto;
            HotelIdHotel = hotelIdHotel;
            TipoQuarto = tipoQuarto;
            DiariaQuarto = diariaQuarto;
        }

        public int NumQuarto { get; set; }
        public int HotelIdHotel { get; set; }
        public string TipoQuarto { get; set; }
        public float DiariaQuarto { get; set; }
    }
}
