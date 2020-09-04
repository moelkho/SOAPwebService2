using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Compilation;
using System.IO;
using System.Drawing;

namespace LecteurServiceWCF
{
    public class DataProvider

    {
        // charger tous les articles 
        public List<Article> GetArticles()
        {
            List<Article> listArticles = new List<Article>();
            Article article;
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = "Server=localhost; Uid=user; Pwd=1234;Database=articlesdatabase;";

            cn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "article";
                cmd.CommandType = CommandType.TableDirect;
                cmd.Connection = cn;
                MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        article = new Article();
                        article.Id = "" + dr["ID"];
                        article.Titre = "" + dr["TITRE"];
                        article.Texte = "" + dr["TEXTE"];

                        //// si le champ image, like et dislike ne sont pas nulls 
                        //dans la base de donnees on les charges puis on les converti

                        if (!Convert.IsDBNull(dr["IMAGE"]))
                        {
                           article.Img = (byte[])dr["IMAGE"];

                        }
                       

                        if (!Convert.IsDBNull(dr["LIKES"]))
                        {
                            article.Like = Convert.ToInt32(dr["LIKES"]);

                        }
                

                        if (!Convert.IsDBNull(dr["DISLIKES"]))
                        {
                            article.Dislike = Convert.ToInt32(dr["DISLIKES"]);

                        }
                

                
                        listArticles.Add(article);
                
                    }
                        cn.Close();
           
                    return listArticles;
         }


        // ajouter un like a un article
        public bool AjouterLike(string titreArticle)
        {
            int likes =0;

            bool resultat = false;
            MySqlConnection cnx = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand query = new MySqlCommand();

            cnx.ConnectionString = "Server=localhost; Uid=user; Pwd=1234;Database=articlesdatabase;";
            
            cnx.Open();
            query.CommandText = "SELECT LIKES FROM article WHERE TITRE =@titre";
            query.Parameters.AddWithValue("@titre", titreArticle);
            query.Connection = cnx;
            MySqlDataReader re = query.ExecuteReader();
            while(re.Read())
            {
                   // si le champ like dans la base n est pas nulle on le cast en un entier

                if (!Convert.IsDBNull(re[0]))
                    likes = (int)re[0];
            }

            cnx.Close();

            cnx.Open();

            likes++;

            //// j'ai essayer de rassembler les deux requete, en une seule avec une sous requete mais ca 
            // n'a pas marche 
            cmd.CommandText = "UPDATE article SET LIKES=@likes WHERE TITRE=@titre";
            cmd.Parameters.AddWithValue("@titre", titreArticle);
            cmd.Parameters.AddWithValue("@likes", likes);
            
            cmd.Connection = cnx;

            int n = cmd.ExecuteNonQuery();
           
            if (n > 0) resultat = true;

            cnx.Close();
            return resultat;
        }

        // ajouter un dislike a un article en le cherchant par son titre

        public bool AjouterDislike(string titreArticle)
        {
            int dislikes = 0;
            bool resultat = false;
            MySqlConnection cnx = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand query = new MySqlCommand();

            cnx.ConnectionString = "Server=localhost; Uid=user; Pwd=1234;Database=articlesdatabase;";

            cnx.Open();
            query.CommandText = "SELECT DISLIKES FROM article WHERE TITRE =@titre";
            query.Parameters.AddWithValue("@titre", titreArticle);
            query.Connection = cnx;
            MySqlDataReader re = query.ExecuteReader();
            while (re.Read())
            {   if(!Convert.IsDBNull(re[0]))
                dislikes = (int)re[0];
            }

            cnx.Close();

            cnx.Open();

            dislikes++;
            cmd.CommandText = "UPDATE article SET DISLIKES=@dislikes WHERE TITRE=@titre";
            cmd.Parameters.AddWithValue("@titre", titreArticle);
            cmd.Parameters.AddWithValue("@dislikes", dislikes);

            cmd.Connection = cnx;

            int n = cmd.ExecuteNonQuery();

            if (n > 0) resultat = true;

            cnx.Close();
           
            return resultat;
        }


        // chercher un article par un mot cle 

       public  List<Article> ChercherArticle(String txt)
        {
            List<Article> listArticles = new List<Article>();
            Article article;
            MySqlConnection cnx = new MySqlConnection();
            MySqlCommand cmd = new MySqlCommand();
           

            cnx.ConnectionString = "Server=localhost; Uid=user; Pwd=1234;Database=articlesdatabase;";

            cnx.Open();

            cmd.CommandText = "SELECT * FROM article WHERE CONCAT(`TITRE`,`TEXTE`) LIKE '%" +txt+"%'";
            cmd.Connection = cnx;

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                article = new Article();
                article.Id = "" + dr["ID"];
                article.Titre = "" + dr["TITRE"];
                article.Texte = "" + dr["TEXTE"];

                if (!Convert.IsDBNull(dr["IMAGE"]))
                {
                    article.Img = (byte[])dr["IMAGE"];

                }


                if (!Convert.IsDBNull(dr["LIKES"]))
                {
                    article.Like = Convert.ToInt32(dr["LIKES"]);

                }


                if (!Convert.IsDBNull(dr["DISLIKES"]))
                {
                    article.Dislike = Convert.ToInt32(dr["DISLIKES"]);

                }



                listArticles.Add(article);

            }
            cnx.Close();

            return listArticles;
        }

    }
}