using System;
public class LoginFailedException : Exception
{
    public LoginFailedException(string msg): base(msg){}
}
public class LoginSystem
{
    static void Main()
    {
        int attepts=0;
        try
        {
            while (true)
            {
                attepts ++;
                if(attepts > 3)
                {
                     throw new LoginFailedException("Login attempts exceeded");
                }
                Console.WriteLine("Login attempts failed");
            }
        }
        catch(LoginFailedException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}