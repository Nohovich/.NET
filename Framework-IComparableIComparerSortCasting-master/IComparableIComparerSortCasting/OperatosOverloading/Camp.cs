using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IComparableIComparerSortCasting.OperatosOverloading
{
    public class Camp
    {
        public int _latitude { get; set; }
        public int _longitude { get; set; }
        public int _numberOfPepole { get; set; }
        public int _numberOfTents { get; set; }
        public int _numberOfFlashlights { get; set; }
        private readonly int ID;
        private static int lastCampID = 0;

        public Camp(int latitude, int longitude, int numberOfPepole, int numberOfTents, int numberOfFlashlights)
        {
            _latitude = latitude;
            _longitude = longitude;
            _numberOfPepole = numberOfPepole;
            _numberOfTents = numberOfTents;
            _numberOfFlashlights = numberOfFlashlights;
            lastCampID++;
            ID = lastCampID;
        }
        public Camp()
        {

        }
        public static bool operator ==(Camp camp1, Camp camp2)
        {
            if (ReferenceEquals(camp1, null) && ReferenceEquals(camp2, null))
            {
                return true;
            }
            if (ReferenceEquals(camp1, null) || ReferenceEquals(camp2, null))
            {
                return false;
            }
            if (camp1.ID == camp2.ID)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Camp camp1, Camp camp2)
        {
            return !(camp1 == camp2);
        }
        public static bool operator >(Camp camp1, Camp camp2)
        {
            if (camp1.ID == camp2.ID)
            {
                return false;
            }
            if (camp1._numberOfPepole > camp2._numberOfPepole)
            {
                return true;
            }
            return false;
        }
        public static bool operator <(Camp camp1, Camp camp2)
        {
            if (camp1.ID == camp2.ID)
            {
                return false;
            }
            if (camp1._numberOfPepole < camp2._numberOfPepole)
            {
                return true;
            }
            return false;
        }
        public static bool operator >=(Camp camp1, Camp camp2)
        {

            if (camp1._numberOfPepole >= camp2._numberOfPepole)
            {
                return true;
            }
            return false;
        }
        public static bool operator <=(Camp camp1, Camp camp2)
        {
            if (camp1._numberOfPepole <= camp2._numberOfPepole)
            {
                return true;
            }
            return false;
        }
        public static Camp operator +(Camp camp1, Camp camp2)
        {
            Camp camp = new Camp(camp1._latitude + camp2._latitude, camp1._longitude + camp2._longitude, camp1._numberOfPepole + camp2._numberOfPepole, camp1._numberOfTents + camp2._numberOfTents, camp1._numberOfFlashlights + camp2._numberOfFlashlights);
            lastCampID = lastCampID - 2;
            return camp;
        }

        public override bool Equals(object obj)
        {
            Camp camp = obj as Camp;
            return this == camp;

        }

        public override int GetHashCode()
        {
            return ID;
        }
        public override string ToString()
        {
            return $"Camp ID {ID}, number Of People {_numberOfPepole}, _number of flashlights {_numberOfFlashlights}, number Of tents {_numberOfTents}";
        }
    }

}