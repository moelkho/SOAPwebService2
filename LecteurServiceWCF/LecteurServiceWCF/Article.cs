using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace LecteurServiceWCF
{
        [DataContract]
    public class Article
    {
        [DataMember]
       public string Id { get; set; }
        [DataMember]
        public string Titre { get; set; }
        [DataMember]
        public string Texte { get; set; }
        [DataMember]
        public byte[] Img {get;set;}
        [DataMember]
        public int Like { get; set; }
        [DataMember]
        public int Dislike { get; set; }

        public Article() { }

        public Article(string id, string titre, String texte,byte[] img, int like, int dislike)
        { this.Id = id;
            this.Titre = titre;
            this.Texte = texte;
            this.Img = img;
            this.Like = like;
            this.Dislike = dislike;
        }

        public Article(string id, string titre, String texte, byte[] img)
        {
            this.Id = id;
            this.Titre = titre;
            this.Texte = texte;
            this.Img = img;
            
        }
    }

}