using System;
using System.Collections.Generic;
using System.Text;

namespace JonasJohn.Tools.Files2Text
{
	
	[global::System.Serializable]
	public class LinesDontMatchException : Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public LinesDontMatchException() { }
		public LinesDontMatchException(string message) : base(message) { }
		public LinesDontMatchException(string message, Exception inner) : base(message, inner) { }
		protected LinesDontMatchException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	
	[global::System.Serializable]
	public class TempFileDoesNotExistException : Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public TempFileDoesNotExistException() { }
		public TempFileDoesNotExistException(string message) : base(message) { }
		public TempFileDoesNotExistException(string message, Exception inner) : base(message, inner) { }
		protected TempFileDoesNotExistException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}

	
	[global::System.Serializable]
	public class RenameProcessFailedException : Exception
	{
		//
		// For guidelines regarding the creation of new exception types, see
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
		// and
		//    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
		//

		public RenameProcessFailedException() { }
		public RenameProcessFailedException(string message) : base(message) { }
		public RenameProcessFailedException(string message, Exception inner) : base(message, inner) { }
		protected RenameProcessFailedException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}


}
