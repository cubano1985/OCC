using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models;
using System.IO;
using DataBase;

namespace Services
{
    public class SerializeService : ISerializeService
    {
        #region constructor
        private readonly IGuestDb _guestDb;

        public SerializeService(IGuestDb guestDb)
        {
            _guestDb = guestDb;
        }
        #endregion

        /// <summary>
        /// Method that serializes all guests to XML
        /// </summary>
        /// <param name="path">Actual path to app directory</param>
        /// <returns>Path to XML file</returns>
        public string SerializeFullGuestList(string path)
        {
            var fullPath = path + "\\AllGuestList.xml";
            var serializer = new XmlSerializer(typeof(List<Guest>));
            var writer = new StreamWriter(fullPath);
            serializer.Serialize(writer, _guestDb.GuestList);
            writer.Close();

            return fullPath;
        }

        /// <summary>
        /// Method that serializes only attending guests to XML
        /// </summary>
        /// <param name="path">Actual path to app directory</param>
        /// <returns>Path to XML file</returns>
        public string SerializeAttendingGuestList(string path)
        {
            var fullPath = path + "\\AttendingGuestList.xml";
            var serializer = new XmlSerializer(typeof(List<Guest>));
            var writer = new StreamWriter(fullPath);
            var attendingGuestList = _guestDb.GuestList.Where(onlyAttending => onlyAttending.Status == GuestStatus.Attending).ToList();
            serializer.Serialize(writer, attendingGuestList);
            writer.Close();

            return fullPath;
        }

        /// <summary>
        /// Method that reads all guest list
        /// </summary>
        /// <param name="path">Actual path to app directory</param>
        /// <returns>True if data was read without problems, false otherwise</returns>
        public bool DeserializeFullGuestList(string path)
        {
            try
            {
                var deserializer = new XmlSerializer(typeof(List<Guest>));
                var reader = new StreamReader(path + "\\AllGuestList.xml");

                var readList = (List<Guest>)deserializer.Deserialize(reader);
                reader.Close();

                foreach (Guest guest in readList)
                {
                    _guestDb.GuestList.Add(new Guest(guest.Name, guest.Surname, guest.Gender, guest.Status));
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
