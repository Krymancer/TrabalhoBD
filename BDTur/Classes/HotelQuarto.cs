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

        public HotelQuarto(int numQuarto, int hotelIdHotel, int tipoQuarto, float diariaQuarto)
        {
            this.numQuarto = numQuarto;
            this.hotelIdHotel = hotelIdHotel;
            this.tipoQuarto = tipoQuarto;
            this.diariaQuarto = diariaQuarto;
        }

        public int NumQuarto { get; set; }
        public int HotelIdHotel { get; set; }
        public int TipoQuarto { get; set; }
        public float DiariaQuarto { get; set; }
    }
}
