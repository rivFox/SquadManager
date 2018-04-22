using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Drawing;

namespace ZarzadzeniaOddzialamiNET.Models
{
    [Serializable]
    public class ElementOfNature
    {
        /*
         * 0 Fire;
         * 1 Wind;
         * 2 Lighting
         * 3 Earth
         * 4 Water
        */
        public int indexOfElement { get; set; }
        public float[] modificators = new float[5];
        public ElementOfNature() { }
        public ElementOfNature(int index, float fire = 1f, float wind = 1f, float lightning = 1f, float earth = 1f, float water = 1f)
        {
            modificators[0] = fire;
            modificators[1] = wind;
            modificators[2] = lightning;
            modificators[3] = earth;
            modificators[4] = water;
        }

        public float getModificator(int index)
        {
            return modificators[index];
        }
    }
}   
