using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.ModelBinding;

namespace LecteurServiceWCF
{
    
    public class Service1 : IService1
    {
       // charger tous les articles
        public List<Article> GetAllArticles()
        {
            return new DataProvider().GetArticles();
        }

        // ajouter un dislike a l article, on cherche l'article par son titre 

        public bool SetDislike(string titreArticle)
        {
            return new DataProvider().AjouterDislike(titreArticle);
        }

        // ajouter un like a l article, on cherche l'article par son titre 
        public bool SetLike(string titreArticle)
        {
            return new DataProvider().AjouterLike(titreArticle);
        }

        // chercher un article par un mot cle 
        public List<Article> SetSearch(string motRecherche)
        {
            return new DataProvider().ChercherArticle(motRecherche);
        }
    }
}
