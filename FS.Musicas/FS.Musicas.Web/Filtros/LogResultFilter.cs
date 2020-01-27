using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FS.Musicas.Web.Filtros
{
    public class LogResultFilter : FilterAttribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string mensagem = string.Format("[{0}] Resultado : {1}/{2} | {3}",
                DateTime.Now.ToString(),  //0
                filterContext.RouteData.Values["Controller"].ToString(), //1
                filterContext.RouteData.Values["Action"].ToString(),//2
                filterContext.Result.ToString()
                );
            Debug.WriteLine(mensagem);

        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string mensagem = string.Format("[{0}] Processando resultados : {1}/{2} ",
                DateTime.Now.ToString(),  //0
                filterContext.RouteData.Values["Controller"].ToString(), //1
                filterContext.RouteData.Values["Action"].ToString()//2
                );
            Debug.WriteLine(mensagem);

        }
    }
}