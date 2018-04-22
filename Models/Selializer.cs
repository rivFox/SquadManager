using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ZarzadzeniaOddzialamiNET.Models
{
    class Serializer
    {
        public GameController ReadContent(string _documentName)
        {
            TextReader tr = new StreamReader(_documentName + ".xml");
            XmlSerializer sr = new XmlSerializer(typeof(GameController));
            GameController Game = (GameController)sr.Deserialize(tr);
            tr.Close();
            return Game;
        }

        public void WriteContent(GameController Game, string _documentName)
        {
            TextWriter tw = new StreamWriter(_documentName + ".xml");
            XmlSerializer sr = new XmlSerializer(typeof(GameController));

            sr.Serialize(tw, Game);
            tw.Close();
        }


    }
}
