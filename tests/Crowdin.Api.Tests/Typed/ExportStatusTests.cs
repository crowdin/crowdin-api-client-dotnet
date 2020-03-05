using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Crowdin.Api.Typed;
using Xunit;

namespace Crowdin.Api.Tests.Typed
{
	public class ExportStatusTests
	{
		[Fact]
		public static void ExportIsFinished()
		{
			const string lastBuild = "2018-10-22T13:49:00+0000";
			const string statusXml =
				@"<?xml version=""1.0"" encoding=""UTF-8""?>
				<success>
				  <status>" + ExportStatus.Finished + @"</status>
				  <progress>100</progress>
				  <last_build>" + lastBuild + @"</last_build>
				</success>";

			var serializer = new XmlSerializer(typeof(ExportStatus));
			using (var stringReader = new StringReader(statusXml))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				Assert.True(serializer.CanDeserialize(xmlReader));
				var result = serializer.Deserialize(xmlReader);
				Assert.IsType<ExportStatus>(result);
				var status = (ExportStatus) result;
				Assert.Equal(ExportStatus.Finished, status.Status);
				Assert.Equal(100, status.Progress);
				Assert.Equal(DateTime.Parse(lastBuild), status.LastBuild);
				Assert.Null(status.CurrentFile);
				Assert.Null(status.CurrentLanguage);
			}
		}

		[Fact]
		public static void ExportInProgress()
		{
			const string lastBuild = "2018-10-18T16:08:00+0000";
			const string currentFile = "example.xml";
			const string currentLanguage = "Ukrainian";
			const string statusXml =
				@"<?xml version=""1.0"" encoding=""UTF-8""?>
				<success>
				  <status>" + ExportStatus.InProgress + @"</status>
				  <progress>29</progress>
				  <last_build>" + lastBuild + @"</last_build>
				  <current_file>" + currentFile + @"</current_file>
				  <current_language>" + currentLanguage + @"</current_language>
				</success>";

			var serializer = new XmlSerializer(typeof(ExportStatus));
			using (var stringReader = new StringReader(statusXml))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				Assert.True(serializer.CanDeserialize(xmlReader));
				var result = serializer.Deserialize(xmlReader);
				Assert.IsType<ExportStatus>(result);
				var status = (ExportStatus) result;
				Assert.Equal(ExportStatus.InProgress, status.Status);
				Assert.Equal(29, status.Progress);
				Assert.Equal(DateTime.Parse(lastBuild), status.LastBuild);
				Assert.Equal(currentFile, status.CurrentFile);
				Assert.Equal(currentLanguage, status.CurrentLanguage);
			}
		}

		[Fact]
		public static void ExportNeverBuilt()
		{
			const string statusXml =
				@"<?xml version=""1.0"" encoding=""UTF-8""?>
				<success>
				  <status>" + ExportStatus.None + @"</status>
				  <progress>0</progress>
				  <last_build>never</last_build>
				</success>";

			var serializer = new XmlSerializer(typeof(ExportStatus));
			using (var stringReader = new StringReader(statusXml))
			using (var xmlReader = XmlReader.Create(stringReader))
			{
				Assert.True(serializer.CanDeserialize(xmlReader));
				var result = serializer.Deserialize(xmlReader);
				Assert.IsType<ExportStatus>(result);
				var status = (ExportStatus) result;
				Assert.Equal(ExportStatus.None, status.Status);
				Assert.Equal(0, status.Progress);
				Assert.Equal(DateTime.MinValue, status.LastBuild);
				Assert.Null(status.CurrentFile);
				Assert.Null(status.CurrentLanguage);
			}
		}
	}
}
