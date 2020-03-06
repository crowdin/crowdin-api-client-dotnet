using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Crowdin.Api.Typed
{
	[XmlRoot("success")]
	public sealed class ExportStatus : IXmlSerializable
	{
		public const string Finished = "finished";

		public const string InProgress = "in-progress";

		/// <summary>The export has never been built</summary>
		public const string None = "none";

		public string Status { get; private set; }

		public int Progress { get; private set; }

		public DateTime LastBuild { get; private set; }

		public string CurrentFile { get; private set; }

		public string CurrentLanguage { get; private set; }

		XmlSchema IXmlSerializable.GetSchema() => null;

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			reader.Read();
			if (reader.ReadToNextSibling("status"))
				Status = reader.ReadElementContentAsString();
			if (reader.ReadToNextSibling("progress"))
				Progress = reader.ReadElementContentAsInt();
			if (reader.ReadToNextSibling("last_build"))
			{
				try
				{
					// The XML contains a string similar to "2018-10-18T16:08:00+0000".
					// XmlReader can't parse the "+0000", but DateTime can.
					LastBuild = DateTime.Parse(reader.ReadElementContentAsString());
				}
				catch (FormatException)
				{
					// If the export has never been built, last_build is "never", which can't be parsed
				}
			}

			if (reader.ReadToNextSibling("current_file"))
				CurrentFile = reader.ReadElementContentAsString();
			if (reader.ReadToNextSibling("current_language"))
				CurrentLanguage = reader.ReadElementContentAsString();
		}

		void IXmlSerializable.WriteXml(XmlWriter writer) => throw new NotSupportedException();
	}
}