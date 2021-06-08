using System;
using System.ComponentModel.DataAnnotations;

namespace EDennis.SampleApp
{
    public class Rgb
    {
        public int Id { get; set; }


        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0,255)]
        public int Red { get; set; }
        [Range(0, 255)]
        public int Green { get; set; }
        [Range(0, 255)]
        public int Blue { get; set; }
    }
}
