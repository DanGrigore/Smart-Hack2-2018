using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Database
/// </summary>
public class Database
{
    public static string GetConnectionString()
    {
        return System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}