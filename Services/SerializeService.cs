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
        private readonly IGuestDb _guestDb;

        public SerializeService(IGuestDb guestDb)
        {
            _guestDb = guestDb;
        }

        public string SerializeFullGuestList(string path)
        {
            var fullPath = path + "\\AllGuestList.xml";
            var serializer = new XmlSerializer(typeof(List<Guest>));
            var writer = new StreamWriter(fullPath);
            serializer.Serialize(writer, _guestDb.GuestList);
            writer.Close();

            return fullPath;
        }

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

        public void DeserializeFullGuestList(string path)
        {
            var deserializer = new XmlSerializer(typeof(List<Guest>));
            var reader = new StreamReader(path + "\\AllGuestList.xml");

            var readList = (List<Guest>)deserializer.Deserialize(reader);

            foreach (Guest guest in readList)
            {
                _guestDb.GuestList.Add(new Guest(guest.Name, guest.Surname, guest.Gender, guest.Status));
            }
        }
    }
}
