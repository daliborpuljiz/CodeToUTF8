using System;
using System.IO;
using System.Text;

namespace CodeToUTF8
{
 public class TestInputArguments
 {

  private string _retError ;
  private string[] _inputArgs;

  private Encoding _inputEncoding;
  private Encoding _outputEncoding;
  private string _sourceFile;
  private string _destinationFile;

  //Argument 0: Encoding, i.e. "Windows-1250"
  //Argument 1: Source file name
  //Argument 2: Destination file name

  public TestInputArguments(string[] inputArgs)
  {
   _retError = "";
   _inputArgs = inputArgs;
   _inputEncoding = Encoding.Default;
   _outputEncoding = Encoding.UTF8;
  }


  public bool PassCheck()
  {
   
   if (_inputArgs.Length == 0)
   {
    _retError = "No arguments passed. Pass '/?' for help.";
    return false;
   };


   if (_inputArgs[0] == "/?" || _inputArgs[0] == "help" )
   {
    _retError = "Usage:";
    _retError += "\n\n" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + 
                 ": srcFileName/k /dstFileName/k inputEncoding/o outputEncoding/o";
    _retError += "\nRecodes an input text using. Version " + typeof(String).Assembly.GetName().Version + "\n";
    _retError += "\n - srcFileName: mandatory source file name to convert";
    _retError += "\n - dstFileName: mandatory destination file name of converted file";
    _retError += "\n - inputEncoding: optional input encoding, i.e. Windows-1250, if omitted using default";
    _retError += "\n - outputEncoding: optional output encoding, if ommited using UTF-8  ";
    _retError += "\n";
    return false;
   };


   if (_inputArgs.Length < 2)
   {
    _retError = "Too few arguments. Pass '/?' for help.";
    return false;
   }
   else
   {

    _sourceFile = _inputArgs[0];
    if (!File.Exists(_sourceFile))
    {
     _retError = "ERROR: Can't open the source file!";
     return false;
    }

    _destinationFile = _inputArgs[1];

   };


   if (_inputArgs.Length >= 3)
   {
    try { _inputEncoding = Encoding.GetEncoding(_inputArgs[2]); }
    catch
    {
     _retError = "ERROR: Unknown input encoding designator: " + _inputArgs[2];
     return false;
    }
   }

   if (_inputArgs.Length >= 4)
   {
    try { _outputEncoding = Encoding.GetEncoding(_inputArgs[3]); }
    catch
    {
     _retError = "ERROR: Unknown output encoding designator: " + _inputArgs[3];
     return false;
    }
   }

   return true;

  }



  public string SourceFile()
  { return _sourceFile; }

  public string DestinationFile()
  { return _destinationFile; }

  public Encoding InEncoding()
  { return _inputEncoding; }

  public Encoding OutEncoding()
  { return _outputEncoding; }

  public string ReturnErrorMsg()
  {
   return _retError;
  }


 }
}
