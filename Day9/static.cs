using System;
using System.Security.Cryptography.X509Certificates;
public static class GeneralUse
{
    //static constructors are not public so we no need to create instance
    public static int Rno;
    static GeneralUse()
    {
        //it works only once the value would be present there 
        //static constructor supprts static variables only nrml instance variables cannot be created
      
        Rno=1;
    
    }
}