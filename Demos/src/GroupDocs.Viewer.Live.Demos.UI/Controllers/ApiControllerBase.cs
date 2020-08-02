using System;
using System.IO;
using System.Web.Http;
using GroupDocs.Viewer.Live.Demos.UI.Models;
using System.Threading.Tasks;
using System.IO.Compression;

namespace GroupDocs.Viewer.Live.Demos.UI.Controllers
{
	public abstract class ApiControllerBase : ApiController
	{
		protected delegate void ActionDelegate(string inFilePath, string outPath, string zipOutFolder);
		protected delegate void inFileActionDelegate(string inFilePath);

		protected string GetoutFileExtension(string fileName, string folderName)
		{
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;
			return Path.GetExtension(fileName);
		}

		protected async Task<Response> Process(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, ActionDelegate action, bool isMultiple)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName + " OutFileExtension: " + outFileExtension;
			var watch = System.Diagnostics.Stopwatch.StartNew();

			string guid = folderName;
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
			string outPath = AppSettings.OutputDirectory + "/" + guid;

			string zipOutfileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
			string zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
			string zipOutFolder = AppSettings.OutputDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				if (System.IO.File.Exists(zipOutPath))
					System.IO.File.Delete(zipOutPath);
				if (!createZip)
				{
					if (!Directory.Exists(outPath))
					{
						Directory.CreateDirectory(outPath);
					}
				}
				outPath += "/" + outfileName;
				action(fileName, outPath, zipOutFolder);
			}
			catch (Exception exc)
			{
				string statusMessage = "500 " + exc.Message;
				statusValue = exc.Message;
				if (exc.Message.Contains("The given key was not present in the dictionary"))
					statusValue = "Conversion from '" + Path.GetExtension(fileName).ToUpper() + "' to '" + outFileExtension.ToUpper() + "' is not supported.";
				statusCodeValue = 500;
				ex = exc;
			}

			return await Task.FromResult(new Response
			{
				FileName = (createZip ? outfileName : folderName + "/" + outfileName),
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			});
		}

		protected async Task<Response> Process(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, ActionDelegate action)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName + " OutFileExtension: " + outFileExtension;
			var watch = System.Diagnostics.Stopwatch.StartNew();

			string guid = folderName;
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
			string outPath = AppSettings.OutputDirectory + "/" + guid;

			string zipOutfileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
			string zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
			string zipOutFolder = AppSettings.OutputDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				if (System.IO.File.Exists(zipOutPath))
					System.IO.File.Delete(zipOutPath);
				if (!createZip)
				{
					if (!Directory.Exists(outPath))
					{
						Directory.CreateDirectory(outPath);
					}
				}
				outPath += "/" + outfileName;
				action(fileName, outPath, zipOutFolder);

				if (Directory.GetFiles(AppSettings.OutputDirectory + "/" + guid + "/").Length > 1)
					createZip = true;
				else
					createZip = false;

				if (createZip)
				{
					outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
					outPath = zipOutFolder + "/" + outfileName;
					Directory.CreateDirectory(zipOutFolder);
				}

				if (createZip)
				{
					ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
					Directory.Delete(zipOutFolder, true);
					outfileName = zipOutfileName;
				}

				try
				{
					//Directory.Delete(sourceFolder, true);
				}
				catch
				{ }               
			}
			catch (Exception exc)
			{
				string statusMessage = "500 " + exc.Message;
				statusValue = exc.Message;
				if (exc.Message.Contains("The given key was not present in the dictionary"))
					statusValue = "Conversion from '" + Path.GetExtension(fileName).ToUpper() + "' to '" + outFileExtension.ToUpper() + "' is not supported.";
				statusCodeValue = 500;
				ex = exc;
			}

			return await Task.FromResult(new Response
			{
				FileName = (createZip ? outfileName : folderName + "/" + outfileName),
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			});
		}

		protected async Task<Response> Process(string controllerName, string fileName, string folderName, inFileActionDelegate action)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName;
			string guid = Guid.NewGuid().ToString();
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				action(fileName);

				try
				{
					//Directory.Delete(sourceFolder, true);
				}
				catch
				{ }

				// Log information to NLogging database
				//NLogger.LogInfo(logMsg, productFamily);

			}
			catch (Exception exc)
			{
				statusValue = "500 " + exc.Message;
				statusCodeValue = 500;
				ex = exc;
			}
			return await Task.FromResult(new Response
			{
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			});
		}

		protected async Task<Response> Process2(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, ActionDelegate action)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName + " OutFileExtension: " + outFileExtension;
			string guid = folderName;
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
			string outPath = AppSettings.OutputDirectory + "/" + guid;

			string zipOutfileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
			string zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
			string zipOutFolder = AppSettings.OutputDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;

			try
			{
				if (System.IO.File.Exists(zipOutPath))
					System.IO.File.Delete(zipOutPath);

				if (!createZip)
				{
					if (!Directory.Exists(outPath))
					{
						Directory.CreateDirectory(outPath);
					}
				}
				outPath += "/" + outfileName;
				action(fileName, outPath, zipOutFolder);

				if (createZip)
				{
					outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
					outPath = zipOutFolder + "/" + outfileName;
					Directory.CreateDirectory(zipOutFolder);
				}

				if (createZip)
				{
					ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
					Directory.Delete(zipOutFolder, true);
					outfileName = zipOutfileName;
				}

				try
				{
					Directory.Delete(sourceFolder, true);
				}
				catch
				{ }			

			}
			catch (Exception exc)
			{
				statusValue = "500 " + exc.Message;
				statusCodeValue = 500;				
			}

			return await Task.FromResult(new Response
			{
				FileName = (createZip ? outfileName : folderName + "/" + outfileName),
				Status = statusValue,
				StatusCode = statusCodeValue
			});
		}

		protected Response ProcessConversion(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, ActionDelegate action, bool isMultiple)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName + " OutFileExtension: " + outFileExtension;
			var watch = System.Diagnostics.Stopwatch.StartNew();

			string guid = folderName;
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
			string outPath = AppSettings.OutputDirectory + "/" + guid;

			string zipOutfileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
			string zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
			string zipOutFolder = AppSettings.OutputDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				if (System.IO.File.Exists(zipOutPath))
					System.IO.File.Delete(zipOutPath);
				if (!createZip)
				{
					if (!Directory.Exists(outPath))
					{
						Directory.CreateDirectory(outPath);
					}
				}
				outPath += "/" + outfileName;
				action(fileName, outPath, zipOutFolder);

				// Log information to NLogging database
				logMsg = "TimeElapsed: " + watch.Elapsed.ToString("mm\\:ss") + ", " + logMsg;				
			}
			catch (Exception exc)
			{
				string statusMessage = "500 " + exc.Message;
				statusValue = exc.Message;
				if (exc.Message.Contains("The given key was not present in the dictionary"))
					statusValue = "Conversion from '" + Path.GetExtension(fileName).ToUpper() + "' to '" + outFileExtension.ToUpper() + "' is not supported.";
				statusCodeValue = 500;

				// Log error message to NLogging database
				logMsg = "TimeElapsed: " + watch.Elapsed.ToString("mm\\:ss") + ", " + logMsg;
				ex = exc;
			}

			return new Response
			{
				FileName = (createZip ? outfileName : folderName + "/" + outfileName),
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			};
		}

		protected Response ProcessConversion(string controllerName, string fileName, string folderName, string outFileExtension, bool createZip, ActionDelegate action)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName + " OutFileExtension: " + outFileExtension;
			var watch = System.Diagnostics.Stopwatch.StartNew();

			string guid = folderName;
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
			string outPath = AppSettings.OutputDirectory + "/" + guid;

			string zipOutfileName = Path.GetFileNameWithoutExtension(fileName) + ".zip";
			string zipOutPath = AppSettings.OutputDirectory + zipOutfileName;
			string zipOutFolder = AppSettings.OutputDirectory + guid;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				if (System.IO.File.Exists(zipOutPath))
					System.IO.File.Delete(zipOutPath);
				if (!createZip)
				{
					if (!Directory.Exists(outPath))
					{
						Directory.CreateDirectory(outPath);
					}
				}
				outPath += "/" + outfileName;
				action(fileName, outPath, zipOutFolder);

				if (Directory.GetFiles(AppSettings.OutputDirectory + "/" + guid + "/").Length > 1)
					createZip = true;
				else
					createZip = false;

				if (createZip)
				{
					outfileName = Path.GetFileNameWithoutExtension(fileName) + outFileExtension;
					outPath = zipOutFolder + "/" + outfileName;
					Directory.CreateDirectory(zipOutFolder);
				}

				if (createZip)
				{
					ZipFile.CreateFromDirectory(zipOutFolder, zipOutPath);
					Directory.Delete(zipOutFolder, true);
					outfileName = zipOutfileName;
				}

				try
				{
					//Directory.Delete(sourceFolder, true);
				}
				catch
				{ }

				// Log information to NLogging database
				logMsg = "TimeElapsed: " + watch.Elapsed.ToString("mm\\:ss") + ", " + logMsg;
			}
			catch (Exception exc)
			{
				string statusMessage = "500 " + exc.Message;
				statusValue = exc.Message;
				if (exc.Message.Contains("The given key was not present in the dictionary"))
					statusValue = "Conversion from '" + Path.GetExtension(fileName).ToUpper() + "' to '" + outFileExtension.ToUpper() + "' is not supported.";
				statusCodeValue = 500;

				// Log error message to NLogging database
				logMsg = "TimeElapsed: " + watch.Elapsed.ToString("mm\\:ss") + ", " + logMsg;
				ex = exc;
			}

			return new Response
			{
				FileName = (createZip ? outfileName : folderName + "/" + outfileName),
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			};
		}

		protected Response ProcessConversion(string controllerName, string fileName, string folderName, inFileActionDelegate action)
		{
			string logMsg = "ControllerName: " + controllerName + " FileName: " + fileName;
			string guid = Guid.NewGuid().ToString();
			string sourceFolder = AppSettings.WorkingDirectory + folderName;
			fileName = sourceFolder + "/" + fileName;

			string statusValue = "OK";
			int statusCodeValue = 200;
			Exception ex = null;

			try
			{
				action(fileName);

				try
				{
					//Directory.Delete(sourceFolder, true);
				}
				catch
				{ }

				// Log information to NLogging database
				//NLogger.LogInfo(logMsg, productFamily);

			}
			catch (Exception exc)
			{
				statusValue = "500 " + exc.Message;
				statusCodeValue = 500;
				// Log error message to NLogging database
				ex = exc;
			}
			return new Response
			{
				Status = statusValue,
				StatusCode = statusCodeValue,
				exc = ex
			};
		}
	}
}