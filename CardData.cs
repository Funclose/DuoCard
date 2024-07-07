using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoCards
{
    internal class CardData
    {
        public string Path { get; set; }

        public void Save(Dictionary<string, string> dict)
        {
            using (FileStream fs = new FileStream(Path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    foreach (var item in dict)
                    {
                        bw.Write(item.Key);
                        bw.Write(item.Value);
                    }
                }
            }
        }
        public Dictionary<string, string> Load()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            using (FileStream fs = new FileStream(Path, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Length > br.BaseStream.Position)
                    {
                        string key = br.ReadString();
                        string value = br.ReadString();
                        dict.Add(key, value);
                    }
                }
            }
            return dict;
        }
    }
}
