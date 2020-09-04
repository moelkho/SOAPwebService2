using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LecteurServiceWCF
{
   
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Article> GetAllArticles();

        [OperationContract]
        bool SetLike(string titreArticle);

        [OperationContract]
        bool SetDislike(string titreArticle);

        [OperationContract]
         List<Article> SetSearch(string txt);
    }


  
}
