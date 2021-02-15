using System.IO;
using System.Text;

namespace CodeToUTF8
{
 public class ConvertFile
 {

  private bool _success = false;
  private string _errMsg = "";

  public ConvertFile(
    string sourceFile
   ,string destinationFile
   ,Encoding inputEncoding
   ,Encoding outputEncoding
   )
  {

   string strSRT;
   StreamReader streamRead = new StreamReader(sourceFile, inputEncoding, true);
   strSRT = streamRead.ReadToEnd();  //Convert to string
   streamRead.Close();

   try {
    File.WriteAllText(destinationFile, strSRT, outputEncoding);
    _success = true;
   }
   catch
   {
    _errMsg = "ERROR: Destination file could not be written: (" + destinationFile + ")\n";
    _success = false; }

  }

  public bool Success()
  { return _success; }

  public string RetMessage()
  { return _errMsg; }


 }

}
