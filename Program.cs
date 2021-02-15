using System;


namespace CodeToUTF8
{
 class Program
 {
  static void Main(string[] args)
  {

   TestInputArguments tInput = new TestInputArguments(args);
   if (!tInput.PassCheck())
   { Console.WriteLine(tInput.ReturnErrorMsg()); }

   else
   {

    ConvertFile cf = new ConvertFile(tInput.SourceFile(), tInput.DestinationFile(), tInput.InEncoding(), tInput.OutEncoding());
    if (cf.Success())
    {
     Console.WriteLine("Success. New file: {0}. Encoding: {1}", tInput.DestinationFile(), tInput.OutEncoding()); 
    }
    else
    {
     Console.WriteLine(cf.RetMessage());
    }

    //Console.WriteLine("All done");
    //Console.ReadLine();


   }


  }
 }
}
